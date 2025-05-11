using System.ComponentModel.DataAnnotations;

namespace UserManagement.Core.Entities;

public partial class User
{
    [MaxLength(50)]
    public string Username { get; set; } = null!;

    public byte[] Password { get; set; } = null!;

    public byte[] Salt { get; set; } = null!;

    [MaxLength(50)]
    public string Role { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
