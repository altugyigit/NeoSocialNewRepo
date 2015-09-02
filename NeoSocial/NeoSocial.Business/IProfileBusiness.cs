using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoSocial.Database.Models;

namespace NeoSocial.Business
{
  public  interface IProfileBusiness
    {
        int getProfileId(int userId);
        UserProfile getProfileInfo(int userId);
        void addProfile(UserProfile userProfile);
        void updateIcon(UserProfile userProfile);
        bool insertFollower(Follower follower);
        int checkFollower(Follower follower);
        void deleteFollower(Follower follower);
        List<int> getAllFollowerByProfileId(int profileId);

    }
}
