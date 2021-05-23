using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataEntity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class ShippmentManager :BaseManager<Shipment>, IShippmentServices
    {
        public ShippmentManager(IShipmentRepository repository) : base(repository)
        {

        }

       
        public void getShipWithPackage(int id)
        {
           
        }

        public void IsValid()
        {
            
        }
    }
}
