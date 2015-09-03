using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoSocial.Database.Models;
using NeoSocial.Database.Repository;
using NeoSocial.Database.IUnitOfWork;
using NeoSocial.Business;


namespace NeoSocial.Business
{
   

  public  class RegisterBusiness : IRegisterBusiness
    {
      UserContext _userContext;
     

      public RegisterBusiness()
      {
          
          _userContext = new UserContext(new DbContextFactory());
      }

      public void addUser(UserRegister userRegister)
      {

          _userContext.UserRegisterRepository.Create(userRegister);
          _userContext.Commit();

      }

      public bool checkUser(string mail) {

         
          if (_userContext.UserRegisterRepository.Find(addUser=>addUser.Email==mail) != null )
          {
              return true;
          }
          else
          {
              return false;
          }
      
      
      }

      public int findRegisterIDByMail(string mail) {

       return _userContext.UserRegisterRepository.Get(x => x.Email == mail).First().UserRegisterID;

      
      }

      public UserRegister findById(int registerId)
      {
         return  _userContext.UserRegisterRepository.Find(a => a.UserRegisterID == registerId);

         
      }

    }

}
