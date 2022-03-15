if object_id('ReadGenre') is not null
begin
	drop procedure ReadGenre;
end;
go

create proc ReadGenre
      @id int null
as
begin
	select * from dbo.Genre g where (g.Id=@id or @id is null) 
	         order by Id

end;
go