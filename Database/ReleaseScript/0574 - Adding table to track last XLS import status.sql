
--drop table if exists ImportFinancial.ImpProcessingTableType


CREATE TABLE ImportFinancial.ImpProcessingTableType
(
    ImpProcessingTableTypeID [int] NOT NULL,
    ImpProcessingTableTypeName varchar(200) not null
 CONSTRAINT [PK_ImpProcessingTableType_ImpProcessingTableTypeID] PRIMARY KEY CLUSTERED 
(
    ImpProcessingTableTypeID ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE ImportFinancial.ImpProcessing
(
    ImpProcessingID [int] IDENTITY(1,1) NOT NULL,
    ImpProcessingTableTypeID int not null,
    -- When was this uploaded?
    UploadDate datetime null,
    UploadPersonID int null,
    -- When was this last successfully processed (we do allow re-processing)
    LastProcessedDate datetime null,
    LastProcessedPersonID int null,
 -- Primary key
 CONSTRAINT [PK_ImpProcessing_ImpProcessingID] PRIMARY KEY CLUSTERED 
(
    ImpProcessingID ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE ImportFinancial.ImpProcessing  WITH CHECK 
ADD CONSTRAINT [FK_ImpProcessing_UploadPersonID_UploadPersonID] FOREIGN KEY(UploadPersonID)
REFERENCES dbo.Person(PersonID)

ALTER TABLE ImportFinancial.ImpProcessing  WITH CHECK 
ADD CONSTRAINT [FK_ImpProcessing_LastProcessedPersonID_LastProcessedPersonID] FOREIGN KEY(LastProcessedPersonID)
REFERENCES dbo.Person(PersonID)

ALTER TABLE ImportFinancial.ImpProcessing  WITH CHECK 
ADD CONSTRAINT [FK_ImpProcessing_ImpProcessingTableType_ImpProcessingTableTypeID] FOREIGN KEY(ImpProcessingTableTypeID)
REFERENCES ImportFinancial.ImpProcessingTableType(ImpProcessingTableTypeID)

