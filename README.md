# UFIN
Assessment of Ukrainian financial statements


##  ASP.NET Blazor WebAssembly PWA to GitHub Pages example

## WebAssembly Application which runs natively in the browser

[![N|Solid](https://miro.medium.com/max/875/1*mNOKpf7lW6dQC8LvewtMdQ.jpeg)](https://docs.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/webassembly)

[Working instance of the application](https://whitewaw.github.io/AFS/).

You can integrate into your build process or continuous integration pipeline next script, as done in this GitHub Actions workflow:

```sh
name: Deploy to GitHub Pages

on:
  push:
    branches: [ main ]
    
jobs:
  deploy-to-github-pages:
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@v2
    
    - name: Setup .NET 6
      uses: actions/setup-dotnet@v2
      with:
        dotnet-version: '6.0.x'
        include-prerelease: true
        
    - name: Install .NET WebAssembly Tools
      run: dotnet workload install wasm-tools
        
     # publishes Blazor project to the release-folder
    - name: Publish .NET Core Project
      run: dotnet publish AFS.sln -c Release -o release --nologo
    
    # changes the base-tag in index.html from '/' to 'AFS' to match GitHub Pages repository subdirectory
    - name: Change base-tag in index.html from / to AFS
      run: sed -i 's/<base href="\/" \/>/<base href="\/AFS\/" \/>/g' release/wwwroot/index.html

    # changes the base-tag in index.html from '/' to 'AFS' to match GitHub Pages repository subdirectory
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
