﻿namespace Core.Models;

public class RegisterModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
