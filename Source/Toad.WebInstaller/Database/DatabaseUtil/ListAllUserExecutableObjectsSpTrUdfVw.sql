--Note: This is embedded in the solution as a resource file
select db_name() as DatabaseName, ObjectType,  ObjectSchema, ObjectName
from (
	SELECT OBJECT_SCHEMA_NAME(id, db_id()) as ObjectSchema, name as ObjectName, 'PROCEDURE' AS objectType FROM sysobjects WHERE type = 'P' AND xtype='P' AND ObjectProperty (id, 'IsMSShipped') = 0 AND substring([name], 1, 9) not in ('sp_MSdel_','sp_MSins_','sp_MSupd_')
	UNION
	SELECT OBJECT_SCHEMA_NAME(id, db_id()) as ObjectSchema, name as ObjectName, 'VIEW' AS objectType FROM sysobjects WHERE type = 'V' AND xtype='V' AND ObjectProperty (id, 'IsMSShipped') = 0
	UNION
	SELECT OBJECT_SCHEMA_NAME(id, db_id()) as ObjectSchema, name as ObjectName, 'FUNCTION' AS objectType FROM sysobjects WHERE type IN ('IF', 'FN', 'TF') AND xtype IN ('IF', 'FN', 'TF') AND ObjectProperty (id, 'IsMSShipped') = 0
	UNION
	SELECT OBJECT_SCHEMA_NAME(id, db_id()) as ObjectSchema, name as ObjectName, 'TRIGGER' AS objectType FROM sysobjects WHERE type = 'TR' AND xtype = 'TR' AND ObjectProperty (id, 'IsMSShipped') = 0
) ob
where ob.ObjectName not in
(
'dm_stats',
'dt_addtosourcecontrol',
'dt_addtosourcecontrol_u',
'dt_adduserobject',
'dt_adduserobject_vcs',
'dt_checkinobject',
'dt_checkinobject_u',
'dt_checkoutobject',
'dt_checkoutobject_u',
'dt_displayoaerror',
'dt_displayoaerror_u',
'dt_droppropertiesbyid',
'dt_dropuserobjectbyid',
'dt_generateansiname',
'dt_getobjwithprop',
'dt_getobjwithprop_u',
'dt_verstamp006',
'dt_whocheckedout',
'dt_whocheckedout_u',
'fn_diagramobjects',
'sp_alterdiagram',
'sp_creatediagram',
'sp_dropdiagram',
'sp_helpdiagramdefinition',
'sp_helpdiagrams',
'sp_renamediagram',
'sp_upgraddiagrams'
)
