using Services.Interface;
using SqlModels.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : BaseService,IUserService
    {
        public UserService(IRepository repository) : base(repository)
        {

        }
    }
}
