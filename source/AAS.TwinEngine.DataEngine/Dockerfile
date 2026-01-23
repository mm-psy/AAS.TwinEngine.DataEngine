FROM mcr.microsoft.com/dotnet/sdk:8.0@sha256:aa05b91be697b83229cb000b90120f0783604ad74ed92a0b45cdf3d1a9c873de AS build 
ARG BUILD_CONFIGURATION=Release
WORKDIR /App
COPY ["AAS.TwinEngine.DataEngine/", "AAS.TwinEngine.DataEngine/"]
RUN dotnet restore "AAS.TwinEngine.DataEngine/AAS.TwinEngine.DataEngine.csproj"
RUN dotnet publish "AAS.TwinEngine.DataEngine/AAS.TwinEngine.DataEngine.csproj" -c "$BUILD_CONFIGURATION" -o out

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine@sha256:961ef553f5b47185707ef693f9103004ea98cf022ce826cc8aacd5da29c93a46
USER app
WORKDIR /App
COPY --from=build /App/out .
ENTRYPOINT ["dotnet", "AAS.TwinEngine.DataEngine.dll"]