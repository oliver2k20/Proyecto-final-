using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    /// <summary>
    /// Repositorio de la  orden aqui se realiza la orden
    /// </summary>
    public class OrderRepository:IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        //Inyeccion de dependencias
        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        //Aqui crea la orden
        public void CreateOrder(Order order)
        {
            try
            {
                order.OrderPlaced = DateTime.Now;
                order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

                _appDbContext.Orders.Add(order);

                var shoppingCartItems = _shoppingCart.ShoppingCartItems;

                foreach (var shoppingCartItem in shoppingCartItems)
                {
                    //Crea un nuevo objeto de tipo Orden Detalles
                    var orderDetail = new OrderDetail()
                    {
                        Amount = shoppingCartItem.Amount,
                        HotelId = shoppingCartItem.Hotel.Id,
                        Hotel = shoppingCartItem.Hotel,
                        OrderId = order.OrderId,
                        Price = shoppingCartItem.Hotel.Price
                    };
                    //Guarda al DbContext
                    _appDbContext.OrderDetails.Add(orderDetail);
                }

                _appDbContext.SaveChanges();
            }
            //Captura la excepcion
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        //Aqui busca los detalles de la orden por Id
        public List<OrderDetail> getDetailsByOrderId(int id)
        {
            return _appDbContext.OrderDetails.Where(od => od.OrderId == id).ToList();
        }
        //Busca la  orden por el Id
        public Order getOrderById(int id)
        {
            return _appDbContext.Orders.FirstOrDefault(o => o.OrderId == id);
        }
        
    }
   
}

