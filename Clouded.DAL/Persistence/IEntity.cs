namespace CloudEd.DAL.Persistence
{
    public interface IEntity<TIdentifier>
    {
        TIdentifier Id { get; }
    }
}