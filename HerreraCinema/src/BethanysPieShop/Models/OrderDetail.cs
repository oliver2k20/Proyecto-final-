using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    /// <summary>
    /// Modelo para detalles de la orden
    /// </summary>
    public class OrderDetail
    {
        //Detalles de la Orden
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int HotelId{ get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual Order Order { get; set; }
    }
}
