# open-im-dotnet-demo

## step 1  genetate open-im-sdk.1.0.0.nupkg
    git clone https://github.com/yj12138/open-im-sdk-dotnet.git
    cd open-im-sdk-dotnet
    dotnet pack -c Release  
## step 2 
    git clone https://github.com/yj12138/open-im-dotnet-demo.git
    cd open-im-dotnet-demo
    copy open-im-sdk.1.0.0.nupkg ./
    dotnet add package --source ./ open-im-sdk -v 1.0.0
## step 3
    copy open-im-sdk-dotnet/Plugins ./
    dotnet run