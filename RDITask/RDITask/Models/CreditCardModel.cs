using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RDITask.Models
{
    public class CreditCardModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CostumerId { get; set; }
        [ForeignKey("CostumerId")]
        public virtual CustomerModel Customer{ get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }
    }
}
