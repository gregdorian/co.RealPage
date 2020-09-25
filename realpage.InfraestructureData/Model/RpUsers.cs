using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace realpage.InfraestructureData.Model
{
    public class RpUsers : IdentityUser
    {

        public int Age { get; set; }
        public string Nationality { get; set; }
        public bool Gender { get; set; }

    }
}
