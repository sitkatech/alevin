SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[procNotThereSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[procNotThereSelect]
GO

CREATE PROCEDURE	dbo.procNotThereSelect
AS
BEGIN

	[][][][][][][][]

END