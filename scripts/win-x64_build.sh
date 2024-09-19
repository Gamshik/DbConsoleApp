cd ./db_app

dotnet publish -c Release -r win-x64 --self-contained

cd ..

git add .

git commit -m "Win-x64 build"

git push