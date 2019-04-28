Resumen de la aplicación:
Introducción:
En Centro Ignis busca realizar una aplicación que facilite la interacción entre los clientes y trabajadores (alumnos o exalumnos de la UCU).
La aplicación, es una aplicación web, para asignar los proyectos de Ignis a los trabajadores interesados.

Desarrollo:
Para resolver esta interacción con la aplicacion web, creamos este modelo con clases y responsabilidades:
Tenemos 3 tipos de usuarios (tipo User) que son Admin, Client y Worker. Al Admin le asignamos la responsabilidad de validar a los Worker y a los Client.
También tiene la responsabilidad devolver una lista de Workers disponibles cuando la clase Client los solicita. El Admin conoce a los Workers.
La clase Worker, tiene la responsabilidad de conocer y cambiar su rol y su nivel (avanzado o basico).
En cuanto a la clase Client, este debe pedir al Admin una lista de Workers para el rol especificado y devolver un feedback al Worker con el que trabajó.



