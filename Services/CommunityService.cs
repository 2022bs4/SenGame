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
        private readonly IRepository<MyForum> _myForum;
        private readonly IRepository<UserModel> _User;
        public CommunityService(IRepository<Forum> repository, IRepository<MyForum> myForum, IRepository<UserModel> User)
		: base(repository)
        {
            this._myForum = myForum;
            this._User = User;
        }
        
        public IEnumerable<Forum> GetUserForum(string _name)
        {
            var id = _User.GetAll().First(x => x.UserName == _name).UserId;
            var ids = _myForum.FindBy(x => x.UserId == id).Select(x=>x.ForumId);
            List<Forum> data=new();
            foreach (var item in ids) { 
                data.Add(_repository.GetById(item)) ;
            }
            return data.AsEnumerable();
        }

    }
}
