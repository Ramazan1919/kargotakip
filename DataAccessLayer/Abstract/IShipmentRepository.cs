using DataEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IShipmentRepository:IRepository<Shipment>
    {
        void getShipWithPackage();
    }
}
