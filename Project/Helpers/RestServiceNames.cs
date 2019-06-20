using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Helpers
{
    public class RestServiceNamesClass
    {
        public enum RestServiceNames
        {
            GetAccessToken,
            GetVersion,
            CreateContact,
            GetContacts,
            GetContactById,
            UpdateContact,
            DeleteContact
        }
    }
}