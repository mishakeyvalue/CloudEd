namespace Clouded.DAL.Persistence
{
    public interface IEntity<TIdentifier>
    {
        TIdentifier Id { get; }
    }
}