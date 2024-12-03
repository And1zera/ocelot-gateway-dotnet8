namespace ocelot_writer_dotnet8.Entity
{
    public record Writer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
