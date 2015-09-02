using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using NeoSocial.Database.Models;
using NeoSocial.Database.Repository;
using NeoSocial.Database.IUnitOfWork;
using System.Web;


namespace NeoSocial.Business
{

 
  public  class CountryBusiness : ICountryBusiness
    {

        CountryContext _countryContext;
        List<Country> _countryList;

        public CountryBusiness() {

            _countryContext = new CountryContext(new DbContextFactory());

        
        }

        public List<Country> getAllCountry() {

            _countryList = _countryContext.CountryRepository.Get().OrderBy(x => x.CountryID).ToList();
            return _countryList;
        
        
        }


    }
}
