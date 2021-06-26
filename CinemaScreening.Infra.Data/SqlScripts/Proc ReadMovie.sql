if object_id('ReadMovie') is not null
begin
	drop procedure ReadMovie;
end;
go

create proc ReadMovie
      @id int null
as
begin
	select * from dbo.Movie  m
			left join dbo.Director d on d.Id = m.DirectorId
			left join dbo.Genre g on g.Id = m.GenreId
			left join dbo.[Language] l on l.Id = m.LanguageId	
	where (m.Id=@id  or @id is null) 
	         order by m.Title;

end;
go