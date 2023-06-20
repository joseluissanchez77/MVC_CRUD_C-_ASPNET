
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_CRUD_C__ASPNET.Models.ViewModels
{
    public class UserVM
    {
        public User oUser { get; set; }

        public List<SelectListItem> oPositionList { get; set; }
    }
}
