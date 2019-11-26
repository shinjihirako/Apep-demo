#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1709 AS base
LABEL author ="Donny Bottse"
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY ["Media/Media.WebAp22222i.csproj", "Media/"]
RUN dotnet restore "Media/Media.WebApi.csproj"
COPY . .
WORKDIR "/src/services/media"
RUN dotnet build "Media.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Media.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Media.WepApi.dll"]