if object_id('DeleteMovie') is not null
begin
     drop proc DeleteMovie;
end;
go

create proc DeleteMovie
       @id int
as
begin
	declare @result int =1;
	 declare @messages table (
        msg nvarchar(1000));

	if exists(select MovieId from dbo.MoviePromo where MovieId = @id)
	begin
		set @result = 0;
		insert into @messages
        values ('This Movie cannot be deleted because it is referenced by one or more MoviePromo.');
	end;

	if exists(select MovieId from dbo.DubbedVersion where MovieId = @id)
	begin
		set @result = 0;
		insert into @messages
        values ('This Movie cannot be deleted because it is referenced by one or more DubbedVersion.');
	end;

	if @result = 1
	begin
	   delete from dbo.Movie where Id = @id;

	   set @result = @@rowcount;
	end;

	select msg from @messages;
	return @result;
end;
go