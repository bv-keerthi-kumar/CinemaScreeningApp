if object_id('AddGenre') is not null
begin
     drop proc AddGenre;
end;
go

create proc AddGenre
	@name nvarchar(50),
	@newId int output
as
begin
	
	declare @result int = 1;
	declare @message nvarchar(100);
	set @newId = 0;

	if exists(select * from dbo.Genre where [Name]=@name)
	begin
	     set @result =0;
		 set @message = 'There is already a Genre with the name '  + @name + '.' ;
	end

	if @result = 1
	begin
		insert into dbo.Genre (
					[Name])
		select 		    
			@name
		
		set @newId = scope_identity();
		set @result = @@rowcount;
	end;

	select @message;
	return @result;
end;
go