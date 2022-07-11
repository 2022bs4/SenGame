using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SqlModels.ViewModels.UserViewModels
{
    
    public class PrivacieViewModel
    {
        [Required]
        public string Privacie { get; set; }
        public List<SelectListItem> Privacies { get; } = new List<SelectListItem>
        {
            new SelectListItem{Text = "公開", Value="public"},
            new SelectListItem{Text = "僅限好友", Value="Friendsonly"},
            new SelectListItem{Text = "私人", Value="personal"}
        };
    }
}
