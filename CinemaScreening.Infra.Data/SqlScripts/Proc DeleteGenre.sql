if object_id('DeleteGenre') is not null
begin
     drop proc DeleteGenre;
end;
go

create proc DeleteGenre
       @id int
as
begin
	declare @result int =1;
	declare @messages table (
        msg nvarchar(1000));

	if exists(select * from dbo.Movie where GenreId = @id)
	begin
		set @result = 0;
		insert into @messages
        values ('This Genre cannot be deleted because it is referenced by one or more Movies.');
	end;

	if @result = 1
	begin
	   delete from dbo.Genre where Id = @id;

	   set @result = @@rowcount;
	end;

	select msg from @message;
	return @result;
end;
go