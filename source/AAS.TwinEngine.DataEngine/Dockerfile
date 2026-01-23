FROM mcr.microsoft.com/dotnet/sdk:10.0@sha256:25d14b400b75fa4e89d5bd4487a92a604a4e409ab65becb91821e7dc4ac7f81f AS build 
ARG BUILD_CONFIGURATION=Release
WORKDIR /App
COPY ["AAS.TwinEngine.DataEngine/", "AAS.TwinEngine.DataEngine/"]
RUN dotnet restore "AAS.TwinEngine.DataEngine/AAS.TwinEngine.DataEngine.csproj"
RUN dotnet publish "AAS.TwinEngine.DataEngine/AAS.TwinEngine.DataEngine.csproj" -c "$BUILD_CONFIGURATION" -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine@sha256:a0ce42fe86548363a9602c47fc3bd4cf9c35a2705c68cd98d7ce18ae8735b83c
USER app
WORKDIR /App
COPY --from=build /App/out .
ENTRYPOINT ["dotnet", "AAS.TwinEngine.DataEngine.dll"]