namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProductRepository
    {
        Product[] GetAllProducts();
        //Ajout méthode getProductById
        Product GetProductById(int id); 
        void UpdateProductStocks(int productId, int quantityToRemove);
    }
}
