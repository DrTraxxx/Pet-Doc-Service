namespace Pet_Doc_BE_Domain.Models.Doctor;

using Pet_Doc_BE_Domain.Exceptions;
using Pet_Doc_BE_Domain.Extensions;

public class Speciality : Entity<int>
{
	internal Speciality(string name)
	{
		Guard.AgainstModelIncorrectness<InvalidSpecialityException>
			(name.Validate(ForEmptyString, ForStringLength));

        Name = name;
	}
	public string Name { get; set; }

}
