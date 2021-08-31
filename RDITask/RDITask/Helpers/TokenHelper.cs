using RDITask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDITask.Helpers
{
    public static class TokenHelper
    {
        public static long GenerateToken(CreditCardModel card)
        {
            List<int> lastFourNumbers = Int32.Parse(card.CardNumber.ToString().Substring(card.CardNumber.ToString().Length - 4, 4)).ToString().Select(o => Convert.ToInt32(o) - 48).ToList();
            for (int i = 0; i < card.CVV; i++)
            {
                int number = lastFourNumbers[lastFourNumbers.Count - 1];
                lastFourNumbers.RemoveAt(lastFourNumbers.Count - 1);
                lastFourNumbers.Insert(0, number);
            }

            long token = 0;
            foreach (int entry in lastFourNumbers)
            {
                token = 10 * token + entry;
            }

            return token;
        }
    }
}
