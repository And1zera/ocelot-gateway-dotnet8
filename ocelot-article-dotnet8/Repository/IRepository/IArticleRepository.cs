using ocelot_article_dotnet8.Entity;

namespace ocelot_article_dotnet8.Repository.IRepository
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll();
        Article? GetById(Guid id);
        void Add(Article article);
        void Update(Article article);
        void Delete(Guid id);
    }
}
