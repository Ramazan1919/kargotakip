using DataAccessLayer.Abstract;
using DataEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.EfCore
{
    public class EfCoreShippmentPackage : EfBaseRepository<ShippmentPackage, StdContext>, IShippmentPackageRepository
    {
        public EfCoreShippmentPackage(StdContext context) : base(context)
        {
        }
    }
}
