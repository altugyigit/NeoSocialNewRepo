﻿using NeoSocial.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeoSocial.ViewModels
{
    //INSERT ISLEMLERI ICIN BU MODELLER KULLANILIYOR.

    public class ArticleDbWebModel
    {
        public ArticlePost articlePostDatabaseModel { get; set; }
    }
    public class RegisterDbWebModel
    {
        public UserRegister registerDatabaseModel { get; set; }
    }

}