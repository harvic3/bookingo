using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookingoApi.Modules.UserAdmin
{
    public partial class UserModel
    {
        [NotMapped]
        public string Password { get; set; }
        public string Uid { get; set; }
        public bool Disabled { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool EmailVerified { get; set; }
        public string PhotoUrl { get; set; }
        public short RoleId { get; set; }
        public bool Deleted { get; set; }
        public Dictionary<string, object> Clains { get; set; }
        public virtual RoleModel Role { get; set; }
    }
}