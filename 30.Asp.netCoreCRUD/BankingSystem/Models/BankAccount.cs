using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Xml.Linq;

namespace BankingSystem.Models
{
    public class BankAccount
    {
        [Key]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Account holder name is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Account holder name must be between 5 and 50 characters.")]
        [Display(Name = "Holder Name")]
        [Column(TypeName = "VARCHAR(50)")]
        public string AccountHolderName { get; set; }

        [Required(ErrorMessage = "Account Type is Required.")]
        [Display(Name = "Account Number")]
        [StringLength(14, ErrorMessage = "Account Number cannot be longer than 14 digits.")]
        public long AccountNumber { get; set; }

        [Required(ErrorMessage = "Balance is required.")]
        [Range(0, 100000000, ErrorMessage = "Balance must be between 0 and 100,000,000.")]
        [Column(TypeName = "DECIMAL(18,2)")]
        [Display(Name = "Account Balance")]
        public decimal Balance { get; set; }

        [Required(ErrorMessage = "Created date is required.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Account Created Date")]
        [Column(TypeName = "DATETIME")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}
