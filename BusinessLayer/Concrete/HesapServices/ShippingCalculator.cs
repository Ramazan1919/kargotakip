using BusinessLayer.Abstract;
using DataEntity;
using DataEntity.DTO;
using DataEntity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete.HesapServices
{
    public class ShippingCalculator
    {
        private readonly List<WeightAndSize> _weightAndSizeList;

        public ShippingCalculator(IWeightAndSizeServices weightAndSizeServices )
        {

            _weightAndSizeList = weightAndSizeServices.GetAll();
        }

        public RsEstimateShipmentDto CalculateShip(string SenderAddress,string ReceiverAddress, int Weight, ShipSize Size)
        {
            var distance = 100;
            var tablokarsiligi = _weightAndSizeList.Find(x => x.WeightMin <= Weight && x.WeightMax >= Weight && x.Size==Size).Price;
            var cash = tablokarsiligi * Weight * distance;
            var result = new RsEstimateShipmentDto
            {
                Price = cash,
                Weight = Weight,
                ReceiverAddress = ReceiverAddress,
                SenderAddress = SenderAddress,
                Size = Size
            };
            return result;

        }
    }
}
