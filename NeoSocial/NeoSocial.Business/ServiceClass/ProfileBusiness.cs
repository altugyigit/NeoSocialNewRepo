using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoSocial.Database.Models;
using NeoSocial.Database.IUnitOfWork;
using NeoSocial.Database.Repository;
using System.Data.Entity;

namespace NeoSocial.Business
{
   
    public class ProfileBusiness: IProfileBusiness
    {
        UserContext _userContext;
        UserProfile _userProfile;

        public ProfileBusiness()
        {
            _userContext = new UserContext(new DbContextFactory());
            _userProfile = new UserProfile();
        }

        public UserProfile getProfileInfo(int userId)
        {
            return _userContext.UserProfileRepository.Get(a => a.UserID == userId).First();

           
        }

        public int getProfileId(int userId)
        {
            return _userContext.UserProfileRepository.Find(a => a.UserID == userId).UserProfileID;

           
        }

     public   void addProfile(int userId, int userRegisterId) {

         _userProfile.UserID = userId;
         _userProfile.UserRegisterID = userRegisterId;

         _userContext.UserProfileRepository.Create(_userProfile);
         _userContext.Commit();
        
        }

     public void updateIcon(UserProfile userProfile)
     {
        

         _userContext.UserProfileRepository.Update(userProfile);
         _userContext.Commit();

     }

     public bool insertFollower(Follower follower) {

         try
         {

             _userContext.FollowerRepository.Create(follower);
             _userContext.Commit();

             return true;
         }
         catch (Exception ex)
         {
             return false;
         }
     }

     public int checkFollower(Follower follower)
     {
         try
         {
             int _followerId = _userContext.FollowerRepository.Get(a => a.UserID == follower.UserID && a.ProfileID == follower.ProfileID).AsNoTracking().First().FollowerID;

             if (_followerId > 0) return _followerId;
             else return -1;
         }
         catch (Exception ex)
         {
             return -1;
         }
     }
    public void deleteFollower(Follower follower) {

         _userContext.FollowerRepository.Delete(follower);
         _userContext.Commit();
     }

    public List<int> getAllFollowerByProfileId(int profileId)
    {
       return _userContext.FollowerRepository.Get(a => a.ProfileID == profileId).Select(a => (int)a.UserID).ToList();

       
    }
  

    }
}
