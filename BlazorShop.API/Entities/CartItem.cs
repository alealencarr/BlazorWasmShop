namespace BlazorShop.API.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CarrinhoId { get; set; }
        public int ProdutoId { get; set; }
        public int Amount { get; set; }

        public Cart? Cart { get; set; }
        public Product? Product { get; set; }
    }
}
