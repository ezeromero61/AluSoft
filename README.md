<div align="center">

# AluSoft

**Sistema de gestión integral para empresas de aberturas de aluminio**

![C#](https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET_Framework_4.7.2-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows_Forms-0078D4?style=for-the-badge&logo=windows&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)

<img src="docs/capturas/login.png" alt="Pantalla de inicio de sesión de AluSoft" width="820">

</div>

## El problema

Muchas fábricas y comercios de aberturas todavía gestionan presupuestos, stock, producción y cobros con papel o planillas sueltas. Eso genera errores en los presupuestos, stock incierto, pedidos que se pierden y una fuerte dependencia de lo que recuerda cada empleado.

AluSoft centraliza todo ese circuito en una sola aplicación de escritorio, con acceso según el rol de cada usuario.

## Qué hace

| Área | Funciones |
| --- | --- |
| **Comercial** | Clientes, presupuestos de cliente, pedidos, ventas, facturas y cobros |
| **Producción** | Órdenes de producción y seguimiento del estado de cada trabajo |
| **Stock** | Inventario, catálogo de productos, stock y lista de precios |
| **Reaprovisionamiento** | Proveedores, presupuestos de proveedores, pedidos de reaprovisionamiento, remitos, compras y pagos |
| **Reportes** | Exportación a Excel de la información del negocio |
| **Seguridad** | Inicio de sesión con credenciales cifradas, menú por rol, bitácora, backup y control de integridad |

### Ciclo de venta

`Cliente` → `Presupuesto` → `Pedido` → `Orden de producción` → `Estado de producción` → `Venta y factura` → `Cobro`

### Ciclo de compra

`Proveedor` → `Presupuesto del proveedor` → `Pedido de reaprovisionamiento` → `Remito` → `Compra` → `Stock` → `Pago`

## Capturas

| | |
| --- | --- |
| <img src="docs/capturas/menu.png" alt="Menú principal"> **Menú principal por rol** | <img src="docs/capturas/presupuesto.png" alt="Presupuesto de cliente"> **Presupuesto de cliente** |
| <img src="docs/capturas/produccion.png" alt="Estado de producción"> **Estado de producción** | <img src="docs/capturas/stock.png" alt="Gestión de stock"> **Gestión de stock** |
| <img src="docs/capturas/compras.png" alt="Gestión de compras"> **Compras a proveedores** | <img src="docs/capturas/cobros.png" alt="Gestión de cobros"> **Cobros** |
| <img src="docs/capturas/bitacora.png" alt="Bitácora"> **Bitácora de operaciones** | <img src="docs/capturas/integridad.png" alt="Aviso de integridad"> **Control de integridad** |

## Roles

| Rol | Uso principal |
| --- | --- |
| **Gerente** | Supervisión general, reportes y decisiones |
| **Administrativo** | Clientes, presupuestos, facturación, compras y pagos |
| **Supervisor** | Órdenes y estados de producción |
| **Soporte técnico** | Usuarios, bitácora, backup y dígitos verificadores |

## Seguridad

- **Credenciales cifradas:** usuario y contraseña nunca se guardan en texto plano.
- **Bitácora:** cada operación importante queda registrada con fecha, hora, acción, tabla y usuario, y se puede filtrar y exportar a Excel.
- **Backup y restauración:** copia completa de la base (estructura y datos) en formato `.bacpac`.
- **Dígitos verificadores (DVH / DVV):** al iniciar sesión se verifica que los datos no hayan sido modificados por fuera del sistema. Si hay diferencias, solo Soporte técnico puede seguir operando hasta resolverlas.
- **Idiomas:** el selector de idioma (español, English, Français, Português) está implementado como demo en Gestión de Clientes.

## Arquitectura

Aplicación de escritorio en capas:

```
VISTA (Windows Forms)
   │
BLL   ── lógica de negocio
   │
DAL   ── acceso a datos mediante stored procedures (clsAcceso)
   │
SQL Server

BE    ── entidades compartidas entre capas
```

- Todo el acceso a datos se hace con **stored procedures**.
- Librerías externas: **ClosedXML** (exportación a Excel) y **DacFx** (backup).

## Requisitos e instalación

**Requisitos**
- Windows con **.NET Framework 4.7.2**
- **SQL Server** local con autenticación de Windows

**Pasos**
1. Restaurar la base de datos de AluSoft en SQL Server.
2. Ejecutar el instalador del proyecto `Alusoft-Instalador`, o abrir la solución en Visual Studio y compilarla.
3. Iniciar sesión con un usuario existente.

## Equipo

Proyecto final de **Prácticas Profesionalizantes 3**, Tecnicatura Superior en Análisis de Sistemas, **ISFT N° 172 "Alan Turing"**, Lomas de Zamora.

- Danel Fretes  danelfretes94@gmail.com
- Lautaro Villarreal  lautaroemmanuel.villa@gmail.com
- Brian Villarreal  brianvillarreal2450@gmail.com
- Thomas Velázquez  thomyvelazquez84@gmail.com
- Ezequiel Romero ezeromero61@gmail.com

Profesores: Javier Pozzo y Rocío Vargas.
