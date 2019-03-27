FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Boyner.ServiceB/Boyner.ServiceB.csproj", "./Boyner.ServiceB"]
RUN dotnet restore "./Boyner.ServiceB.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Boyner.ServiceB.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Boyner.ServiceB.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Boyner.ServiceB.dll"]