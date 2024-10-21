Nombre: Jesús Ramírez Serrano
Ruta del proyecto en GIT: https://github.com/jrsdevs/pruebaNuxiba

1.- Crear contenedor docker: docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourStrong!Passw0rd'    -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2019-latest
2.- ¿Cómo me conecto a la instancia de SQL Server creada con la instruccion anterior?
	Server Name: [SERVICIO_LOCAL_SQL],[PUERTO]
	usuario: sa
	contraseña: YourStrong!Passw0rd
3.- Restaurar la base con el archivo nuxiba.bak, es un respaldo que contien las tablas e informacion para el consumo de las apis.
4.- Al proyecto, habrá que cambiar la cadena de conexion a las propiedades de tu servidor sql, la cadena de conexion se encuentra en el archvo appsettings.json
5.- Rutas api login:
    obtener todos los login:[GET]: /api/login
	insertar un login: [POST]: /api/login, recibe un json con el siguiente formato: 
																					{																					  
																					  "user_id": 0,
																					  "extencion": 0,
																					  "tipoMov": 0,
																					  "fecha": "2024-10-21T04:54:23.783Z"
																					}
   actualizar un login: [PUT] /api/login/{id} y recibe un json con el siguiente formato: 
																					{
																						"logId": 0,
																						"user_id": 0,
																						"extencion": 0,
																						"tipoMov": 0,
																						"fecha": "2024-10-21T04:55:10.838Z"
																					}
   elimiar un login: [DELETE] /api/login/{id}

6- descargar el archivo CSV

