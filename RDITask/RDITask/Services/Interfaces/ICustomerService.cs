using RDITask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDITask.Services.Interfaces
{
    public interface ICustomerService
    {
        public List<CustomerModel> ListAll();
        public CustomerModel Find(int id);
        public bool Create(CustomerModel customer);
        public bool Edit(CustomerModel customer);
        public bool Delete(int id);

    }
}
