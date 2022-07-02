using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interface;
using SqlModels.Models;
using SqlModels.Repository.Interface;

namespace Services
{
    public class CommunityService : BaseService<Forum>,ICommunityService
    {
        public CommunityService(IRepository<Forum> repository)
		: base(repository)
        {

        }

        public void TotalForum()
        {
            throw new NotImplementedException();
        }
    }
}
