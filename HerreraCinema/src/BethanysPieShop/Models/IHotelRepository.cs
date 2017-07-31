using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Repositorio de los Hoteles
/// </summary>
namespace BethanysPieShop.Models
{
    //Repositorio de Hoteles
    public interface IHotelRepository
    {
        //Busca los hoteles
        IEnumerable<Hotel> Hotels {get;}
        //Busca el hotel por el Id
        Hotel GetHotelById(int pieId);
    }
}
