INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(378, N'TrainingVideoUploadDate', N'Video Upload Date'),
(379, N'TrainingVideoUrl', N'Video URL')

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values
(378, 'The date the video was uploaded on the external site where it is hosted.'),
(379, 'URL of externally hosted training video. URL must be an embed link provided by the video hosting service.')

alter table dbo.TrainingVideo add SortOrder int null
go

-- update sort order to match current default sorting  by training video ID

--Update dbo.TrainingVideo set SortOrder = 0 where TrainingVideoID = 1 and TenantID = 1
--Update dbo.TrainingVideo set SortOrder = 10 where TrainingVideoID = 2 and TenantID = 1
--Update dbo.TrainingVideo set SortOrder = 20 where TrainingVideoID = 3 and TenantID = 1
--Update dbo.TrainingVideo set SortOrder = 30 where TrainingVideoID = 44 and TenantID = 1
--Update dbo.TrainingVideo set SortOrder = 40 where TrainingVideoID = 77 and TenantID = 1
--Update dbo.TrainingVideo set SortOrder = 50 where TrainingVideoID = 88 and TenantID = 1
--Update dbo.TrainingVideo set SortOrder = 0 where TrainingVideoID = 4 and TenantID = 2
--Update dbo.TrainingVideo set SortOrder = 10 where TrainingVideoID = 5 and TenantID = 2
--Update dbo.TrainingVideo set SortOrder = 20 where TrainingVideoID = 6 and TenantID = 2
--Update dbo.TrainingVideo set SortOrder = 30 where TrainingVideoID = 37 and TenantID = 2
--Update dbo.TrainingVideo set SortOrder = 40 where TrainingVideoID = 70 and TenantID = 2
--Update dbo.TrainingVideo set SortOrder = 50 where TrainingVideoID = 81 and TenantID = 2
--Update dbo.TrainingVideo set SortOrder = 0 where TrainingVideoID = 7 and TenantID = 3
--Update dbo.TrainingVideo set SortOrder = 10 where TrainingVideoID = 8 and TenantID = 3
--Update dbo.TrainingVideo set SortOrder = 20 where TrainingVideoID = 9 and TenantID = 3
--Update dbo.TrainingVideo set SortOrder = 30 where TrainingVideoID = 43 and TenantID = 3
--Update dbo.TrainingVideo set SortOrder = 40 where TrainingVideoID = 76 and TenantID = 3
--Update dbo.TrainingVideo set SortOrder = 50 where TrainingVideoID = 87 and TenantID = 3
--Update dbo.TrainingVideo set SortOrder = 0 where TrainingVideoID = 10 and TenantID = 4
--Update dbo.TrainingVideo set SortOrder = 10 where TrainingVideoID = 11 and TenantID = 4
--Update dbo.TrainingVideo set SortOrder = 20 where TrainingVideoID = 12 and TenantID = 4
--Update dbo.TrainingVideo set SortOrder = 30 where TrainingVideoID = 40 and TenantID = 4
--Update dbo.TrainingVideo set SortOrder = 40 where TrainingVideoID = 73 and TenantID = 4
--Update dbo.TrainingVideo set SortOrder = 50 where TrainingVideoID = 84 and TenantID = 4
--Update dbo.TrainingVideo set SortOrder = 60 where TrainingVideoID = 89 and TenantID = 4
--Update dbo.TrainingVideo set SortOrder = 70 where TrainingVideoID = 90 and TenantID = 4
--Update dbo.TrainingVideo set SortOrder = 0 where TrainingVideoID = 13 and TenantID = 5
--Update dbo.TrainingVideo set SortOrder = 10 where TrainingVideoID = 14 and TenantID = 5
--Update dbo.TrainingVideo set SortOrder = 20 where TrainingVideoID = 15 and TenantID = 5
--Update dbo.TrainingVideo set SortOrder = 30 where TrainingVideoID = 38 and TenantID = 5
--Update dbo.TrainingVideo set SortOrder = 40 where TrainingVideoID = 71 and TenantID = 5
--Update dbo.TrainingVideo set SortOrder = 50 where TrainingVideoID = 82 and TenantID = 5
--Update dbo.TrainingVideo set SortOrder = 16 where TrainingVideoID = 16 and TenantID = 6
--Update dbo.TrainingVideo set SortOrder = 17 where TrainingVideoID = 17 and TenantID = 6
--Update dbo.TrainingVideo set SortOrder = 18 where TrainingVideoID = 18 and TenantID = 6
--Update dbo.TrainingVideo set SortOrder = 42 where TrainingVideoID = 42 and TenantID = 6
--Update dbo.TrainingVideo set SortOrder = 75 where TrainingVideoID = 75 and TenantID = 6
--Update dbo.TrainingVideo set SortOrder = 86 where TrainingVideoID = 86 and TenantID = 6
--Update dbo.TrainingVideo set SortOrder = 0 where TrainingVideoID = 52 and TenantID = 7
--Update dbo.TrainingVideo set SortOrder = 10 where TrainingVideoID = 53 and TenantID = 7
--Update dbo.TrainingVideo set SortOrder = 20 where TrainingVideoID = 54 and TenantID = 7
--Update dbo.TrainingVideo set SortOrder = 30 where TrainingVideoID = 55 and TenantID = 7
--Update dbo.TrainingVideo set SortOrder = 40 where TrainingVideoID = 56 and TenantID = 7
--Update dbo.TrainingVideo set SortOrder = 50 where TrainingVideoID = 57 and TenantID = 7
--Update dbo.TrainingVideo set SortOrder = 60 where TrainingVideoID = 58 and TenantID = 7
--Update dbo.TrainingVideo set SortOrder = 70 where TrainingVideoID = 59 and TenantID = 7
--Update dbo.TrainingVideo set SortOrder = 80 where TrainingVideoID = 60 and TenantID = 7
--Update dbo.TrainingVideo set SortOrder = 90 where TrainingVideoID = 61 and TenantID = 7
--Update dbo.TrainingVideo set SortOrder = 100 where TrainingVideoID = 62 and TenantID = 7
--Update dbo.TrainingVideo set SortOrder = 110 where TrainingVideoID = 63 and TenantID = 7
--Update dbo.TrainingVideo set SortOrder = 120 where TrainingVideoID = 64 and TenantID = 7
--Update dbo.TrainingVideo set SortOrder = 130 where TrainingVideoID = 65 and TenantID = 7
--Update dbo.TrainingVideo set SortOrder = 140 where TrainingVideoID = 66 and TenantID = 7
--Update dbo.TrainingVideo set SortOrder = 150 where TrainingVideoID = 74 and TenantID = 7
--Update dbo.TrainingVideo set SortOrder = 160 where TrainingVideoID = 85 and TenantID = 7
--Update dbo.TrainingVideo set SortOrder = 22 where TrainingVideoID = 22 and TenantID = 8
--Update dbo.TrainingVideo set SortOrder = 23 where TrainingVideoID = 23 and TenantID = 8
--Update dbo.TrainingVideo set SortOrder = 24 where TrainingVideoID = 24 and TenantID = 8
--Update dbo.TrainingVideo set SortOrder = 35 where TrainingVideoID = 35 and TenantID = 8
--Update dbo.TrainingVideo set SortOrder = 68 where TrainingVideoID = 68 and TenantID = 8
--Update dbo.TrainingVideo set SortOrder = 79 where TrainingVideoID = 79 and TenantID = 8
--Update dbo.TrainingVideo set SortOrder = 0 where TrainingVideoID = 28 and TenantID = 9
--Update dbo.TrainingVideo set SortOrder = 10 where TrainingVideoID = 29 and TenantID = 9
--Update dbo.TrainingVideo set SortOrder = 20 where TrainingVideoID = 30 and TenantID = 9
--Update dbo.TrainingVideo set SortOrder = 30 where TrainingVideoID = 31 and TenantID = 9
--Update dbo.TrainingVideo set SortOrder = 40 where TrainingVideoID = 39 and TenantID = 9
--Update dbo.TrainingVideo set SortOrder = 50 where TrainingVideoID = 72 and TenantID = 9
--Update dbo.TrainingVideo set SortOrder = 60 where TrainingVideoID = 83 and TenantID = 9
--Update dbo.TrainingVideo set SortOrder = 32 where TrainingVideoID = 32 and TenantID = 11
--Update dbo.TrainingVideo set SortOrder = 33 where TrainingVideoID = 33 and TenantID = 11
--Update dbo.TrainingVideo set SortOrder = 34 where TrainingVideoID = 34 and TenantID = 11
--Update dbo.TrainingVideo set SortOrder = 67 where TrainingVideoID = 67 and TenantID = 11
--Update dbo.TrainingVideo set SortOrder = 78 where TrainingVideoID = 78 and TenantID = 11
Update dbo.TrainingVideo set SortOrder = 36 where TrainingVideoID = 36 and TenantID = 12
Update dbo.TrainingVideo set SortOrder = 69 where TrainingVideoID = 69 and TenantID = 12
Update dbo.TrainingVideo set SortOrder = 80 where TrainingVideoID = 80 and TenantID = 12
--Update dbo.TrainingVideo set SortOrder = 0 where TrainingVideoID = 91 and TenantID = 13
--Update dbo.TrainingVideo set SortOrder = 10 where TrainingVideoID = 92 and TenantID = 13
--Update dbo.TrainingVideo set SortOrder = 20 where TrainingVideoID = 93 and TenantID = 13
--Update dbo.TrainingVideo set SortOrder = 30 where TrainingVideoID = 94 and TenantID = 13
--Update dbo.TrainingVideo set SortOrder = 40 where TrainingVideoID = 95 and TenantID = 13
--Update dbo.TrainingVideo set SortOrder = 50 where TrainingVideoID = 96 and TenantID = 13
--Update dbo.TrainingVideo set SortOrder = 60 where TrainingVideoID = 97 and TenantID = 13
--Update dbo.TrainingVideo set SortOrder = 70 where TrainingVideoID = 98 and TenantID = 13