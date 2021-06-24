if object_id('AddDirector') is not null
begin
     drop proc AddDirector;
end;
go

create proc AddDirector
	@firstName nvarchar(50),
	@lastName nvarchar(50),
	@newId int output
as
begin
	
	declare @result int = 1;
	declare @message nvarchar(100);
	set @newId = 0;

	if exists(select Id from dbo.Director where FirstName =@firstName and LastName =@lastName)
	begin
	     set @result =0;
		 set @message = 'There is already a director with the name ' + @firstName + ' ' + @lastName + '.' ;
	end

	if @result = 1
	begin
		insert into dbo.Director (
			FirstName,
			LastName)
		select 		    
			@firstName,
			@lastName;
		
		set @newId = scope_identity();
		set @result = @@rowcount;
	end;

	select @message;
	return @result;
end;
go