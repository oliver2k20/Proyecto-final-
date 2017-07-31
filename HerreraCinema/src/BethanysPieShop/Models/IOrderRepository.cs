using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    /// <summary>
    /// La interfaz para realizar operaciones de BD en el repositorio de Orden
    /// </summary>
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        Order getOrderById(int id);
         List<OrderDetail> getDetailsByOrderId(int id);
    }
}
