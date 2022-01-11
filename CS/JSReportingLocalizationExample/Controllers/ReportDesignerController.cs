using DevExpress.DataAccess.Sql;
using DevExpress.Web.Mvc.Controllers;
using DevExpress.XtraReports.Web.Localization;
using DevExpress.XtraReports.Web.ReportDesigner;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace JSReportingLocalizationExample.Controllers
{
    public class ReportDesignerController : ReportDesignerApiController
    {
        // GET: ReportDesigner
        public ActionResult Index()
        {
            return View();
        }
        public override ActionResult Invoke()
        {
            var result = base.Invoke();
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            return result;
        }
        public ActionResult GetReportDesignerModel(string reportUrl)
        {
            Response.AppendHeader("Access-Control-Allow-Origin", "*");

            string modelJsonScript =
                new ReportDesignerClientSideModelGenerator()
                .GetJsonModelScript(
                    reportUrl,                 // The URL of a report that is opened in the Report Designer when the application starts.
                    GetAvailableDataSources(), // Available data sources in the Report Designer that can be added to reports.
                    "ReportDesigner/Invoke",   // The URI path of the controller action that processes requests from the Report Designer.
                    "WebDocumentViewer/Invoke",// The URI path of the controller action that processes requests from the Web Document Viewer.
                    "QueryBuilder/Invoke"      // The URI path of the controller action that processes requests from the Query Builder.
                );
            return Content(modelJsonScript, "application/json");
        }

        override public ActionResult GetLocalization()
        {
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("de-DE");
            return base.GetLocalization();
        }
        Dictionary<string, object> GetAvailableDataSources()
        {
            var dataSources = new Dictionary<string, object>();
            SqlDataSource ds = new SqlDataSource("NWindConnectionString");
            var query = SelectQueryFluentBuilder.AddTable("Products").SelectAllColumns().Build("Products");
            ds.Queries.Add(query);
            ds.RebuildResultSchema();
            dataSources.Add("SqlDataSource", ds);
            return dataSources;
        }
    }
}