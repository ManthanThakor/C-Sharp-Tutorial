using Domain.CommonEntity;
using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Item : BaseEntity
{
    [Required]
    [MaxLength(20)]
    public string ItemCode { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string ItemName { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? ItemDescription { get; set; }

    [Required]
    [Range(0.01, 999999.99)]
    public decimal ItemPrice { get; set; }

    [Required]
    [ForeignKey("Category")]
    public Guid CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual CustomerItem? CustomerItem { get; set; }

    public virtual SupplierItem? SupplierItem { get; set; }

    public virtual List<ItemImage> ItemImages { get; set; } = new List<ItemImage>();
}
