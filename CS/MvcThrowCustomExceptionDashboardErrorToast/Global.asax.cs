using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml.Linq;
using DevExpress.DashboardWeb;

namespace MvcThrowCustomExceptionDashboardErrorToast {
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DashboardConfig.RegisterService(RouteTable.Routes);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            DashboardConfigurator.Default.SetDashboardStorage(new CustomDashboardStorage());
        }
    }

    public class CustomException : Exception {
        public const string SafeMessage = "Custom exception text for end users";
        public const string UnsafeMessage = "Custom exception text for developers";
    }

    public class CustomDashboardStorage : IDashboardStorage {
        IEnumerable<DashboardInfo> IDashboardStorage.GetAvailableDashboardsInfo() {
            return new[] {
                new DashboardInfo { ID = "Dashboard", Name = "Dashboard" }
            };
        }
        XDocument IDashboardStorage.LoadDashboard(string dashboardID) {
            throw new CustomException();
        }
        void IDashboardStorage.SaveDashboard(string dashboardID, XDocument dashboard) {
        }
    }
}
