using NeoSocial.Database.IUnitOfWork;
using NeoSocial.Database.Repository;
using NeoSocial.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSocial.Business
{
   
    public class IconBusiness : IIconBusiness
    {
        PostContext _postContext;
       
        Icon _icon;

        public IconBusiness()
        {
            _postContext = new PostContext(new DbContextFactory());   
        }

        public List<Icon> getAllIconId()
        {
           return _postContext.IconRepository.Get().ToList();

          
        }

        public string getIconUrl(int iconId)
        {
            _icon = _postContext.IconRepository.Filter(a => a.IconID == iconId).ToList().First();

            return _icon.IconPath;
        }
    }
}
