using RDITask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDITask.Services.Interfaces
{
    public interface ITokenService
    {
        public List<TokenModel> ListAll();
        public TokenModel Find(int id);
        public bool Create(TokenModel token);
        public bool Edit(TokenModel token);
        public bool Delete(int id);
        public bool Validate(int customerId, int cardId, int tokenNumber, int cvv);
    }
}
