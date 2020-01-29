const host = 'http://localhost:56742/',
	reportUrl = "Products",
	designerOptions = {
		reportUrl: reportUrl, // The URL of a report that the Report Designer loads when the application starts.  
		requestOptions: { // Options to process requests from the Report Designer. 
			host: host, // URI of your backend project.
			getDesignerModelAction: "/ReportDesigner/GetReportDesignerModel", // Action that returns the Report Designer model. 
			// (Optional) Use this action to get the localized strings from the server.
			getLocalizationAction: "/ReportDesigner/GetLocalization" 
		},
		callbacks: {
			// Handle the CustomizeLocalization event to load the DevExpress Localization Service JSON files.
            // (Optional) Handle the CustomizeLocalization event and call the UpdateLocalization method
			// to localize a particular string.
			CustomizeLocalization: function (s, e) {
				e.LoadMessages($.get("/dx-analytics-core.de.json")); // Load files obtained from DevExpress Localization Service. 
				e.LoadMessages($.get("/dx-reporting.de.json")); // Load files obtained from DevExpress Localization Service. 
				s.UpdateLocalization({ 
					'Properties': 'TEST',
					'Data Source': 'Datenquelle',
					'Data Member': 'Datenelement'
				}); 
			}
		}
	};

ko.applyBindings({ designerOptions });
