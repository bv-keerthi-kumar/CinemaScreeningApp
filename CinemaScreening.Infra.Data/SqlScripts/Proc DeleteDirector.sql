﻿if object_id('DeleteDirector') is not null
begin
     drop proc DeleteDirector;
end;
go

create proc DeleteDirector
       @id int
as
begin
	declare @result int =1;
	declare @message varchar(100);

	if exists(select directorId from dbo.Movie where DirectorId = @id)
	begin
		set @result = 0;
		set @message = 'This Director cannot be deleted because it is referenced by one or more Movies.' ;
	end;

	if @result = 1
	begin
	   delete from dbo.Director where Id = @id;

	   set @result = @@rowcount;
	end;

	select @message;
	return @result;
end;
go