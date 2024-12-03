using Microsoft.AspNetCore.Mvc;
using ocelot_writer_dotnet8.Entity;
using ocelot_writer_dotnet8.Repository.IRepository;

namespace ocelot_writer_dotnet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController(IWriterRepository writerRepository) : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            var writers = writerRepository.GetAll();
            return Ok(writers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var writer = writerRepository.GetById(id);
            if (writer == null)
            {
                return NotFound();
            }
            return Ok(writer);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Writer writer)
        {
            if (writer == null)
            {
                return BadRequest();
            }
            writerRepository.Add(writer);
            return CreatedAtAction(nameof(GetById), new { id = writer.Id }, writer);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Writer writer)
        {
            if (writer == null || writer.Id != id)
            {
                return BadRequest();
            }

            var existingWriter = writerRepository.GetById(id);
            if (existingWriter == null)
            {
                return NotFound();
            }

            writerRepository.Update(writer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var writer = writerRepository.GetById(id);
            if (writer == null)
            {
                return NotFound();
            }

            writerRepository.Delete(id);
            return NoContent();
        }
    }
}
