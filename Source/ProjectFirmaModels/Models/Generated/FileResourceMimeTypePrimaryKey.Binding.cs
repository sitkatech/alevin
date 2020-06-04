//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FileResourceMimeType
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FileResourceMimeTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FileResourceMimeType>
    {
        public FileResourceMimeTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FileResourceMimeTypePrimaryKey(FileResourceMimeType fileResourceMimeType) : base(fileResourceMimeType){}

        public static implicit operator FileResourceMimeTypePrimaryKey(int primaryKeyValue)
        {
            return new FileResourceMimeTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FileResourceMimeTypePrimaryKey(FileResourceMimeType fileResourceMimeType)
        {
            return new FileResourceMimeTypePrimaryKey(fileResourceMimeType);
        }
    }
}