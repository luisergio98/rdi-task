using RDITask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDITask.Services.Interfaces
{
    public interface ICreditCardService
    {
        public List<CreditCardModel> ListAll();
        public CreditCardModel Find(int id);
        public object Create(CreditCardModel card);
        public bool Edit(CreditCardModel card);
        public bool Delete(int id);
    }
}
