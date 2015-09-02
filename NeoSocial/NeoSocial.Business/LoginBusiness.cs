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
   

  public  class LoginBusiness :ILoginBusiness
{

        UserContext _userContext;
       

        public LoginBusiness() 
        {
            _userContext = new UserContext(new DbContextFactory());
        }

        public   void addUser(UserLogin userLogin)      
        {
            _userContext.UserLoginRepository.Create(userLogin);
            _userContext.Commit();
        }

        public int verifyUser(UserLogin userLogin)
        {
            string _userNameText = userLogin.UserName;
            string _userPasswordText = userLogin.UserPassword;

            var resultVerify = _userContext.UserLoginRepository.Find(a => a.UserName == _userNameText && a.UserPassword == _userPasswordText);

            //Repository ile login bilgilerini kontrol et ve aynı zamanda şifre ve kullanıcı adının farklı olmasına dikkat et.
            if( resultVerify != null && !_userNameText.Equals(_userPasswordText))
            {
                return resultVerify.UserID;
            }
            else
            {
                return -1;
            }
        }

     public   List<UserLogin> findUser(UserLogin userLogin) {

            List<UserLogin> login = new List<UserLogin>();
            string _username = userLogin.UserName;

        login=    _userContext.UserLoginRepository.Get(x => x.UserName == _username).ToList();

        return login;
        
        }

     public int findUserIdByName(string userName,UserLogin userLogin)
     {
         userLogin = new UserLogin();

         userLogin = _userContext.UserLoginRepository.Get(x => x.UserName == userName).First();

         return userLogin.UserID;
     }

  public   int findRegisterIdByUserId(int userId,UserLogin userLogin) {

      userLogin = new UserLogin();

      userLogin = _userContext.UserLoginRepository.Get(x => x.UserID == userId).First();

      return userLogin.UserRegisterID;
     
     
     }
    }
}
