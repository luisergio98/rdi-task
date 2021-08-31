using Microsoft.EntityFrameworkCore;
using RDITask.Models;
using RDITask.Models.Context;
using RDITask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDITask.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CreditCardContext _context;

        public CustomerService(CreditCardContext context)
        {
            _context = context;
        }

        public bool Create(CustomerModel customer)
        {
            try
            {
                _context.Add(customer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public bool Delete(int id)
        {
            try
            {
                _context.Costumer.Remove(Find(id));
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool Edit(CustomerModel customer)
        {
            try
            {
                _context.Update(customer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public CustomerModel Find(int id)
        {
            try
            {
                return _context.Costumer.FirstOrDefault(m => m.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<CustomerModel> ListAll()
        {
            try
            {
                return _context.Costumer.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
