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

        [Required(ErrorMessage = "Transaction account number is required.")]
        [StringLength(14, ErrorMessage = "Transaction account number must not exceed 14 characters.")]
        [Display(Name = "Transaction Account Number")]
        public string TransactionAccountNumber { get; set; }

        [Required(ErrorMessage = "Account holder name is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Account holder name must be between 5 and 50 characters.")]
        [Display(Name = "Account Holder Name")]
        public string AccountHolderName { get; set; }

        [Required(ErrorMessage = "Beneficiary name is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Beneficiary name must be between 5 and 50 characters.")]
        [Display(Name = "Transaction Beneficiary Name")]
        public string TransactionBeneficiaryName { get; set; }

        [Required(ErrorMessage = "Bank name is required.")]
        [StringLength(20, ErrorMessage = "Bank name must not exceed 20 characters.")]
        [Display(Name = "Transaction Bank Name")]
        public string TransactionBankName { get; set; }

        [Required(ErrorMessage = "SWIFT code is required.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "SWIFT code must be exactly 11 characters.")]
        [Display(Name = "Transaction SWIFT Code")]
        public string TransactionSwiftCode { get; set; }

        [Required(ErrorMessage = "Transaction amount is required.")]
        [Range(0.01, 100000000, ErrorMessage = "Transaction amount must be greater than 0.")]
        [Column(TypeName = "DECIMAL(18,2)")]
        [Display(Name = "Transaction Amount")]
        public decimal TransactionAmount { get; set; }

        [Required(ErrorMessage = "Transaction date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Transaction Date")]
        [Column(TypeName = "DATE")]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

    }
}
