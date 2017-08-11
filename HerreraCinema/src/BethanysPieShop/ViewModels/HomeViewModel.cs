using BethanysPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.ViewModels
{
    //Un modelo para mostrar todos los articulos disponibles
    public class HomeViewModel
    {
        public IEnumerable<Hotel> Hotels { get; set; }
    }
}
