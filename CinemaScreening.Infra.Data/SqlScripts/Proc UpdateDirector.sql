if object_id('UpdateDirector') is not null
begin
    drop proc  UpdateDirector;  
end; 
go

create proc UpdateDirector 
    @id int, 
    @firstName nvarchar(50), 
    @lastName nvarchar(50)

as
begin
    declare @result int = 1;  -- Presume success

    update dbo.Director
    set 
        FirstName = @firstName,
		LastName = @lastName
    where 
        Id = @id;

	set @result = @@rowcount;
    return @result;
end;
go