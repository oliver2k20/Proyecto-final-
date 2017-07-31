using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    /// <summary>
    /// Esta es la clase que guarda en la db
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //Dbsets de todas las propiedades
        public DbSet<Category> Categories { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get;set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
