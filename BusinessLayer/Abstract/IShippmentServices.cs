using DataEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
   public  interface IShippmentServices :IBaseService<Shipment>
    {
        void IsValid();
        void getShipWithPackage(int id);
    }
}
