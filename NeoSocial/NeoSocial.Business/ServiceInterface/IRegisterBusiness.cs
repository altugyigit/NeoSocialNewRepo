using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoSocial.Database.Models;

namespace NeoSocial.Business
{
   public interface IRegisterBusiness
    {

        UserRegister findById(int registerId);
        void addUser(UserRegister userRegister);
        bool checkUser(string mail);
        int findRegisterIDByMail(string mail);
    }

}
