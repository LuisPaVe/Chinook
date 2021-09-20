CREATE PROCEDURE [dbo].[usp_DeleteArtist]    
@artistId NVARCHAR(120)    
AS    
BEGIN    
 Delete FROM Artist      
 WHERE ArtistId  = @artistId    
END 

go
CREATE PROCEDURE usp_UpdateArtist  
(  
@artistId INT,  
@name NVARCHAR(120)  
)  
AS  
BEGIN  
 UPDATE Artist SET [Name]=@name WHERE ArtistId=@artistId  
END
go
  
CREATE PROCEDURE [dbo].[usp_InsertArtist]  
@name NVARCHAR(120)  
AS  
BEGIN  
 INSERT INTO Artist(Name)   
 VALUES(@name)    
   
 SELECT SCOPE_IDENTITY()  
END  
go
    
CREATE PROCEDURE [dbo].[usp_GetOne]    
@artistId NVARCHAR(120)    
AS    
BEGIN    
 SELECT ArtistId,Name FROM Artist NOLOCK     
 WHERE ArtistId  = @artistId    
END 
go
  
CREATE PROCEDURE [dbo].[usp_GetArtist]  
@name NVARCHAR(120)  
AS  
BEGIN  
 SELECT ArtistId,Name FROM Artist NOLOCK   
 WHERE Name LIKE @name  
END  