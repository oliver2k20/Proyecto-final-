using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BethanysPieShop.Models
{
    /// <summary>
    /// Clase que shoppingCart
    /// </summary>
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;
        private ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        /// <summary>
        /// Este metodo consigue el carrito y le asigna un nuevo ID
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }
        /// <summary>
        /// Este metodo añade al carro
        /// </summary>
        /// <param name="hotel"></param>
        /// <param name="amount"></param>
        public void AddToCart(Hotel hotel, int amount)
        {
            var shoppingCartItem =
                    _appDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Hotel.Id == hotel.Id && s.ShoppingCartId == ShoppingCartId);
            //Revisa si el item es nulo
            if (shoppingCartItem == null)
            {

                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Hotel = hotel,
                    Amount = 1
                };

                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _appDbContext.SaveChanges();
        }
        //Remueve del carrito
        public int RemoveFromCart(Hotel hotel)
        {
            var shoppingCartItem =
                    _appDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Hotel.Id == hotel.Id && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }
        /// <summary>
        /// Consigue todos los itemes del carro
        /// </summary>
        /// <returns></returns>
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Hotel)
                           .ToList());
        }


        /// <summary>
        /// Limpia el carrito despues del checkout
        /// </summary>
        public void ClearCart()
        {
            var cartItems = _appDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }


        

/// <summary>
/// Consigue el total del carrito de la reservacion
/// </summary>
/// <returns></returns>
        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Hotel.Price * c.Amount).Sum();
            return total;
        }
    }
}