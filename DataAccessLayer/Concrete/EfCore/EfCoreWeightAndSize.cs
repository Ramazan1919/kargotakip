using DataAccessLayer.Abstract;
using DataEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.EfCore
{
    public class EfCoreWeightAndSize : EfBaseRepository<WeightAndSize, StdContext>, IWeightAndSizeRepository
    {
        public EfCoreWeightAndSize(StdContext context) : base(context)
        {
        }
    }
}
