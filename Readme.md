# How to Localize the Reporting Controls in a JavaScript Application with Knockout Bindings

This example includes the server-side (backend) application that is an ASP.NET MVC application created from the DevExpress Visual Studio template as described in the [Report Designer's Server-Side Configuration (ASP.NET MVC)](https://docs.devexpress.com/XtraReports/118371) topic.

The client-side (front-end) application is created in JavaScript with npm as described in the [Basic Report Designer Integration (with npm or Yarn Package Managers)](https://docs.devexpress.com/XtraReports/401256) document.

To run the example, perform the following steps:

1. Open the **CS** or **VB** solution in Visual Studio and rebuild to install the required NuGet packages.
2. Run the command prompt, navigate to the ClientSide folder and execute the command:
    
    ```
    npm install
    ```
3. Open the Internet Information Services manages and add a website whose content's physical path is the **ClientSide** folder. Specify any free port, in this example it is **1020**. Start the web site.
4. Run the Visual Studio project.
5. Open the URL **localhost:1020** (port number may be different, as specified in step 3) in your browser.

![](/images/screenshot.png)
