using BusinessLayer.Abstract;
using DataEntity;
using DataEntity.DTO;
using DataEntity.Enums;
using StudentInfo.BusinessLayer.WebRequester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.HesapServices
{
    public class ShippingCalculator
    {
        private readonly List<WeightAndSize> _weightAndSizeList;
        private readonly IShippmentServices _shippmentServices;

        public ShippingCalculator(IShippmentServices shippmentService, IWeightAndSizeServices weightAndSizeServices)
        {

            _weightAndSizeList = weightAndSizeServices.GetAll();
            _shippmentServices = shippmentService;
        }

        public double CalculateTime(int distance)
        {

            return distance / 20;


        }

        public void updateCargos()
        {
            List<Shipment> shipments = _shippmentServices.GetAll();//new List<Shipment>();


            foreach (var item in shipments)
            {
                if (item.IsActive)
                {
                    item.Remaining = item.Remaining - 20;
                    if (item.Remaining < 0)
                    {
                        item.IsActive = false;
                    }
                    var rTime = CalculateTime( item.Remaining );
                    var msg = calculateRemainingTime(rTime);
                    _shippmentServices.Update(item);
                }
            }
                
        }

        public string calculateRemainingTime(double time)
        {
            
            string msg = "";
            if (time > 24)
            {
                int kalan = Convert.ToInt32(time % 24);
                int mod = Convert.ToInt32(time / 24);
                msg = mod + " day " + kalan + " hour";
            }
            else
                msg = time + " hour";

            return msg;
        }


        public RsEstimateShipmentDto CalculateShip(string senderAddress, string receiverAddress, int Weight, ShipSize Size)
        {
            var sender = GetCoordinatesForAddress(senderAddress);
            var receiver = GetCoordinatesForAddress(receiverAddress);

            var distance = CalculateDistance(sender, receiver);
            var weightSize = _weightAndSizeList.Find(x => x.WeightMin <= Weight && x.WeightMax >= Weight && x.Size == Size);

            var tablokarsiligi = weightSize != null ? weightSize.Price : 0;
            double cash = Convert.ToDouble(tablokarsiligi) * Weight * distance;
            var result = new RsEstimateShipmentDto
            {
                Price = Convert.ToDecimal(cash),
                Weight = Weight,
                ReceiverAddress = senderAddress,
                SenderAddress = receiverAddress,
                Size = Size,
                Distance = Convert.ToInt32(distance)
            };
            return result;

        }

        private GeoLocationInfo GetCoordinatesForAddress(string address)
        {
            try
            {

                var url = string.Format("/search.php?q={0}&polygon_geojson=0&format=jsonv2", address);

                var webRequester = new WebRequestManager("https://nominatim.openstreetmap.org");
                var result = webRequester.DoRequest<List<GeoLocationInfo>>(url, false);
                if (result != null && result.Count > 0)
                {
                    return result.OrderByDescending(o => o.importance).FirstOrDefault();

                }
            }
            catch (Exception e)
            {

            }


            //JsonObject jsonObject = JsonObject.Parse(await httpResult.Content.ReadAsStringAsync());

            //return jsonObject.GetNamedObject("address").GetNamedString("lat"); // <-- what about "lon"?
            return null;
        }

        public double CalculateDistance(GeoLocationInfo start, GeoLocationInfo target, char unit = 'K')
        {
            if (start != null && target != null)
            {
                return CalculateDistance(Convert.ToDouble(start.Lat), Convert.ToDouble(start.Lon), Convert.ToDouble(target.Lat), Convert.ToDouble(target.Lon), unit);
            }
            return 0;
        }

        public double CalculateDistance(double lat1, double lon1, double lat2, double lon2, char unit = 'K')
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            switch (unit)
            {
                case 'K': //Kilometers -> default
                    return dist * 1.609344;
                case 'N': //Nautical Miles 
                    return dist * 0.8684;
                case 'M': //Miles
                    return dist;
            }

            return dist;
        }
    }

    public class GeoLocationInfo
    {
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string display_name { get; set; }
        public string icon { get; set; }
        public decimal importance { get; set; }
    }
}
