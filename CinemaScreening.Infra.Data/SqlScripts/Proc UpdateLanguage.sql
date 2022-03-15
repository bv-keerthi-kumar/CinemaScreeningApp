if object_id('UpdateLanguage') is not null
begin
    drop proc  UpdateLanguage;  
end; 
go

create proc UpdateLanguage 
    @id int, 
    @language nvarchar(50)

as
begin
    declare @result int = 1;  -- Presume success

    update dbo.[Language]
    set 
		[Language] = @language
    where 
        Id = @id;

	set @result = @@rowcount;
    return @result;
end;
go