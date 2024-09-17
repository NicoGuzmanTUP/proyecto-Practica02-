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
