using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class users
{
    [Key] public double Id { get; set; }

    public String name { get; set; }

    [Display(Name = "User password")]
    [DataType(DataType.Password)]
    public String password { get; set; }
    
    [DataType(DataType.EmailAddress)] public string email { get; set; }

    [MaxLength(7)]
    public String? gender { get; set; }

    [DataType(DataType.Date)] public DateTime? dateOfBrith { get; set; }
}