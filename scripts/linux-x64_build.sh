cd ./db_app

dotnet publish -c Release -r linux-x64 --self-contained

cd ..

git add .

git commit -m "Linux-x64 build"

git push