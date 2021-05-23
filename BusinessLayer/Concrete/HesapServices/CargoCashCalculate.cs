using BusinessLayer.Abstract;
using DataEntity;
using DataEntity.DTO;
using DataEntity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete.HesapServices
{
    public class CargoCashCalculate
    {
        private readonly List<WeightAndSize> _weightAndSizeList;

        public CargoCashCalculate(IWeightAndSizeServices weightAndSizeServices )
        {

            _weightAndSizeList = weightAndSizeServices.GetAll();
        }

        public RsShipmentDto CalculateShipp(string SenderAddress,string ReceiverAddress, int Weight, ShipSize Size)
        {
            var distance = 100;
            var tablokarsiligi = _weightAndSizeList.Find(x => x.WeightMin <= Weight && x.WeightMax >= Weight && x.Size==Size).Price;
            var cash = tablokarsiligi * Weight * distance;
            var result = new RsShipmentDto
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
