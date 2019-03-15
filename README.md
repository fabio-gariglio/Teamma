# Teamma
Team management platform for Agile teams

## Prerequisites

* Install .NET Core sSDK following [the official guide](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/install).
* Install Docker community edition following [the official guide](https://docs.docker.com/install/linux/docker-ce/ubuntu/).
* Install Docker Compose: `sudo apt install docker-compose`

## Getting started

1. Run Docker compose to launch all the containers

```bash
$ docker-compose up -d
```

2. Get a given container IP

```bash
$ docker inspect {container-id} | grep IPAddress
```