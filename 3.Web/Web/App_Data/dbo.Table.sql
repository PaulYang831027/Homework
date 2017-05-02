CREATE TABLE [dbo].[Station] (
    [ReservoirName]         NVARCHAR (100) NOT NULL,
    [ReservoirIdentifier]   INT            NULL,
    [EffectiveCapacity]     FLOAT (53)     NULL,
    [DeadStorageLevel]      FLOAT (53)     NULL,
    [FullWaterLevel]        FLOAT (53)     NULL,
    [CatchmentAreaRainfall] FLOAT (53)     NULL,
    [InflowVolume]          FLOAT (53)     NULL,
    [OutflowTotal]          FLOAT (53)     NULL,
    PRIMARY KEY CLUSTERED ([ReservoirName] ASC)
);