-- Sql file - RERUNNABLE
if not exists(select * from information_schema.tables where table_name = 'tblUnitTest_OtherA')
begin
	create table tblUnitTest_OtherA(ColA int)
end
