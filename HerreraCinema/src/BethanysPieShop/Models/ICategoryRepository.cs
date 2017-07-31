using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    //Interfaz para las categorias
    public interface ICategoryRepository
    {
            IEnumerable<Category> Categories { get; }
    }

    
}
