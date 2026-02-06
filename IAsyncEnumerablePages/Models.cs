namespace IAsyncEnumerablePages.Models;

public enum Gender
{
    Male,
    Female
}

public class Person
{
    public Gender Gender { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}

public class Vehicle
{
    public string Vin { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Fuel { get; set; } = string.Empty;
}
