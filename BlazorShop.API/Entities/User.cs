using System.ComponentModel.DataAnnotations;

namespace BlazorShop.API.Entities
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } =string.Empty;

        public Cart? Cart { get; set; }
    }
}
