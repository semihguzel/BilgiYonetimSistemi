using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BilgiYonetimSistemi.DATA.Entities
{
    public class Kullanici : IdentityUser
    {
        public virtual List<Ogrenci> Ogrenciler { get; set; }
        public virtual List<Ogretmen> Ogretmenler { get; set; }
        public virtual List<Yonetici> Yoneticiler { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Kullanici> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
