# GestionMecanica 🛠️

Sistema de gestión para un taller mecánico.  
Incluye la definición de una base de datos relacional con tablas normalizadas para manejar clientes, vehículos, empleados, servicios, repuestos, órdenes de trabajo, facturación y pagos.

## 📦 Estructura del proyecto

- `sql/DML-GestionMecanica.sql`: Script completo para crear la base de datos en SQL Server.
- `doc/Diagrama_ER_GestionMecanica.png`: Diagrama entidad-relación visual del modelo.
- `README.md`: Documentación inicial del proyecto.
- `.gitignore`: Exclusiones recomendadas para entornos .NET/C#.

## 🧱 Entidades principales

- **Cliente**: Información personal y de contacto.
- **Vehículo**: Relacionado con el cliente.
- **Empleado**: Encargado de realizar reparaciones.
- **Servicio / Repuesto**: Elementos facturables o necesarios para una orden.
- **Orden de trabajo**: Vincula todo lo anterior.
- **Factura y Pago**: Registro administrativo.

## 🚀 Próximos pasos

- Desarrollar backend en C# (Entity Framework / ADO.NET).
- Implementar lógica de negocio.
- Agregar interfaz (consola, WinForms o Web).

## 💡 Autor

Proyecto académico creado con fines prácticos para desarrollo backend e integración con bases de datos.
