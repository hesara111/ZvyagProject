﻿using Project.Core.Stuff;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Project.Helpers.RestServiceNamesClass;

namespace Project.Helpers
{
    public class TokenHelper
    {
        public readonly RestSharpHelper restSharpHelper;

        public TokenHelper()
        {
            restSharpHelper = new RestSharpHelper();
        }

        public Token GetRefreshToken(string login, string password)
        {
            var response = restSharpHelper.Execute<Token>(RestServiceNames.GetAccessToken,
                                                          Method.POST,
                                                          new Dictionary<string, object>()
                                                          {
                                                              {"application/json",
                                                                $"grant_type=password&username={login}&password={password}"}
                                                          },
                                                          false,
                                                          DataFormat.None);
            return response.Data;
        }

    }
}