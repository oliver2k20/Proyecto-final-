using BethanysPieShop.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Controlador de ordenes
/// </summary>
namespace BethanysPieShop.Controllers
{
    public class OrderController : Controller
    {
        private IHostingEnvironment _config;
        private IHotelRepository _hotelRepository;
        private IOrderRepository _orderRepository;
        private ShoppingCart _shoppingCart;
        //Dependency Injection
        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart, IHotelRepository hotelRepository, IHostingEnvironment config)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _hotelRepository = hotelRepository;
            _config = config;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        //Aqui se realiza el checkout cuando se realiza una orden
        [HttpPost]
        public  IActionResult Checkout(Order order)
        {

            

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            if(_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Tu carro esta vacio"); //Si el carro no tiene nada
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                //Limpia el carro
                _shoppingCart.ClearCart();
                //Pasar Id de orden
                return RedirectToAction("CheckoutComplete",new {id = order.OrderId });
            }
            return View(order);
        }
        //Me Dira que mandara un mensaje de que ha realizado correctamente la orden
      public IActionResult CheckoutComplete(int id)

            
        {
            var order = _orderRepository.getOrderById(id);
             SendMessage(order);
            ViewBag.CheckoutCompleteMessage = "Orden realizada correctamente";
            return View();
        }
        /// <summary>
        /// Esta funcion es la encargada de mandar el mensaje en base a una orden solicitada de la habitacion
        /// </summary>
        /// <param name="order"></param>
        public void SendMessage(Order order)
        {
            //esto me tomará los detalles de las ordenes basados en un Id de Orden
            var oDetails = _orderRepository.getDetailsByOrderId(order.OrderId);
            try
            {
                //este es la clase para mandar el mensaje
                var message = new MimeMessage();
                //este es el que envia
                message.From.Add(new MailboxAddress("HerreraCinemas", "Herreracinemas@gmail.com"));
                //El destinatario
                message.To.Add(new MailboxAddress(order.FirstName, order.Email));
                //El sujeto del email
                message.Subject = "¡Ha adquirido sus taquillas correctamente!";
               //Este builder permitirá construir nuestro mensaje
                var builder = new BodyBuilder();
                //Un stringbuilder para construir un string y pasarlo al messageBody
                var sb = new StringBuilder();
                //El stringbuilder tiene este metodo appendLine para añadir líneas  al string y concatenarlo 
                //el $ es para hacer una interpolación de Strings
                sb.AppendLine($"<p>Gracias por su compra, tiene un total de RD$ {order.OrderTotal} a nombre de {order.FirstName} {order.LastName}</p>");

                foreach (var item in oDetails)
                {
                    var hotel = _hotelRepository.GetHotelById(item.HotelId);
                    //aqui conseguimos el path de la imagen
                    var image = builder.LinkedResources.Add(_config.WebRootPath+ hotel.ImageUrl);
                    //Esto consigue el id que generara la imagen
                    image.ContentId = MimeUtils.GenerateMessageId();
                  
                    sb.AppendLine($"<p><strong>Película</strong> {hotel.Name}</p>");
                    sb.AppendLine($"<p><strong>Precio de la taquilla: RD$</strong> {hotel.Price}</p>");
                    sb.AppendLine($"<p><strong>Descripción:</strong> {hotel.LongDescription}</p>");
                    sb.AppendLine($"<p><strong> cantidad:</strong> {item.Amount}</p>");
                    sb.AppendLine(String.Format(@"<img src=""cid:{0}"">", image.ContentId));
                    sb.AppendLine("<hr>");
                }
                //Aqui establecemos el htmlBody como todo el string concatenado
                builder.HtmlBody = sb.ToString();
                //cuerpo del mensaje
                message.Body = builder.ToMessageBody();
                //Esta parte me muestra el cliente para mandar el email correctamente
                using (var client = new SmtpClient())
                {
                    //Conecta al servidor de correos 'local'
                    client.Connect("smtp.gmail.com", 587, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    //Autentica una cuenta, esta cuenta es default
                    client.Authenticate("herreracinemas@gmail.com", "lala030303");
                    //Enviamos el mensaje
                     client.Send(message);
                    Console.WriteLine("The mail has been sent successfully");
                     client.Disconnect(true);
                }
            }
            //En caso que algo inesperado ocurra
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
