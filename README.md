# UFIN
Assessment of Ukrainian financial statements


##  An example of using ASP.NET Blazor WebAssembly to create a progressive web app (PWA) that can be deployed to GitHub Pages.

## This application is able to run directly in the browser using WebAssembly technology.

[![N|Solid](https://miro.medium.com/max/875/1*mNOKpf7lW6dQC8LvewtMdQ.jpeg)](https://docs.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/webassembly)

[Working instance of the application](https://whitewaw.github.io/UFIN/).

This GitHub Actions workflow provides an example of how to deploy an ASP.NET Blazor WebAssembly PWA to GitHub Pages. You can incorporate the script into your build process or continuous integration pipeline. The workflow installs .NET 7 and the necessary WebAssembly tools, publishes the Blazor project to a release folder, modifies the base tag in index.html to match the repository subdirectory, and fixes the hashes in the service-worker-assets.js file. Finally, the workflow deploys the content of the release/wwwroot directory to GitHub Pages using the JamesIves/github-pages-deploy-action.

```sh
name: Deploy to GitHub Pages

on:
  push:
    branches: [ main ]
    
jobs:
  deploy-to-github-pages:
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@v3
    
    - name: Setup .NET 7
      uses: actions/setup-dotnet@v2
      with:
        dotnet-version: '7.0.x'
        include-prerelease: true
        
    - name: Install .NET WebAssembly Tools
      run: dotnet workload install wasm-tools
      
    - name: Install the wasm-experimental workload
      run: dotnet workload install wasm-experimental
        
     # publishes Blazor project to the release-folder
    - name: Publish .NET Core Project
      run: dotnet publish AFS/AFS.csproj -c Release -o release --nologo
    
    # changes the base-tag in index.html from '/' to 'UFIN' to match GitHub Pages repository subdirectory
    - name: Change base-tag in index.html from / to UFIN
      run: sed -i 's/<base href="\/" \/>/<base href="\/UFIN\/" \/>/g' release/wwwroot/index.html

    # changes the base-tag in index.html from '/' to 'UFIN' to match GitHub Pages repository subdirectory
    - name: Fix service-worker-assets.js hashes
      working-directory: release/wwwroot
      run: |
        jsFile=$(<service-worker-assets.js)
        # remove JavaScript from contents so it can be interpreted as JSON
        json=$(echo "$jsFile" | sed "s/self.assetsManifest = //g" | sed "s/;//g")
        # grab the assets JSON array
        assets=$(echo "$json" | jq '.assets[]' -c)
        for asset in $assets
        do
          oldHash=$(echo "$asset" | jq '.hash')
          #remove leading and trailing quotes
          oldHash="${oldHash:1:-1}"
          path=$(echo "$asset" | jq '.url')
          #remove leading and trailing quotes
          path="${path:1:-1}"
          newHash="sha256-$(openssl dgst -sha256 -binary $path | openssl base64 -A)"
          
          if [ $oldHash != $newHash ]; then
            # escape slashes for json
            oldHash=$(echo "$oldHash" | sed 's;/;\\/;g')
            newHash=$(echo "$newHash" | sed 's;/;\\/;g')
            echo "Updating hash for $path from $oldHash to $newHash"
            # escape slashes second time for sed
            oldHash=$(echo "$oldHash" | sed 's;/;\\/;g')
            jsFile=$(echo -n "$jsFile" | sed "s;$oldHash;$newHash;g")
          fi
        done
        echo -n "$jsFile" > service-worker-assets.js
    
    # copy index.html to 404.html to serve the same file when a file is not found
    - name: copy index.html to 404.html
      run: cp release/wwwroot/index.html release/wwwroot/404.html

    # add .nojekyll file to tell GitHub pages to not treat this as a Jekyll project. (Allow files and folders starting with an underscore)
    - name: Add .nojekyll file
      run: touch release/wwwroot/.nojekyll
      
    - name: Commit wwwroot to GitHub Pages
      uses: JamesIves/github-pages-deploy-action@v4.3.3
      with:
        GITHUB_TOKEN: ${{ secrets.GITHUB_TOKEN }}
        BRANCH: gh-pages
        FOLDER: release/wwwroot
```

[How to deploy ASP.NET Blazor WebAssembly to GitHub Pages](https://swimburger.net/blog/dotnet/how-to-deploy-aspnet-blazor-webassembly-to-github-pages).

[Fix Blazor WebAssembly PWA integrity checks](https://swimburger.net/blog/dotnet/fix-blazor-webassembly-pwa-integrity-checks).
