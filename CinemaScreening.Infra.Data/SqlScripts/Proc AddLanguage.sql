if object_id('AddLanguage') is not null
begin
     drop proc AddLanguage;
end;
go

create proc AddLanguage
	@language nvarchar(50),
	@newId int output
as
begin
	
	declare @result int = 1;
	declare @message nvarchar(100);
	set @newId = 0;

	if exists(select * from dbo.[Language] where [Language] = @language)
	begin
	     set @result =0;
		 set @message = 'There is already a Language with the name '  + @language + '.' ;
	end

	if @result = 1
	begin
		insert into dbo.[Language] (
				[Language])
		select 		    
			@language;
		
		set @newId = scope_identity();
		set @result = @@rowcount;
	end;

	select @message;
	return @result;
end;
go