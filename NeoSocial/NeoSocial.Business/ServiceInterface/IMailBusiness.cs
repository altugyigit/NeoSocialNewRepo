﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoSocial.Database.Models;

namespace NeoSocial.Business
{
  public interface IMailBusiness
    {

      void sendMail(string fromMail, string toMail, string subject, string message);
        string findPassword(int registerID);

    }
}
