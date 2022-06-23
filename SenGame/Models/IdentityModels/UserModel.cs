using Microsoft.AspNetCore.Identity;

namespace SenGame.Models.IdentityModels
{
    public class UserModel:IdentityUser
    {
        public string Account { get; set; }
    }
}
