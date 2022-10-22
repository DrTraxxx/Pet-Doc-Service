namespace Pet_Doc_BE_Domain.Comon;

internal class DocSeedData : IInitialData<Doctor[]>
{

	public Doctor[] GetData()
	{
		return new Doctor[]
		{
			new( "Pettify",
				 new Speciality("Dermatology"),
				 new Address{City="Sofa",Street="Елин Пелин",PhoneNumber="0888456474", mapPin = new("42.68121840094344","23.332956491965177")},
				 new HashSet<Appointment>(),
				 new HashSet<Certification>(){ new() {Name = "DermaQuality", IssueDate = DateTime.Now.AddDays(+3)} },
				 new Schedule("Monday",5,"11:30",5)
				 ) ,

			new( "PetLife",
				 new Speciality("Internal medicine"),
				 new Address{ City ="Sofa",Street="Солунска",PhoneNumber="0878345671",mapPin =new ("42.69332242051469","23.316472621635025")},
				 new HashSet<Appointment>{new (DateTime.Now.AddDays(+3), "11:30")},
                 new HashSet<Certification>(),
                 new Schedule("Monday",5,"11:30",5)
                 )
        };
	}
}
