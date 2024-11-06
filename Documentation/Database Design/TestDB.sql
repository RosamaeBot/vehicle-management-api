CREATE TABLE [dbo].[FleetType]
(
	[FleetTypeId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
        [FleetTypeName]  NVARCHAR(20) NOT NULL
)

CREATE TABLE [dbo].[Fleet]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    	[Make] NVARCHAR(20) NOT NULL, 
    	[Model] NVARCHAR(20) NOT NULL, 
    	[Price] smallmoney NOT NULL,
        [FleetTypeId] int,
        constraint [FK_FleetId] foreign key ([FleetTypeId]) references [dbo].[FleetType](FleetTypeId)
)

INSERT INTO [dbo].[FleetType] (FleetTypeName)
VALUES ('Car')


INSERT INTO [dbo].[FleetType] (FleetTypeName)
VALUES ('Boat')


INSERT INTO [dbo].[Fleet] (Make, Model, Price, FleetTypeId) 
                                     VALUES ('Toyota', 'Camry', 321.3, 1);

INSERT INTO [dbo].[Fleet] (Make, Model, Price, FleetTypeId) 
                                     VALUES ('Toyota', 'Prius', 321.3, 1);
SELECT * FROM dbo.Fleet
SELECT * FROM dbo.FleetType
