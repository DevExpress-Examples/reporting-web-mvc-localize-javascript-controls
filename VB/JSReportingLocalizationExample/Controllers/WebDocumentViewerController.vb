Imports DevExpress.Web.Mvc.Controllers
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace JSReportingLocalizationExample.Controllers
	Public Class WebDocumentViewerController
		Inherits WebDocumentViewerApiControllerBase

		' GET: WebDocumentViewerApi
		Public Function Index() As ActionResult
			Return View()
		End Function
		Public Overrides Function Invoke() As ActionResult
			Dim result = MyBase.Invoke()
			Response.AppendHeader("Access-Control-Allow-Origin", "*")
			Return result
		End Function
	End Class
End Namespace