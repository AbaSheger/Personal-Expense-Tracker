# Use the official ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET SDK as a build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PersonalExpenseTracker/PersonalExpenseTracker.csproj", "PersonalExpenseTracker/"]
RUN dotnet restore "PersonalExpenseTracker/PersonalExpenseTracker.csproj"
COPY . .
WORKDIR "/src/PersonalExpenseTracker"
RUN dotnet build "PersonalExpenseTracker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PersonalExpenseTracker.csproj" -c Release -o /app/publish

# Use the base image to run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonalExpenseTracker.dll"]
