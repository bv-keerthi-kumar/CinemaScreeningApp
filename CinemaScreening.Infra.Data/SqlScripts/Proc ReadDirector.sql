if object_id('ReadDirector') is not null
begin
	drop procedure ReadDirector;
end;
go

create proc ReadDirector
      @id int null
as
begin
	select * from dbo.Director d where (d.Id=@id or @id is null) 
	         order by Id

end;
go