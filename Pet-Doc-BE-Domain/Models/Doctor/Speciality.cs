namespace Pet_Doc_BE_Domain.Models.Doctor;

public class Speciality : Entity<int>
{
	internal Speciality(string name)
	{
		Name = name;
	}
	public string Name { get; set; }
}
