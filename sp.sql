use Facturacion

alter table Articulos
drop column es_activo

CREATE PROCEDURE OBTENER_ARTICULOS
AS
BEGIN
SELECT * FROM Articulos
END

CREATE PROCEDURE AGREGAR_ARTICULOS
@nombre varchar(50),
@precio money,
@descripcion varchar(50)
AS
BEGIN
INSERT INTO Articulos(nombre, precio_unitario, descripcion)
VALUES(@nombre, @precio, @descripcion)
END

CREATE PROCEDURE ELIMINAR_PRODUCTO
@id int
AS
BEGIN
DELETE FROM Articulos WHERE id_articulo = @id
END


CREATE PROCEDURE BUSCAR_ARTICULO
@id int
AS
BEGIN
SELECT * FROM Articulos WHERE id_articulo = @id
END