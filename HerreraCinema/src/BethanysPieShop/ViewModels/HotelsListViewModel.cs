using BethanysPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.ViewModels
{
    /// <summary>
    /// modelo de vista para mostrar las taquillas
    /// </summary>
    public class HotelsListViewModel
    {
        public IEnumerable<Hotel> Hotels { get; set; }
        public string CurrentCategory { get; set; }
    }
}
