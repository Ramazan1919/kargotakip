using DataAccessLayer.Abstract;
using DataEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.EfCore
{
    public class EfCoreShippment : EfBaseRepository<Shipment, StdContext>, IShipmentRepository
    {
        public EfCoreShippment(StdContext context) : base(context)
        {
        }

        public void getShipWithPackage()
        {
            throw new NotImplementedException();
        }
    }
}
