cd ../db_app

chmod +x ./scripts/linux-x64_build.sh

dotnet publish -c Release -r linux-x64 --self-contained