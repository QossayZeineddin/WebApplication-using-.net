using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class users
{
    [Key] public double Id { get; set; }

    public String name { get; set; }

    [DataType(DataType.Password)] public String password { get; set; }

    [DataType(DataType.EmailAddress)] public string email { get; set; }

    public String? gender { get; set; }

    [DataType(DataType.Date)] public DateTime? dateOfBrith { get; set; }
}