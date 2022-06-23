using Microsoft.AspNetCore.Identity;

namespace SenGame.Areas.IdentityModels
{
    public class UserModel:IdentityUser
    {
        [PersonalData]
        public string Account { get; set; }

    }
}
