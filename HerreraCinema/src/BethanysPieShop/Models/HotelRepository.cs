using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    /// <summary>
    /// Repositorio de los pies
    /// </summary>
    public class HotelRepository : IHotelRepository
    {
        private AppDbContext _appDbContext;

        public HotelRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Hotel> Hotels
        {
            get
            {
                return _appDbContext.Hotels.Include(c => c.Category);
            }
        } 

        public Hotel GetHotelById(int Id)
        {
            return _appDbContext.Hotels.FirstOrDefault(p => p.Id == Id);
        }

    }
}
