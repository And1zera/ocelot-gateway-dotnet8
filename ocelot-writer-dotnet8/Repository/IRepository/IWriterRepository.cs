using ocelot_writer_dotnet8.Entity;

namespace ocelot_writer_dotnet8.Repository.IRepository
{
    public interface IWriterRepository
    {
        IEnumerable<Writer> GetAll();
        Writer GetById(Guid id);
        void Add(Writer writer);
        void Update(Writer writer);
        void Delete(Guid id);
    }
}