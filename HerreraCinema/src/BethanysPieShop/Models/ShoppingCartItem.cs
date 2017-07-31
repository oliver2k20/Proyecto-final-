using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    //Modelo para el item del carrito de compras
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Hotel Hotel { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
