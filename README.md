# Menú Cafetería

Aplicación de escritorio para armar pedidos de una cafetería, calcular el total, confirmar la compra y consultar pedidos anteriores.

## Requisitos

- Windows
- Visual Studio con **Desarrollo de escritorio de .NET** y el paquete de destino de **.NET Framework 4.8**

## Ejecutar

1. Abrí `MenuCafeteria.sln` en Visual Studio.
2. En el Explorador de soluciones, establecé `MenuCafeteria.WinForms` como proyecto de inicio.
3. Compilá la solución con **Ctrl+Mayús+B** y ejecutá con **F5**.

## Uso

- Elegí una bebida, un acompañamiento o ambos y agregalos al carrito.
- Podés quitar una línea del carrito antes de confirmar el pedido.
- **Finalizar pedido** muestra el total y guarda la venta si confirmás.
- **Historial de pedidos** muestra las compras guardadas.

## Capas

- `Frontend/MenuCafeteria.WinForms`: formularios Windows Forms y presentación.
- `Backend/MenuCafeteria.Backend`: productos, pedidos, reglas del carrito y persistencia.

Los pedidos confirmados se guardan en `%LOCALAPPDATA%\MenuCafeteria\pedidos.json` mediante JSON.

## Repositorio

https://github.com/munozagustinn/MenuCafeteria
