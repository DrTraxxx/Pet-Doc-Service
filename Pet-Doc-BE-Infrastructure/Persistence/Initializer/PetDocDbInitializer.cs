namespace Pet_Doc_BE_Infrastructure.Persistence.Initializer;

using Microsoft.EntityFrameworkCore;
using Pet_Doc_BE_Domain.Comon;

internal class PetDocDbInitializer : IInitializer
{
    private PetDocDbContext _ctx;
    private IInitialData<Doctor[]> _data;

    public PetDocDbInitializer(PetDocDbContext ctx , IInitialData<Doctor[]> data)
    {
        _ctx = ctx;
        _data = data;
    }
    public void Initialize()
    {
        _ctx.Database.Migrate(); 

        if(_ctx.Doctors.Any()) return;

        _ctx.Doctors.AddRange(_data.GetData());

        _ctx.SaveChanges();
    }
}
