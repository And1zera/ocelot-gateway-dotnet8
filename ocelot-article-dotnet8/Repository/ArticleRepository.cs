using ocelot_article_dotnet8.Entity;
using ocelot_article_dotnet8.Repository.IRepository;

namespace ocelot_article_dotnet8.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly List<Article> _articles = new()
        {
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Introdução ao .NET 8",
                Content = "Este artigo fornece uma visão geral das novas funcionalidades do .NET 8.",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Novidades no C# 12",
                Content = "Este artigo explora as novas funcionalidades introduzidas no C# 12.",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Melhores práticas com Ocelot",
                Content = "Este artigo discute as melhores práticas para usar o Ocelot em aplicações .NET.",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        public IEnumerable<Article> GetAll()
        {
            return _articles;
        }

        public Article? GetById(Guid id)
        {
            return _articles.FirstOrDefault(a => a.Id == id);
        }

        public void Add(Article article)
        {
            article.Id = Guid.NewGuid();
            article.CreatedAt = DateTime.UtcNow;
            article.UpdatedAt = DateTime.UtcNow;
            _articles.Add(article);
        }

        public void Update(Article article)
        {
            var existingArticle = GetById(article.Id);
            if (existingArticle != null)
            {
                existingArticle.Title = article.Title;
                existingArticle.Content = article.Content;
                existingArticle.UpdatedAt = DateTime.UtcNow;
            }
        }

        public void Delete(Guid id)
        {
            var article = GetById(id);
            if (article != null)
            {
                _articles.Remove(article);
            }
        }
    }
}
