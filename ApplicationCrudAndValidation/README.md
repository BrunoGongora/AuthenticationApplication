# > README
## Descripcion
> Este proyecto es una aplicación de C# que contiene un servicio de autenticación de usuario mediante Microsoft 
Authentication. Incluye un formulario de inicio de sesión y un formulario de registro de usuarios. La aplicación 
está conectada a una base de datos local y para que funcione es necesario configurar el archivo appsettings en 
base a la base de datos que se tenga en SQL Server y hacer la migración. Tener presente que la aplicacion se 
encuentra desarrollada con .Net Core MVC, adicional es necesario instalar los paquetes de: 

##### EntityFramwerok SqlServer
##### EntityFramwerok Tools

> Tambien es importante que la cadena de conexion este conectada a la base de datos local para que el 
proyecto pueda funcionar. 

######  "ConnectionStrings": {
    "DefaultConnection": "Server=BRUNOGONGORA\\SQLEXPRESS;Database=MenuData;Trusted_Connection=True;MultipleActiveResultSets=true;"
  },

> Una vez el usuario tiene una cuenta, podrá acceder a la tabla principal de un menú en el cual podrá 
agregar nuevos productos, eliminar o editar. También podrá buscar por nombre y, a medida que se agreguen 
o eliminen productos, se actualizarán automáticamente en la base de datos.

> La aplicación también incluye un botón de cerrar sesión, el cual elimina las cookies una vez el usuario 
cierre sesión.

> Antes de ejecutar la aplicación, asegurarse de configurar correctamente el archivo appsettings para la 
conexión a la base de datos local y hacer la migración correspondiente.

> La aplicacion cuenta con todos sus respectivos controladores para el manejo de la aplicacion, tambien 
maneja un sistema de validacion para verificar si el usuario se encuentra registrado en la base de datos, en caso de que no este registrado lo llevara a la vista para que se registre, pero si el usuario ya tiene una cuenta entonces lo llevara a la pagina principal para que inicie sesion, ambas metodologias mostraran el respetivo label a el usuario para que el usuario sepa que le hace falta. 

**Usuarios para probar:**

###### Email: bruno@demo.com Password: 123
###### Email bruno2@demo,com Password: 12345
###### Email: bruno3@demo.com Password 123456789

**Author: Bruno Gongora**