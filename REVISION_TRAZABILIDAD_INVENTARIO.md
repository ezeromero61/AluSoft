# Revisión de trazabilidad: Inventario, Stock, Catálogo y Lista de precios

## Relaciones revisadas

1. **Inventario** registra la identidad y características del elemento (`IdInventario`).
2. **Stock** vincula el elemento mediante `IdInventario` y mantiene `CantidadActual`.
3. **Catálogo** se vincula con Inventario mediante `IdInventario`; al cargarlo, ahora toma la cantidad actual desde Stock.
4. **Lista de precios** se vincula con Catálogo mediante `IdCatalogo`; al cargarla, ahora toma el precio unitario del Catálogo.

## Cambios incluidos

- `Vista/frm12_Catalogo_1.cs`: combo de elementos abastecido desde Stock; muestra ID, nombre y existencia; al seleccionar, completa la cantidad desde `CantidadActual`. El campo de cantidad queda de solo lectura para evitar diferencias respecto del registro elegido. La grilla muestra registros de Catálogo.
- `Vista/frm13_ListaPrecios_1.cs`: combo abastecido desde Catálogo (incluye los artículos que todavía no tienen historial en Lista de precios); muestra ID de catálogo y nombre; al seleccionar, completa `PrecioUnitario`. El precio sigue editable para permitir cargar un valor distinto. La acción “Ver tabla” muestra registros de Lista de precios.
- No se agregaron columnas, procedimientos almacenados ni cambios al esquema. Los métodos DAL ya guardaban las relaciones por `IdInventario` e `IdCatalogo`.

## Orden de carga

Cargar primero Inventario, después su Stock, luego Catálogo y por último Lista de precios. Si un elemento no tiene registro de Stock, no aparecerá en el combo de alta de Catálogo.

## Nota sobre cantidades

La cantidad se copia al registro de Catálogo en el momento de guardarlo. Si posteriormente cambia Stock, el valor ya guardado en Catálogo no se actualiza automáticamente; para mostrar siempre una existencia en vivo haría falta consultar Stock al mostrar el Catálogo o sincronizar las tablas en la base de datos.
