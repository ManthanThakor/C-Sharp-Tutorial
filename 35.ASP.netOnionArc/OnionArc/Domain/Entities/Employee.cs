using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Date of Joining is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfJoin { get; set; }
        public string PhotoFilename { get; set; }
    }
}
