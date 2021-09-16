-- Sql file - RERUNNABLE
if not exists(select * from information_schema.tables where table_name = 'tblUnitTest_OtherB')
begin
	create table tblUnitTest_OtherB(ColA int)
end
