using SqlModels.ViewModels;

namespace SenGame.Controllers
{
    internal class Dictionary
    {
        private FriendViewModel.Group group;
        private FriendViewModel.Friend friend;

        public Dictionary(FriendViewModel.Group group, FriendViewModel.Friend friend)
        {
            this.group = group;
            this.friend = friend;
        }
    }
}