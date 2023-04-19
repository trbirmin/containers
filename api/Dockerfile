# Create a context for building the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env

# Sets working directory inside of the container
WORKDIR /src 

# Copies the C# Project file from our development environment into the build environment
COPY ./*.csproj .

# Restore the nuget package dependencies on our project
RUN dotnet restore

# Copy all files from our development environment to our build environment
COPY ./ .

# Build the solution and & Publish the artifacts 
RUN dotnet publish -c Release -o /publish

# Create a context for running the application
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

# Sets the working directory inside of the container
WORKDIR /publish

# Copies the artifacts from the build environment to our current runtime environment
COPY --from=build-env /publish .

# Expose port 80 by default
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "api.dll"]