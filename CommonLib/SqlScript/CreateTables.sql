create table UserAction
(
ID bigint identity(1,1) not null ,
AppName [nvarchar](64) NOT NULL,
OrgId [nvarchar](128) null,
UserId [nvarchar](128) not null,
Action [nvarchar](128) null,
Parameter [nvarchar](512) null,
DateTimeUTC  [datetime] NULL,
[ExtensionInfo] [nvarchar](2048) NULL,
[RequestUrl] [nvarchar](1024) NULL
)
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserAction_AppName] ON dbo.UserAction(AppName)
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserAction_OrgId] ON dbo.UserAction(OrgId)
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserAction_UserId] ON dbo.UserAction(UserId)
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserAction_Action] ON dbo.UserAction(Action)
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserAction_Parameter] ON dbo.UserAction(Parameter)

---------------------------------------------------------------------------------
create table DataSource
(
Id	int identity(1,1) not null,
DataSoureType	[nvarchar](64) not null,
ConnectString	[nvarchar](128) null,
QueryString	[nvarchar](128) null,
CreateTime	[datetime] null,
APPID	int    null,
SaveTo	[nvarchar](64) not null

)


create table UserData
(
ID	bigint identity(1,1) not null,
Corpid	[nvarchar](64) not null,
corpname	[nvarchar](64) null,
TotalUserCount	Int  not null,
FollowUserCount	Int  not null,
BoundUserCount	int  not null,
Querydate datetime not null
)
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserData_Corpid] ON dbo.UserData(Corpid)

CREATE UNIQUE NONCLUSTERED INDEX [IX_UserData_Querydate] ON dbo.UserData(Querydate)
---------------------------------------------------------------------------
create table AppAllowUser
(
ID	bigint identity(1,1) not null,
APPID int not null,
Corpid [nvarchar](64) not null,
AllowUserCount int not null,
Stage int  not null,
Querydate datetime not null
)
CREATE UNIQUE NONCLUSTERED INDEX [IX_AppAllowUser_Corpid] ON dbo.AppAllowUser(Corpid)

CREATE UNIQUE NONCLUSTERED INDEX [IX_AppAllowUser_Querydate] ON dbo.AppAllowUser(Querydate)


----------------------------------------------------------------------------
create table FeatureUsedByDay
(
[ID] 	bigint identity(1,1) not null,
[QueryData]  datetime not null,
[AppID]  int null,
[Corpid] [nvarchar](64)  not null,
[FeatureID] int null,
[UseCount] int null,
[UseUserCount] int  null,
[UserDetailInfo]  [nvarchar](128) null
)

CREATE UNIQUE NONCLUSTERED INDEX [IX_FeatureUsedByDay_QueryData] ON dbo.FeatureUsedByDay(QueryData)
CREATE UNIQUE NONCLUSTERED INDEX [IX_FeatureUsedByDay_Corpid] ON dbo.FeatureUsedByDay(Corpid)
CREATE UNIQUE NONCLUSTERED INDEX [IX_FeatureUsedByDay_AppID] ON dbo.FeatureUsedByDay(AppID)
CREATE UNIQUE NONCLUSTERED INDEX [IX_FeatureUsedByDay_FeatureID] ON dbo.FeatureUsedByDay(FeatureID)

-----------------------------------------------------------------------------------

create table FeatureUsedByWeek
(
[ID] 	bigint identity(1,1) not null,
[QueryData]  datetime not null,
[Week] [nvarchar](32)  not null,
[AppID]  int null,
[Corpid] [nvarchar](64)  not null,
[FeatureID] int null,
[UseCount] int null,
[UseUserCount] int  null,
[UserDetailInfo]  [nvarchar](128) null
)
CREATE UNIQUE NONCLUSTERED INDEX [IX_FeatureUsedByWeek_Week] ON dbo.FeatureUsedByWeek(Week)
CREATE UNIQUE NONCLUSTERED INDEX [IX_FeatureUsedByWeek_Corpid] ON dbo.FeatureUsedByWeek(Corpid)
CREATE UNIQUE NONCLUSTERED INDEX [IX_FeatureUsedByWeek_AppID] ON dbo.FeatureUsedByWeek(AppID)
CREATE UNIQUE NONCLUSTERED INDEX [IX_FeatureUsedByWeek_FeatureID] ON dbo.FeatureUsedByWeek(FeatureID)

-----------------------------------------------------------------------------------

create table FeatureUsedByMonth
(
[ID] 	bigint identity(1,1) not null,
[QueryData]  datetime not null,
[Month] [nvarchar](32)  not null,
[AppID]  int null,
[Corpid] [nvarchar](64)  not null,
[FeatureID] int null,
[UseCount] int null,
[UseUserCount] int  null,
[UserDetailInfo]  [nvarchar](128) null
)
CREATE UNIQUE NONCLUSTERED INDEX [IX_FeatureUsedByMonth_Month] ON dbo.FeatureUsedByMonth(Month)
CREATE UNIQUE NONCLUSTERED INDEX [IX_FeatureUsedByMonth_Corpid] ON dbo.FeatureUsedByMonth(Corpid)
CREATE UNIQUE NONCLUSTERED INDEX [IX_FeatureUsedByMonth_AppID] ON dbo.FeatureUsedByMonth(AppID)
CREATE UNIQUE NONCLUSTERED INDEX [IX_FeatureUsedByMonth_FeatureID] ON dbo.FeatureUsedByMonth(FeatureID)

-----------------------------------------------------------------------------------

create table AppUsedByDay
(
[ID]bigint identity(1,1) not null,
[QueryData]  datetime not null,
[AppID] int null,
[Corpid][nvarchar](64)  not null,
[UseCount]int  null,
[UseUserCount]int  null

)
CREATE UNIQUE NONCLUSTERED INDEX [IX_AppUsedByDay_QueryData] ON dbo.AppUsedByDay(QueryData)
CREATE UNIQUE NONCLUSTERED INDEX [IX_AppUsedByDay_AppID] ON dbo.AppUsedByDay(AppID)
CREATE UNIQUE NONCLUSTERED INDEX [IX_AppUsedByDay_Corpid] ON dbo.AppUsedByDay(Corpid)

--------------------------------------------------------------------------------------------
create table AppUsedByWeek
(
[ID]bigint identity(1,1) not null,
[QueryData]  datetime not null,
[Week] [nvarchar](32)  not null,
[AppID] int null,
[Corpid][nvarchar](64)  not null,
[UseCount]int  null,
[UseUserCount]int  null

)
CREATE UNIQUE NONCLUSTERED INDEX [IX_AppUsedByWeek_Week] ON dbo.AppUsedByWeek(Week)
CREATE UNIQUE NONCLUSTERED INDEX [IX_AppUsedByWeek_QueryData] ON dbo.AppUsedByWeek(QueryData)
CREATE UNIQUE NONCLUSTERED INDEX [IX_AppUsedByWeek_AppID] ON dbo.AppUsedByWeek(AppID)
CREATE UNIQUE NONCLUSTERED INDEX [IX_AppUsedByWeek_Corpid] ON dbo.AppUsedByWeek(Corpid)

--------------------------------------------------------------------------------------------

create table AppUsedByMonth
(
[ID]bigint identity(1,1) not null,
[QueryData]  datetime not null,
[Month] [nvarchar](32)  not null,
[AppID] int null,
[Corpid][nvarchar](64)  not null,
[UseCount]int  null,
[UseUserCount]int  null
)
CREATE UNIQUE NONCLUSTERED INDEX [IX_AppUsedByMonth_Month] ON dbo.AppUsedByMonth(Month)
CREATE UNIQUE NONCLUSTERED INDEX [IX_AppUsedByMonth_QueryData] ON dbo.AppUsedByMonth(QueryData)
CREATE UNIQUE NONCLUSTERED INDEX [IX_AppUsedByMonth_AppID] ON dbo.AppUsedByMonth(AppID)
CREATE UNIQUE NONCLUSTERED INDEX [IX_AppUsedByMonth_Corpid] ON dbo.AppUsedByMonth(Corpid)

--------------------------------------------------------------------------------------------
