namespace ElixrMarket.Web.Models
{
    /// <summary>
    /// A class defining a product on the elixr marketplace.
    /// </summary>
    public class UserProduct
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ElixrUser User { get; set; }   
        public int ProductId { get; set; }
        public Product Product { get; set; }   
    }
}