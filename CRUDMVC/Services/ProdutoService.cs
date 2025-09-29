using CrudSimples.Models;

namespace CrudSimples.Services
{
    public class ProdutoService
    {
        private static List<Produto> _produtos = new List<Produto>();
        private static int _nextId = 1;

        public ProdutoService()
        {
            if (!_produtos.Any())
            {
                _produtos.Add(new Produto { Id = _nextId++, Nome = "Notebook", Preco = 2500.00m, Descricao = "Notebook Dell i7" });
                _produtos.Add(new Produto { Id = _nextId++, Nome = "Mouse", Preco = 50.00m, Descricao = "Mouse sem fio" });
                _produtos.Add(new Produto { Id = _nextId++, Nome = "Teclado", Preco = 120.00m, Descricao = "Teclado mecânico" });
            }
        }

        public List<Produto> GetAll()
        {
            return _produtos.OrderBy(p => p.Nome).ToList();
        }

        public Produto GetById(int id)
        {
            return _produtos.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Produto produto)
        {
            produto.Id = _nextId++;
            produto.DataCadastro = DateTime.Now;
            _produtos.Add(produto);
        }

        public void Update(Produto produto)
        {
            var existing = GetById(produto.Id);
            if (existing != null)
            {
                existing.Nome = produto.Nome;
                existing.Preco = produto.Preco;
                existing.Descricao = produto.Descricao;
            }
        }

        public void Delete(int id)
        {
            var produto = GetById(id);
            if (produto != null)
            {
                _produtos.Remove(produto);
            }
        }
    }
}