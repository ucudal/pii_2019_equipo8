Resumen App Técnicos

Introducción:

En Centro Ignis se busca realizar una aplicación que facilite la interacción entre los clientes y trabajadores (alumnos o exalumnos de la UCU). La aplicación, es una aplicación web, para asignar los proyectos de Ignis a los trabajadores interesados.

Desarrollo: 

Para resolver esta interacción con la aplicación web, creamos este modelo con clases y responsabilidades. Tenemos 3 tipos de usuarios (tipo User) que son Admin, Client y Worker. Aparte de los usuarios tenemos otras clases que colaboran en la interacción de Admin, Client y Worker, las cuales son Feedback, Contract, Sort y Create.

Al Admin le asignamos la responsabilidad de validar a los usuarios (Client o Worker). También tiene la responsabilidad devolver una lista de Workers disponibles con un rol especificado cuando la clase Client los solicita. Cuando Client pide la lista de Workers disponibles, Admin le manda un mensaje a Sort y este le devuelve un lista de Workers por el rol. El Admin conoce a los Workers. Cabe reconocer que la base de datos del framework ASP.NET crea el Admin una vez que se ejecuta el programa.

La clase Worker, tiene la responsabilidad de conocer y cambiar su rol y su nivel (avanzado o básico). También debe conocer los Feedback que hace Client.

En cuanto a la clase Client, este debe pedir al Admin una lista de Workers para el rol especificado y devolver un feedback al Worker con el que trabajó.

La clase Create tiene la responsabilidad de crear un User (Client o Worker ya que Admin se crea por defecto) cada vez que el usuario se registra. Una vez creado el User, debe avisar a Admin que se creó para este poder habilitarlo.





Casos de Uso:

- Iniciar sesion - todos
    App pide mail y contraseña
    Usuario completa mail y contraseña
    Inicia sesion si los datos son correctos o sino da error
- Cerrar sesion - todos
    Usuario hace click en cerrar sesion
    La app cierra sesion
- Crear Usuario - client y worker
    La app pide nombre, mail y password
    La app pide elegir tipo de usuario
    Si usuario elige worker:
        La app muestra una lista de roles
        El usuario debe elegir hasta 3 roles con su correspondiente nivel
- Habilitar/deshabilitar usuario - admin
    Admin debe ir a lista de usuarios
    Elegir uno y con un checkbox habilitar/deshabilitar usuario
- Ver usuario - admin
    Admin hace click en lista de usuarios
    La app muestra la lista de todos los usuarios
- Crear/editar rol - admin
    Admin hace click en lista de roles
    La app muestra la lista de roles
    Admin agrega o edita rol
- Ordenar lista de usuarios - admin
    Admin debe ir a la lista de usuarios.
    Admin hace click en “cosito” y elige el orden
    La app muestra la lista  con el orden elegido
Editar rol - worker
Worker va a editar rol
La app muestra la lista de roles total
User selecciona hasta 3 roles y guarda
Ver feedback - worker y admin
La app muestra la lista de feedbacks del usuario
Admin hace click en lista de usuarios
La app muestra la lista de todos los usuarios
Selecciona uno y dentro de su perfil se muestran sus feedbacks
Cambiar nivel - worker
Worker va a editar rol
La app muestra la lista de roles total
User elige el nivel dentro de los roles asignados y guarda
Consular proyecto - client
Escribir datos de proyecto y darle enviar
Solicitar proyecto - client
La app muestra una lista de roles y su nivel
Usuario elige un rol con su nivel
Responder solicitud - admin
App muestra el mensaje
Usuario hace click en responder solicitud
La app muestra lista de todos los workers para el rol y nivel especificados
Usuario elige workers y envia
Dar de alta contrato - client
App muestra lista de workers
User selecciona uno y hace click en Empezar proyecto
Escribir feedback - client
La app le pide al user que escriba los feedbacks pendientes
User hace click a escribir feedback
La app muestra lista de contratos pendientes
User selecciona el contrato correspondiente
La app pide que evalue del 1 al 5 una lista de opciones
User escribe el feedback y lo envia
Ver extension de contrato????????




