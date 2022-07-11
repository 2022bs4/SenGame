using SqlModels.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IUserService : IBaseService
    {
        public List<UserDTO> MyGameList(string UserId);
    }
}
