# Safe Clothing - Filtro
Proyecto webapi de cuatro capas
La empresa safe clothing desea realizar un backend que le permita llevar el control, registro y seguimiento de la producción de prendas de seguridad industrial, la empresa cuenta con diferentes tipos de prendas entre las cuales están las prendas resistentes al fuego (Ignifugas), resistentes a altos voltajes (Arco eléctrico). La empresa lo contrata a usted como experto backend para que cumpla con los siguientes requerimientos de desarrollo.

### Pre-requisitos 📋
MySQL<br>
NetCore 7.0
## Autenticación y autorización 
* Autenticación de un usuario registrado.<br>
  ```
  http://localhost:5000/api/User/token
  ```
  ![image](https://github.com/Marsh1100/Margie-Ropa/assets/131481951/d27f8379-24d0-4ac6-82aa-381a0c31d108)
<br><br>
* RefreshToken<br>
  ```
  http://localhost:5000/api/User/refresh-token
  ```
  ![image](https://github.com/Marsh1100/apiweb-vet/assets/131481951/84c29e09-a869-4217-b85b-348cf29fe919)<br>
* Autorización<br>
  En el siguiente enpoint es para eliminar un proveedor de la base de datos donde solo esta autorizado el Administrador
  ![image](https://github.com/Marsh1100/apiweb-vet/assets/131481951/230fda07-9ac6-409e-81eb-01f5d7773d16)
  ```
  http://localhost:5000/api/Proveedor/{id}
  ```
  <b>Nota</b>: Reemplazar {id}.<br>
  <br>Token de un usuario autorizado ✅.
  ![image](https://github.com/Marsh1100/Margie-Ropa/assets/131481951/40bdd231-628b-4d3e-b1e1-3da9fa36b066)
  Token de un usuario no autorizado  ❌.
  ![image](https://github.com/Marsh1100/Margie-Ropa/assets/131481951/2af1b32d-97a7-4fda-8ec8-49849e248a91)

## CRUD
CRUD en controladores. En el siguiente link [Peticiones](https://github.com/Marsh1100/Margie-Ropa/blob/main/x-safe-clothing.postman_collection.json), es un archivo contenido en el proyecto, puede importarse a Postman o Insomia para visualizar cada una de las peticiones realizadas.
## Paginación de peteciones get y Versionado
Se realizó la paginación en las peticiones get de los controladores en la version 1.1.<br>
Para el versionado se puede realizar mediante la query.  
```
http://localhost:5000/api/Cliente?ver=1.1
```
![image](https://github.com/Marsh1100/Margie-Ropa/assets/131481951/6b4bd6cf-f76a-4111-9036-448650442ecd)<br><br>
O mediante los headers. 
```
http://localhost:5000/api/Cliente
```
![image](https://github.com/Marsh1100/Margie-Ropa/assets/131481951/90fc0bd9-882c-4694-a491-a13df680a061)
<br><br>
Ejemplo de paginación implementando los parámetros index y cantidad de registros por página.  
```
http://localhost:5000/api/Cliente?pageIndex=2&pageSize=1
```
![image](https://github.com/Marsh1100/Margie-Ropa/assets/131481951/a9780fda-7411-4ed5-9662-b1d0c517c4d0)

## Ejecutando las consultas ⚙️📚
1.  Listar los proveedores que sean persona natural.
    ```
    http://localhost:5000/api/Proveedor/natural
    ```
    ![image](https://github.com/Marsh1100/Margie-Ropa/assets/131481951/0aec4eec-4e5e-470f-853f-b4134a5f8156)
2. Listar las prendas de una orden de producción cuyo estado sea en producción. El usuario debe ingresar el número de orden de producción.
    ```
    http://localhost:5000/api/Orden/prendasXorden/2
    ```
    ![image](https://github.com/Marsh1100/Margie-Ropa/assets/131481951/82fd8f56-22f7-40e6-b220-c0440d58b37f)

3. Listar las prendas agrupadas por el tipo de protección.
    ```
    http://localhost:5000/api/Prenda/prendasProteccion
    ```
    ![image](https://github.com/Marsh1100/Margie-Ropa/assets/131481951/a1ff7fe9-13d1-46a3-9cbc-8e3c2cddc5d1)
