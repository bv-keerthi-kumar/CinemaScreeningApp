if object_id('AddMovie') is not null
begin
     drop proc AddMovie;
end;
go

create proc AddMovie
	@title nvarchar(200),
	@rating int,
	@releaseDate datetime,
	@directorId int,
	@genreId int,
	@languageId int,
    @createdDate datetime,
	@modifiedDate datetime,
	@createdBy nvarchar(50),
	@modifiedBy nvarchar(50),
	@newId int output
as
begin
	
	declare @result int = 1;
	declare @message nvarchar(250);
	set @newId = 0;

	if exists(select Id from dbo.Movie where Title = @title)
	begin
	     set @result =0;
		 set @message = 'There is already a movie with the name ' + @title + '.' ;
	end

	if @result = 1
	begin
		insert into dbo.Movie (
			Title,
			Rating,
			ReleaseDate,
			GenreId,
			DirectorId,
			LanguageId,
			CreatedDate,
			ModifiedDate,
			CreatedBy,
			ModifiedBy)
		select 		    
			@title,
			@rating,
			@releaseDate,
			@genreId,
			@directorId,
			@languageId,
			@createdDate,
			@modifiedDate,
			@createdBy,
			@modifiedBy;
		
		set @newId = scope_identity();
		set @result = @@rowcount;
	end;

	select @message;
	return @result;
end;
go