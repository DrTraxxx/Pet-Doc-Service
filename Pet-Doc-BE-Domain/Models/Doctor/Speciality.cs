namespace Pet_Doc_BE_Domain.Models.Doctor;

using Pet_Doc_BE_Domain.Comon.Validations;
using Pet_Doc_BE_Domain.Exceptions;
using Pet_Doc_BE_Domain.Extensions;

public class Speciality : Entity<int>
{
	internal Speciality(string name)
	{
		ValidateModel(name);
        Name = name;
	}
	public string Name { get; set; }

	private void ValidateModel(string name)
	{
		if (name.Validate(Validate.ForEmptyString, Validate.ForStringLength))
			throw new InvalidSpecialityException($"{name} is not valid!");
	}
}
