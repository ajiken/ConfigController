# ConfigController
C# で config を扱いやすくする  

# How to use
- 使用したいプロジェクトに NuGet から System.Configuration.ConfigurationManager をインストールする必要がある  
```
dotnet add package System.Configuration.ConfigurationManager --version 8.0.0
```
参考：[System.Configuration.ConfigurationManager](https://www.nuget.org/packages/System.Configuration.ConfigurationManager/)  

- App.config ファイルを作成
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="Server" value="example.com"/>
    <add key="Username" value="Admin"/>
  </appSettings>
</configuration>
```
