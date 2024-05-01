using E_Commerce.Core.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.InterFace
{
    public interface ITokenService
    {
        public string GeneteToken(ApplicationUser user);
    }
}
