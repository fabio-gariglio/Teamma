# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY /bin/Release/netcoreapp2.2/publish .
ENTRYPOINT ["dotnet", "FrontEnd.dll"]
