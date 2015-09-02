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

      public bool checkUser(UserLogin userLogin) {

          string _userNameText = userLogin.UserName;
          string _userPasswordText = userLogin.UserPassword;

          if (_userContext.UserLoginRepository.Find(a => a.UserName == _userNameText) != null && !_userNameText.Equals(_userPasswordText))
          {
              return true;
          }
          else
          {
              return false;
          }
      
      
      }

      public List<UserRegister> findID(UserRegister userRegister) {

          string mail=userRegister.Email;

       return _userContext.UserRegisterRepository.Get(x => x.Email == mail).ToList();

      
      }

      public UserRegister findById(int registerId)
      {
         return  _userContext.UserRegisterRepository.Find(a => a.UserRegisterID == registerId);

         
      }

    }

}
