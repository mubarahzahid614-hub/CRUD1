using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD1.Models;

public class Vehicle
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Make is required")]
    [StringLength(50)]
    public string Make { get; set; } = string.Empty;

    [Required(ErrorMessage = "Model is required")]
    [StringLength(50)]
    public string Model { get; set; } = string.Empty;

    [Range(1980, 2030, ErrorMessage = "Enter a valid year")]
    public int Year { get; set; } = DateTime.Now.Year;

    [Range(0, 1000000, ErrorMessage = "Enter valid mileage")]
    public int Mileage { get; set; }

    [StringLength(30)]
    public string? Color { get; set; }

    [Required]
    public string Transmission { get; set; } = "Automatic";

    [Required]
    public string FuelType { get; set; } = "Petrol";

    [StringLength(10)]
    public string? AuctionGrade { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(1, 999999999, ErrorMessage = "Enter a valid price")]
    public decimal PriceJPY { get; set; }

    [Required]
    public string Status { get; set; } = "Available";

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}