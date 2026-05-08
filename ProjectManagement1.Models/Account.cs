using System.ComponentModel.DataAnnotations;

namespace ProjectManagement1.Models;

public class Account
{
    public string Uid         { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Password    { get; set; } = string.Empty;
}
