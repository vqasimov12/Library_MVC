namespace Library.Domain.Abstracts;

public interface IProductPrice:IEntity
{
    public decimal Price { get; set; }
}
