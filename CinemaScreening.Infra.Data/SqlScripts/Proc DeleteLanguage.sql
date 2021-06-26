if object_id('DeleteLanguage') is not null
begin
     drop proc DeleteLanguage;
end;
go

create proc DeleteLanguage
       @id int
as
begin
	declare @result int =1;
	declare @messages table (
        msg nvarchar(1000));

	if exists(select * from dbo.Movie where LanguageId = @id)
	begin
		set @result = 0;
		insert into @messages
        values ( 'This Language cannot be deleted because it is referenced by one or more Movies.');
	end;

	if exists(select * from dbo.MoviePromo where LanguageId = @id)
	begin
		set @result = 0;
		insert into @messages
        values ( 'This Language cannot be deleted because it is referenced by one or more MoviePromo.');
	end;

	if exists(select * from dbo.DubbedVersion where LanguageId = @id)
	begin
		set @result = 0;
		insert into @messages
        values ( 'This Language cannot be deleted because it is referenced by one or more DubbedVersion.');
	end;

	if @result = 1
	begin
	   delete from dbo.[Language] where Id = @id;

	   set @result = @@rowcount;
	end;

	select msg from @message;
	return @result;
end;
go