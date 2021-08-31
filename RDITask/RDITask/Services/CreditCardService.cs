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
    public class CreditCardService : ICreditCardService
    {
        private readonly CreditCardContext _context;

        public CreditCardService(CreditCardContext context)
        {
            _context = context;
        }

        public object Create(CreditCardModel card)
        {
            try
            {
                if(card.CardNumber < 1000 || card.CVV < 100)
                {
                    return null;
                }

                card.Customer = null;
                _context.CreditCard.Add(card);
                _context.SaveChanges();

                var token = new TokenModel
                {
                    Id = 0,
                    CreditCardId = card.Id,
                    CreditCard = null,
                    TokenNumber = TokenHelper.GenerateToken(card),
                    RegistrationDate = DateTime.Now
                };
                _context.Token.Add(token);
                _context.SaveChanges();

                return new { RegistrationDate = token.RegistrationDate, Token = token.TokenNumber, token.CreditCardId };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                TokenModel token = _context.Token.OrderByDescending(m => m.Id == id).FirstOrDefault();
                while (token != null)
                {
                    _context.Token.Remove(token);
                    _context.SaveChanges();
                    token = _context.Token.OrderByDescending(m => m.Id == id).FirstOrDefault();
                }
                

                _context.CreditCard.Remove(Find(id));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(CreditCardModel card)
        {
            try
            {
                if (card.CardNumber < 1000 || card.CVV < 100)
                {
                    return false;
                }

                card.Customer = null;
                _context.Update(card);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CreditCardModel Find(int id)
        {
            try
            {
                return _context.CreditCard.Include(x => x.Customer).FirstOrDefault(m => m.Id == id);
            }
            catch (Exception)
            {
                return new CreditCardModel();
            }
        }

        public List<CreditCardModel> ListAll()
        {
            try
            {
                return _context.CreditCard.Include(x => x.Customer).ToList();
            }
            catch (Exception)
            {
                return new List<CreditCardModel>();
            }
        }
    }
}
