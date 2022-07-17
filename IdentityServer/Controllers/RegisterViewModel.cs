using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Controllers;

public class RegisterViewModel
{
    public string ReturnUrl { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    [DataType("Password")]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    [DataType("Password")]
    public string ConfirmPassword { get; set; }
}