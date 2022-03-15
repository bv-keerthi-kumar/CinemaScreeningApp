if object_id('UpdateMovie') is not null
begin
    drop proc  UpdateMovie;  
end; 
go

create proc UpdateMovie 
    @id int, 
    @title nvarchar(200),
	@rating int,
	@releaseDate datetime,
	@directorId int,
	@genreId int,
	@languageId int,
	@modifiedDate datetime,
	@modifiedBy nvarchar(50)

as
begin
    declare @result int = 1;  -- Presume success

    update dbo.Movie
    set 
		Title = @title,
		Rating = @rating,
		ReleaseDate = @releaseDate,
		DirectorId = @directorId,
		GenreId = @genreId,
		LanguageId = @languageId,
		ModifiedDate = @modifiedDate,
		@modifiedBy = @modifiedBy
    where 
        Id = @id;

	set @result = @@rowcount;
    return @result;
end;
go