using Microsoft.EntityFrameworkCore;
using RDITask.Helpers;
using RDITask.Models;
using RDITask.Models.Context;
using RDITask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDITask.Services
{
    public class TokenService : ITokenService
    {
        private readonly CreditCardContext _context;

        public TokenService(CreditCardContext context)
        {
            _context = context;
        }

        public bool Create(TokenModel token)
        {
            try
            {
                _context.Add(token);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _context.Token.Remove(Find(id));
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(TokenModel token)
        {
            try
            {
                _context.Update(token);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TokenModel Find(int id)
        {
            try
            {
                return _context.Token.Include(x => x.CreditCard).OrderByDescending(m => m.CreditCardId == id).FirstOrDefault();
            }
            catch (Exception)
            {
                return new TokenModel();
            }
        }

        public List<TokenModel> ListAll()
        {
            try
            {
                return _context.Token.Include(x => x.CreditCard).ToList();
            }
            catch (Exception)
            {
                return new List<TokenModel>();
            }
        }

        public bool Validate(int customerId, int cardId, int tokenNumber, int cvv)
        {
            try
            {
                var token = Find(cardId);

                if (token == null || (DateTime.Now - token.RegistrationDate).TotalMinutes > 30)
                    return false;

                var card = _context.CreditCard.FirstOrDefault(m => m.Id == cardId);

                if (card == null || card.CostumerId != customerId || token.TokenNumber != tokenNumber)
                    return false;

                if (tokenNumber != TokenHelper.GenerateToken(new CreditCardModel { CardNumber = card.CardNumber, CVV = cvv }))
                    return false;

                Console.WriteLine(card.CardNumber);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
