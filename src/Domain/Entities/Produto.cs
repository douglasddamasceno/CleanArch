namespace Domain.Entities;

public class Produto
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }

    public Produto(string nome, decimal preco)
    {

        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome é obrigatório.");
        if (preco <= 0)
            throw new ArgumentException("Preço deve ser maior que '0'.");

        Id = Guid.NewGuid();
        Nome = nome;
        Preco = preco;
    }
}