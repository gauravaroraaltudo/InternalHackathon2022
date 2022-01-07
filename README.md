# InternalHackathon2022
## Sitecore JSS with SSR


The solution is powered by:
- Sitecore with Headless Services
- Sitecore CLI
- Angular JS
- ✨Magic ✨

## Tech
Below are the version specific details of our tech stack:

- [Sitecore XP 10.2] - Vanilla version for our sitecore.
- [Sitecore Headless Services 19.0.0] - Sitecore module for Headless and JSS.
- [Sitecore ManagementServices 4.0.0] - Sitecore module used for Content Serialization.
- [node.js] - To support SSR of Sitecore JSS.
- [Angular JS] - To implement the seemless front-end experience.
- [Powershell] - To get rid of manual tasks.

## Installation

1. Setup vanilla instance of Sitecore 10.2(XP)
2. Install Sitecore Headless Services 19.0.0
3. Install Sitecore ManagementServices 4.0.0

Restore the nuget packages and make sure your solution is buildable.

Now, go to the location where code is cloned and follow the below steps to setup Sitecore Content Serialization in Powershell

```sh
cd Hackathon
dotnet nuget add source https://sitecore.myget.org/F/sc-packages/api/v3/index.json -n myget
dotnet tool install Sitecore.CLI --version 4.0.0
dotnet sitecore login --auth <identity-server-hostname> --cm <cm-server-hostname> --allow-write true
dotnet sitecore ser push
```

For code setup, run this command in already opened Powershell window

```sh
.\code-publish.ps1
```
This will create the build artifacts in "app.publish" folder. Copy all assets from there and paste them in your Sitecore instance.

For Angular Code Integration

```sh
cd .\jss\hackathon\
npm i
npm run build
```
This will create the build artifacts for Angular code in dist folder. Copy all contents from there and then go to Sitecore Instance and create a folder named as "dist" then create folder named "hackathon" inside it. Paste the artifacts inside "hackathon" folder.

Reload the homepage of your website.

### Voila Sitecore JSS is up and Running.

