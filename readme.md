 # Real-time Charts with ASP.NET Core, SignalR, and Chart.js

This project shows how to update a real-time chart in your web browser using technologies like ASP.NET Core, SignalR, and Chart.js.

Note The backend is contrived using a Buffer type that is not thread-safe. Substitute your own implementation where data is derived from a database, web service, etc.

## Getting Started

* The latest .NET SDK (6+) (https://dot.net)

 * A .NET IDE like JetBrains Rider

After installing the dotnet sdk, you can run the project.

```bash
dotnet run --project Charts -lp http
```

Then navigate to http://localhost:5296 if the browser did not open.

## Usage

* Once the project is running, navigate to http://localhost:5296 in your web browser to view the real-time chart. The chart will automatically update with new data as it becomes available.



## Thoughts

### SignalR Setup


* Setting up SignalR was relatively painless, but required some reading about what a Hub is and what a IHubContext<THub> is.

* Using LibMan to manage JavaScript dependencies is nice. Check out libman.json in web project. There are several SignalR packages, so finding the right one was annoying.


### Background Service

* A background service is a nice approach to having a recurring event happen.

### ASP.NET Core Razor Pages

 * I was able to do everything in Razor, but could have easily moved things to the IndexModel. By everything I mean injecting dependencies and generating the starting JSON for our Chart.JS element.
* I like  Razor Pages



### Chart.Js

* Relatively straightforward to set up and very responsive. The use of Canvas also allows for some interesting scenarios that I could explore later.

 * Getting data from the Razor Page/ASP.NET Core to ChartJs is an interesting challenge. I ended up using a script element with a type of application/json. Seems reasonable to me. The other choice was a global value on the window element.

## Troubleshooting

If you encounter any issues during setup or usage, try the following steps:

- **Issue**: Chart is not updating in real-time.
  - **Solution**: Ensure that the SignalR connection is established correctly and that data is being sent to the client. Check the browser console for any error messages that may provide further insight.

- **Issue**: Project fails to build or run.
  - **Solution**: Make sure you have the latest .NET SDK (6+) installed and that you are running the project with the correct command (`dotnet run --project Charts -lp http`).




## Acknowledgements

This project makes use of the following third-party libraries and frameworks:

- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)
- [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)
- [Chart.js](https://www.chartjs.org/)



## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.
