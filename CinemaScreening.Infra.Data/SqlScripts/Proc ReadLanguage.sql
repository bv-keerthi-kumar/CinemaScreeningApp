if object_id('ReadLanguage') is not null
begin
	drop procedure ReadLanguage;
end;
go

create proc ReadLanguage
      @id int null
as
begin
	select * from dbo.[Language]  where (Id=@id or @id is null) 
	         order by Id;

end;
go