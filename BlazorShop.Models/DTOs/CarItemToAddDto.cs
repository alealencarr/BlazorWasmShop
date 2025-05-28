using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Models.DTOs
{
    public class CarItemToAddDto
    {
        [Required]
        public int CartId   { get; set; }

        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
