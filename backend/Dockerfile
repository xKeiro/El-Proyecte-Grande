FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# ARG ASPNETCORE_URLS

# ENV ASPNETCORE_URLS=ASPNETCORE_URLS

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
RUN apt-get update && apt-get install -y curl
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "backend.dll"]Trusted_Connection=True;