GO
CREATE PROCEDURE SP_CATEGORIA_GET_ALL
AS        
BEGIN
 
 SELECT Id,Nombre,Descripcion FROM Categoria WHERE Activo = 1;

END   
GO

GO
CREATE PROCEDURE SP_CATEGORIA_GET_ID
 @Id INT
AS        
BEGIN
 
 SELECT Id,Nombre,Descripcion FROM Categoria WHERE Activo = 1 AND Id = @Id;

END   
GO

GO
CREATE PROCEDURE SP_CATEGORIA_POST
 @Nombre VARCHAR(100),
 @Descripcion VARCHAR(250)
AS        
BEGIN
 DECLARE @Id INT;
 INSERT INTO Categoria (Nombre, Descripcion) VALUES (@Nombre,@Descripcion);
 SET @Id = SCOPE_IDENTITY();
 SELECT Id,Nombre,Descripcion FROM Categoria WHERE Id=@Id;
END   
GO

GO
CREATE PROCEDURE SP_CATEGORIA_PUT
 @Id INT,
 @Nombre VARCHAR(100),
 @Descripcion VARCHAR(250)
AS        
BEGIN
 
 UPDATE Categoria SET Nombre=@Nombre, Descripcion=@Descripcion WHERE Id = @Id;

END   
GO

GO
CREATE PROCEDURE SP_CATEGORIA_DELETE
 @Id INT
AS        
BEGIN
 
 DELETE FROM Categoria WHERE Id = @Id;

END   
GO

GO
CREATE PROCEDURE SP_CATEGORIA_DELETE_LOGICO
 @Id INT
AS        
BEGIN
 
 UPDATE Categoria SET Activo = 0 WHERE Id = @Id;

END   
GO


GO
CREATE PROCEDURE SP_PRODUCTO_GET_ALL
AS        
BEGIN
 
 SELECT Id,Nombre,Descripcion,Unidades,IdCategoria FROM Producto WHERE Activo = 1;

END   
GO

GO
CREATE PROCEDURE SP_PRODUCTO_GET_ID
 @Id INT
AS        
BEGIN
 
 SELECT Id,Nombre,Descripcion,Unidades,IdCategoria FROM Producto WHERE Activo = 1 AND Id=@Id;

END   
GO

GO
CREATE PROCEDURE SP_PRODUCTO_GET_CATEGORIA
 @IdCategoria INT
AS        
BEGIN
 
 SELECT 
    p.Id,
    p.Nombre,
    p.Descripcion,
    p.Unidades,
    p.IdCategoria 
 FROM Producto AS p
 INNER JOIN Categoria AS c ON c.Id = p.IdCategoria
 WHERE p.Activo = 1 AND c.Id=@IdCategoria AND c.Activo = 1;

END   
GO

GO
CREATE PROCEDURE SP_PRODUCTO_POST
 @IdCategoria INT,
 @Nombre VARCHAR(200),
 @Descripcion VARCHAR(1000),
 @Unidades INT
AS        
BEGIN
 DECLARE @Id INT;
 INSERT INTO Producto (Nombre,Descripcion,Unidades,IdCategoria) VALUES (@Nombre,@Descripcion,@Unidades,@IdCategoria);
 SET @Id = SCOPE_IDENTITY();
 SELECT Id,Nombre,Descripcion,Unidades,IdCategoria FROM Producto WHERE Id=@Id;
END   
GO

GO
CREATE PROCEDURE SP_PRODUCTO_PUT
 @Id INT,
 @IdCategoria INT,
 @Nombre VARCHAR(200),
 @Descripcion VARCHAR(1000),
 @Unidades INT
AS        
BEGIN
 
 UPDATE Producto SET Nombre=@Nombre,Descripcion=@Descripcion,Unidades=@Unidades,IdCategoria=@IdCategoria
 WHERE Id=@Id;
 
END   
GO

GO
CREATE PROCEDURE SP_PRODUCTO_DELETE
 @Id INT
AS        
BEGIN
 
 DELETE FROM Producto WHERE Id = @Id;

END   
GO

GO
CREATE PROCEDURE SP_PRODUCTO_DELETE_LOGICO
 @Id INT
AS        
BEGIN
 
 UPDATE Producto SET Activo = 0 WHERE Id = @Id;
 
END   
GO
