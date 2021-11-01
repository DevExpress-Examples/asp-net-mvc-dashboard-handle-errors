using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcCustomTextForInternalDashboardErrors {
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            DashboardConfig.RegisterService(RouteTable.Routes);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(typeof(RestrictedControllerFactory));

            DataSourceInMemoryStorage dataSourceStrorage = new DataSourceInMemoryStorage();

            DashboardSqlDataSource sql = new DashboardSqlDataSource("sql");
            sql.Queries.Add(SelectQueryFluentBuilder.AddTable("Products").SelectAllColumns().Build("query"));
            dataSourceStrorage.RegisterDataSource(sql.SaveToXml());

            DashboardConfigurator.Default.SetDashboardStorage(new DashboardFileStorage(Server.MapPath("~/App_Data/Dashboards")));
            DashboardConfigurator.Default.SetDataSourceStorage(dataSourceStrorage);
            DashboardConfigurator.Default.ConfigureDataConnection += ASPxDashboard1_ConfigureDataConnection;
        }

        void ASPxDashboard1_ConfigureDataConnection(object sender, ConfigureDataConnectionWebEventArgs e) {
            // Invalid connection parameters:
            switch (e.DataSourceName) {
                case "sql":
                    e.ConnectionParameters = new MsSqlConnectionParameters(@"localhost", "Northwind123", null, null, MsSqlAuthorizationType.Windows);
                    break;
            }
        }
    }
}
