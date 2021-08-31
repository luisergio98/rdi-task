using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RDITask.Models
{
    public class TokenModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long TokenNumber { get; set; }
        public int CreditCardId { get; set; }
        [ForeignKey("CreditCardId")]
        public virtual CreditCardModel CreditCard { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
