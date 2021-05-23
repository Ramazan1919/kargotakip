using DataEntity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataEntity
{
    public class ShippmentPackage:IEntity
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Size { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverAddress { get; set; }

        public double TotalDistance { get; set; }
        public double RemainigDistance { get; set; }

    }
}
