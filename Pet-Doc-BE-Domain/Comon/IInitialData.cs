namespace Pet_Doc_BE_Domain.Comon;

public interface IInitialData<TData>
{
    public TData GetData();
}
