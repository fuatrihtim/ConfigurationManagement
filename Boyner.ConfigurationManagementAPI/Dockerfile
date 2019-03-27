#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Boyner.ConfigurationManagementAPI/Boyner.ConfigurationManagementAPI.csproj", "Boyner.ConfigurationManagementAPI/"]
RUN dotnet restore "Boyner.ConfigurationManagementAPI/Boyner.ConfigurationManagementAPI.csproj"
COPY . .
WORKDIR "/src/Boyner.ConfigurationManagementAPI"
RUN dotnet build "Boyner.ConfigurationManagementAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Boyner.ConfigurationManagementAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Boyner.ConfigurationManagementAPI.dll"]