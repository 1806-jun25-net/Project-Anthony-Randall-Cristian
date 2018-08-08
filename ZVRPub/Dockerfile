FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ZVRPub.Library/*.csproj ./ZVRPub.Library/
COPY ZVRPub.MVCFrontEnd/*.csproj ./ZVRPub.MVCFrontEnd/
COPY ZVRPub.Test/*.csproj ./ZVRPub.Test/
RUN dotnet restore

# copy everything else and build app
COPY . ./
WORKDIR /app/ZVRPub.MVCFrontEnd
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/ZVRPub.MVCFrontEnd/out ./
ENTRYPOINT ["dotnet", "ZVRPub.MVCFrontEnd.dll"]