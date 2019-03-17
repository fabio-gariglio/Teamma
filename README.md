# Teamma
Team management platform for Agile teams

## Prerequisites

* Install .NET Core sSDK following [the official guide](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/install).
* Install Docker community edition following [the official guide](https://docs.docker.com/install/linux/docker-ce/ubuntu/).
* Install Docker Compose: `sudo apt install docker-compose`
* Install NodeJs following [the guide for Linux](https://github.com/nodesource/distributions/blob/master/README.md#installation-instructions).

## Getting started

1. Run Docker compose to launch all the containers

```bash
$ docker-compose up -d
```

Browse http://localhost:5000

## Useful commands

Build the FrontEnd

```bash
$ dotnet publish -c Release
$ docker build -t frontend /src/FrontEnd/.
```

## How to add React to an AspNet service

1. Create the following file structure:
```
ClientApp
- public
  - index.html
- src
  - index.js
```

2. Initialize npm into the `ClientApp` folder:
```bash
$ npm init
```

3. Install react modules and react-script dev module:
```bash
npm install react --save
npm install react-dom --save
npm install react-script --save-dev
```

4. Add the "build" npm command that transform the source JS files:
```json
{
  "scripts": {
      "build": "react-scripts build"
  }
}
```

5. Configure AspNet to serve a SPA:
```cs
public void ConfigureServices(IServiceCollection services)
{
    // ...
    services.AddSpaStaticFiles(configuration =>
    {
        configuration.RootPath = "ClientApp/build";
    });
    // ...
}

// ...

public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    // ...
    app.UseStaticFiles();
    app.UseSpaStaticFiles();
    
    app.UseSpa(spa =>
    {
        spa.Options.SourcePath = "ClientApp";
    });
    // ...
}
```
