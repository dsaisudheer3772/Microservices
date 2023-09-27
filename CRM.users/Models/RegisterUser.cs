using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Users.Models;

[Index(nameof(RegisterUser.email), nameof(RegisterUser.phonenumber), IsUnique = true)]
public class RegisterUser
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long regesterid { get; set; }
    public string? email { get; set; }
    public string? phonenumber { get; set; }
    [Required]
    public string? password { get; set; }
    public string? lattitude { get; set; }
    public string? longtitude { get; set; }
}
