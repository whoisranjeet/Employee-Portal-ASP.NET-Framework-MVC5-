Database structure and queries... (SQL Query)

Create Database -> EmployeeDB

Select EmployeeDB Database

Execute the following set of queries.

1 ->

CREATE TABLE [dbo].[Roles] (
[id] INT IDENTITY (1, 1) NOT NULL,
[role] VARCHAR (25) NOT NULL CONSTRAINT [Unique_Roles] UNIQUE,
CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([id] ASC)
);

2 ->

SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT INTO [dbo].[Roles] ([id], [role]) VALUES (1, N'Admin')
INSERT INTO [dbo].[Roles] ([id], [role]) VALUES (3, N'Employee')
INSERT INTO [dbo].[Roles] ([id], [role]) VALUES (2, N'HR')
INSERT INTO [dbo].[Roles] ([id], [role]) VALUES (4, N'Manager')
SET IDENTITY_INSERT [dbo].[Roles] OFF

3 ->

CREATE TABLE [dbo].[Users] (
[id] INT IDENTITY (1, 1) NOT NULL,
[username] VARCHAR (10) NOT NULL,
[password] VARCHAR (10) NOT NULL,
[roleid] INT NULL,
CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([id] ASC),
CONSTRAINT [FK_Users_Roles] FOREIGN KEY ([roleid]) REFERENCES [dbo].[Roles] ([id])
);

4 ->

CREATE TABLE [dbo].[Employees] (
[id] INT IDENTITY (1, 1) NOT NULL,
[firstname] VARCHAR (20) NOT NULL,
[lastname] VARCHAR (20) NOT NULL,
[mobile] VARCHAR (10) NULL,
[emailid] VARCHAR (30) NULL,
[address] VARCHAR (30) NULL,
[department] VARCHAR (30) NULL,
[userid] INT NULL,
CONSTRAINT [PK_Employees_1] PRIMARY KEY CLUSTERED ([id] ASC),
CONSTRAINT [FK_Employees_Users] FOREIGN KEY ([userid]) REFERENCES [dbo].[Users] ([id])
);