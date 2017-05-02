CREATE TABLE [dbo].[Table] (
    [ReservoirName]         NVARCHAR (100) NOT NULL,
    [ReservoirIdentifier]   INT NULL,
    [EffectiveCapacity]     FLOAT NULL,
    [DeadStorageLevel]      FLOAT NULL,
    [FullWaterLevel]        FLOAT NULL,
    [CatchmentAreaRainfall] FLOAT NULL,
    [InflowVolume]          FLOAT NULL,
    [OutflowTotal]          FLOAT NULL,
    PRIMARY KEY CLUSTERED ([ReservoirName] ASC)
);

