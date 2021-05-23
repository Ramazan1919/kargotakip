using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class ShipmentPackageManager : BaseManager<ShippmentPackage>, IShippmentPackageServices
    {
        public ShipmentPackageManager(IShippmentPackageRepository repository) : base(repository)
        {
        }
    }
}


