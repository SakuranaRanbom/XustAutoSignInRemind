# XustAutoSignInRemind
xust健康打卡自动提醒

sdk: dotnet 5

运行: dotnet run

发布：dotnet publish -c release -r [linux-arm/linux-x64/win-x64/...]

数据库结构更新: dotnet ef migrations add XXX    -> dotnet ef database update

#### 更新记录：

20211016:数据库有问题，暂时停用数据库和web面板