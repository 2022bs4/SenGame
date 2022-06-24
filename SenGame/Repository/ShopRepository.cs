using SenGame.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SenGame.Repository
{ 
    public class ShopRepository
    {
        private readonly SenGameContext _context;

        public ShopRepository(List<Game> game)
        {
            _context = new SenGameContext();
        }
        //public async Task<List<Game>> GetProductMainInformation()
        //{ 
            
        //}
    }
}
