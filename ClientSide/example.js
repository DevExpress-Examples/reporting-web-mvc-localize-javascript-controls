"use strict"

const host = 'http://localhost:56742/',
    reportUrl = "Products",
    designerOptions = {
        reportUrl: reportUrl, // The URL of a report that the Report Designer loads when the application starts.  
        requestOptions: { // Options for processing requests from the Report Designer. 
            host: host, // URI of your backend project.
            invokeAction: "/ReportDesigner/Invoke", // Action to enable CORS.
            getDesignerModelAction: "/ReportDesigner/GetReportDesignerModel", // Action that returns the Report Designer model. 
			getLocalizationAction: "/ReportDesigner/GetLocalization" // Action used to get the localized strings from server.
		},
		callbacks: {
            CustomizeLocalization: function (s,e) {
				        e.LoadMessages($.get("/dx-analytics-core.de.json"));
						e.LoadMessages($.get("/dx-reporting.de.json"));
						s.UpdateLocalization({
							'Properties': 'TEST',
							'Data Source': 'Datenquelle',
							'Data Member': 'Datenelement'
						});
				}
			}
		};
							
ko.applyBindings({ designerOptions });
