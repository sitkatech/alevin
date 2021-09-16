SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[procAbcSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[procAbcSelect]
GO

CREATE PROCEDURE	dbo.procAbcSelect
AS
BEGIN

	SELECT 'a', 'b', 'c'

END