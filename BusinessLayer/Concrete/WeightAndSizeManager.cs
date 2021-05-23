using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class WeightAndSizeManager:BaseManager<WeightAndSize>,IWeightAndSizeServices
    {
        public WeightAndSizeManager(IWeightAndSizeRepository repository) : base(repository)
        {
        }
    }
}
