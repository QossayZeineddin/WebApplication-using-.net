using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class users
{
    [Key] public double Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3)]
    [Display(Name = "User Name")]
    public String name { get; set; }

    [Display(Name = "User password")]
    [DataType(DataType.Password)]
    public String password { get; set; }

    public string phone_num { get; set; }
    [DataType(DataType.EmailAddress)] public string email { get; set; }

    [MaxLength(7)] public String? gender { get; set; }

    [Display(Name = "Date Of Brith")]
    [DataType(DataType.Date)]
    public DateTime? dateOfBrith { get; set; }
    
    //[RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(5)]
}