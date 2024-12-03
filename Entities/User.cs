using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace  Entities;

public partial class User
{
    public int UserId { get; set; }

    [EmailAddress, Required]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "password required")]
    public string Password { get; set; } = null!;
    [StringLength(15, ErrorMessage = "FirstName can be between 2 till 15", MinimumLength = 2)]
    public string? FirstName { get; set; }
    [StringLength(15, ErrorMessage = "LastName can be between 2 till 15", MinimumLength = 2)]
    public string? LastName { get; set; }
}
