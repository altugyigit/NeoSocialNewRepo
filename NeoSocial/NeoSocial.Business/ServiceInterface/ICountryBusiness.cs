﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoSocial.Database.Models;

namespace NeoSocial.Business
{
    public interface ICountryBusiness {


        List<Country> getAllCountry();

        string getCountryNameById(int countryId);
    
    }
}
