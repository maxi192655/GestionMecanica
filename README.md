# GestionMecanica 🛠️

Sistema de gestión para un taller mecánico.  
Incluye la definición de una base de datos relacional con tablas normalizadas para manejar clientes, vehículos, empleados, servicios, repuestos, órdenes de trabajo, facturación y pagos.


# 🚗 GestionMecanica

Este proyecto es una aplicación de gestión para un taller mecánico. Permite registrar y administrar información sobre clientes, vehículos, reparaciones, facturación, mecánicos y más.

## 📌 Objetivos

- Llevar control de órdenes de reparación.
- Asignar mecánicos y registrar especialidades.
- Gestionar repuestos y facturas.
- Registrar clientes y vehículos.
- Consultar pagos y métodos de pago.

---


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

---

## 🧱 Tecnologías utilizadas

- Lenguaje: **C# (.NET)**
- IDE: **Visual Studio 2022**
- Base de datos: **SQL Server**
- ORM: (por definir, posible uso de Entity Framework)
- Versionado: **Git + GitHub**

---

## 🛠 Instalación y configuración

1. Clonar el repositorio:
	   ```bash
   git clone https://github.com/maxi192655/GestionMecanica.git

## 💡 Autor
Proyecto académico creado con fines prácticos para desarrollo backend e integración con bases de datos.