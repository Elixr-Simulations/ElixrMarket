using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElixrMarket.Web
{
    public enum Genres
    {
        Medical,
    }

    public static class Constants
    {
        public static class Roles
        {
            public const string Customer = "Customer";
            public const string Developer = "Developer";
            public const string Editor = "Editor";
            public const string ContentReviewer = "ContentReviewer";
            public const string TechnicalReviewer = "TechnicalReviewer";
            public const string Admin = "Admin";
        }
    }
}
