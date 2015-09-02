using System;
using System.Collections.Generic;

namespace NeoSocial.Database.Models
{
    public partial class TurkeyCity
    {
        public TurkeyCity()
        {
            this.UserRegisters = new List<UserRegister>();
        }

        public string CityCode { get; set; }
        public string CityName { get; set; }
        public virtual ICollection<UserRegister> UserRegisters { get; set; }
    }
}
