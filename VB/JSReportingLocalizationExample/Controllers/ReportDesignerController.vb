Imports DevExpress.DataAccess.Sql
Imports DevExpress.Web.Mvc.Controllers
Imports DevExpress.XtraReports.Web.Localization
Imports DevExpress.XtraReports.Web.ReportDesigner
Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq
Imports System.Threading
Imports System.Web
Imports System.Web.Mvc

Namespace JSReportingLocalizationExample.Controllers
	Public Class ReportDesignerController
		Inherits ReportDesignerApiControllerBase

		' GET: ReportDesigner
		Public Function Index() As ActionResult
			Return View()
		End Function
		Public Overrides Function Invoke() As ActionResult
			Dim result = MyBase.Invoke()
			Response.AppendHeader("Access-Control-Allow-Origin", "*")
			Return result
		End Function
		Public Function GetReportDesignerModel(ByVal reportUrl As String) As ActionResult
			Response.AppendHeader("Access-Control-Allow-Origin", "*")

			Dim modelJsonScript As String = (New ReportDesignerClientSideModelGenerator()).GetJsonModelScript(reportUrl, GetAvailableDataSources(), "ReportDesigner/Invoke", "WebDocumentViewer/Invoke", "QueryBuilder/Invoke") ' The URI path of the controller action that processes requests from the Query Builder. -  The URI path of the controller action that processes requests from the Web Document Viewer. -  The URI path of the controller action that processes requests from the Report Designer. -  Available data sources in the Report Designer that can be added to reports. -  The URL of a report that is opened in the Report Designer when the application starts.
			Return Content(modelJsonScript, "application/json")
		End Function

		Public Overrides Function GetLocalization() As ActionResult
			Response.AppendHeader("Access-Control-Allow-Origin", "*")
			Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("de-DE")
			Return MyBase.GetLocalization()
		End Function
		Private Function GetAvailableDataSources() As Dictionary(Of String, Object)
			Dim dataSources = New Dictionary(Of String, Object)()
			Dim ds As New SqlDataSource("NWindConnectionString")
			Dim query = SelectQueryFluentBuilder.AddTable("Products").SelectAllColumns().Build("Products")
			ds.Queries.Add(query)
			ds.RebuildResultSchema()
			dataSources.Add("SqlDataSource", ds)
			Return dataSources
		End Function
	End Class
End Namespace