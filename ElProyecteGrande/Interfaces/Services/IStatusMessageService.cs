namespace ElProyecteGrande.Interfaces.Services
{
    public interface IStatusMessageService<T> where T: class
    {
        string AlreadyExists();
        string Deleted(int id);
        string NoneFound();
        string NotFound(int id);
        string NotUnique();
        string GenericError();
    }
}