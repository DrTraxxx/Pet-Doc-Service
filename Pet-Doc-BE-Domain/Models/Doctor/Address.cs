namespace Pet_Doc_BE_Domain.Models.Doctor;

public class Address
{
    public string City { get; set; } = default!;
    public string Street { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public Coordinates mapPin { get; set; } = default!; 
}

public record Coordinates(string Longitude, string Latitude);

