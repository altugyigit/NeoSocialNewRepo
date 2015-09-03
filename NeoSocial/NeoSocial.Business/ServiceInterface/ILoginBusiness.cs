using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoSocial.Database.Models;

namespace NeoSocial.Business
{
   public interface ILoginBusiness
    {

       int verifyUser(string userName, string userPassword);
       void addUser(string userName, string userPassword, int userRegisterID);
        List<UserLogin> findUser(UserLogin userLogin);
        int findUserIdByName(string userName);
        int findRegisterIdByUserId(int userId);


    }
}
