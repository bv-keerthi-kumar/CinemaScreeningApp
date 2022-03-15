if object_id('UpdateGenre') is not null
begin
    drop proc  UpdateGenre;  
end; 
go

create proc UpdateGenre 
    @id int, 
    @name nvarchar(50)

as
begin
    declare @result int = 1;  -- Presume success

    update dbo.Genre
    set 
        [Name] = @name
    where 
        Id = @id;

	set @result = @@rowcount;
    return @result;
end;
go