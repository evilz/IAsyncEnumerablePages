using Bogus;
using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bogus.Person;

namespace IAsyncEnumerablePages.Models;

public enum Gender
{
    Male,
    Female
}

public class Person
{
    public Gender Gender { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Avatar { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }

}

public class Vehicle
{
    public string Vin { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public string Type { get; set; }
    public string Fuel { get; set; }
}