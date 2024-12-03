using ocelot_writer_dotnet8.Entity;
using ocelot_writer_dotnet8.Repository.IRepository;

namespace ocelot_writer_dotnet8.Repository
{
    public class WriterRepository : IWriterRepository
    {
        private readonly List<Writer> _writers = new()
        {
            new Writer { Id = Guid.NewGuid(), Name = "Anderson" },
            new Writer { Id = Guid.NewGuid(), Name = "José" },
            new Writer { Id = Guid.NewGuid(), Name = "Paulo" }
        };

        public IEnumerable<Writer> GetAll()
        {
            return _writers;
        }

        public Writer GetById(Guid id)
        {
            return _writers.FirstOrDefault(w => w.Id == id);
        }

        public void Add(Writer writer)
        {
            _writers.Add(writer);
        }

        public void Update(Writer writer)
        {
            var existingWriter = GetById(writer.Id);
            if (existingWriter != null)
            {
                existingWriter.Name = writer.Name;
            }
        }

        public void Delete(Guid id)
        {
            var writer = GetById(id);
            if (writer != null)
            {
                _writers.Remove(writer);
            }
        }
    }
}
