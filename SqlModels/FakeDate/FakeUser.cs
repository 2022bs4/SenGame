//using SqlModels.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SqlModels.FakeDate
//{
//    public class FakeUser
//    {
//        List<AspNetUser> user = new List<AspNetUser>()
//        {
//            new AspNetUser{UserId=1,UserName="張學友",Account = "test123",PasswordHash="A!a123456",UserPicture="https://memeprod.ap-south-1.linodeobjects.com/user-gif-post/1653456571139.gif"},
//            new AspNetUser{UserId=2,UserName="金城武",Account = "test321",PasswordHash="A!a123456",UserPicture="https://memeprod.ap-south-1.linodeobjects.com/user-gif-post/1649456466797.gif"},
//            new AspNetUser{UserId=3,UserName="郭富城",Account = "test456",PasswordHash="A!a123456",UserPicture="https://memeprod.ap-south-1.linodeobjects.com/user-gif-thumbnail/7893d953a0c3fed57d6f8eaea1c064cf.gif"},
//            new AspNetUser{UserId=4,UserName="劉德華",Account = "test654",PasswordHash="A!a123456",UserPicture="https://j.gifs.com/5QX3NY.gif"},

//        };
//        List<Usergroup> group = new List<Usergroup>()
//        {
//            new Usergroup{UserGroupId=1,FriendGroupId=1,UserId=2},
//            new Usergroup{UserGroupId=2,FriendGroupId=1,UserId=3},
//            new Usergroup{UserGroupId=3,FriendGroupId=1,UserId=4},
//        };
//        List<FriendGroup> freindgroup = new List<FriendGroup>()
//        {
//            new FriendGroup{FriendGoupId=1,GroupName="高中同學"},
//        };
//        List<Chat> chat = new List<Chat>() { };
//    }
//}


//List<UserBackground> userBackgrounds = new List<UserBackground>()
//{
//    new UserBackground{ UserBackgroundId=1, BackgroundColor="linear-gradient(90deg, rgb(243, 243, 249), rgb(243, 243, 249))" }, //Original setting
//    new UserBackground{ UserBackgroundId=2, BackgroundColor="linear-gradient(to top, #fbc2eb 0%, #a6c1ee 100%)" }, //Rainy Ashville
//    new UserBackground{ UserBackgroundId=3, BackgroundColor="linear-gradient(120deg, #84fab0 0%, #8fd3f4 100%)" }, //Tempt Azure</
//    new UserBackground{ UserBackgroundId=4, BackgroundColor="linear-gradient(120deg, #e0c3fc 0%, #8ec5fc 100%)" }, //Deep Blue
//    new UserBackground{ UserBackgroundId=5, BackgroundColor="linear-gradient(to right, #fa709a 0%, #fee140 100%)" }, //True Sunset
//    new UserBackground{ UserBackgroundId=6, BackgroundColor="linear-gradient(to top, #a8edea 0%, #fed6e3 100%)" }, 
//    new UserBackground{ UserBackgroundId=7, BackgroundColor="linear-gradient(to top, #fddb92 0%, #d1fdff 100%)" }, 
//    new UserBackground{ UserBackgroundId=8, BackgroundColor="linear-gradient(to right, #eea2a2 0%, #bbc1bf 19%, #57c6e1 42%, #b49fda 79%, #7ac5d8 100%)" },
//};


//List<UserPrivacy> userprivacie = new List<UserPrivacy>()
//{
//    new UserPrivacy{UserPrivacyId=1, PrivacyState = "公開"},
//    new UserPrivacy{UserPrivacyId=2, PrivacyState = "只限好友"},
//    new UserPrivacy{UserPrivacyId=3, PrivacyState = "私人"}
//};