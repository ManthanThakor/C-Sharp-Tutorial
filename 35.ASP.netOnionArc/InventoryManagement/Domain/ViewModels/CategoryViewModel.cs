using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
    }

    public class CategoryInsertModel
    {
        [Required(ErrorMessage = "Enter Category Name.")]
        public string CategoryName { get; set; }
    }

    public class CategoryUpdateModel : CategoryInsertModel
    {
        [Required(ErrorMessage = "Id is compulsory for Update.")]
        public Guid Id { get; set; }
    }
}