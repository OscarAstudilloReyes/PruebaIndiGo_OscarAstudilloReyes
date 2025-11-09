## Prueba IndiGo -  Sistema de Productos y Ventas.
## Funcionalidades Implementadas

### Gestión de Productos (CRUD)
- **Crear** productos con código único
- **Buscar** productos por código
- **Actualizar** información de productos existentes
- **Eliminar** productos con confirmación
- **Listar** todos los productos en DataGrid

### Sistema de Ventas
- **Agregar items** a la venta con validación de stock
- **Cálculo automático** de totales por item y venta
- **Gestión de inventario** - descuenta stock automaticanemte

### Reportes de Ventas
- **Filtros por fecha** 

### Autenticación Básica
- **Login de usuario** (FrmLogin implementado)
- **Validación de credenciales** básica

## Arquitectura y Tecnologías

### Patrones de Diseño
- **MVP (Model-View-Presenter)** - Separación clara de responsabilidades
- **Repository Pattern** - Abstracción del acceso a datos
- **DTO Pattern** - Objetos de transferencia de datos
- **Dependency Injection** - Inyección por constructor
- **SOLID Principles** - Código mantenible y extensible

### Stack Tecnológico
- **Framework**: .NET 8.0 (Windows)
- **UI**: Windows Forms
- **Base de Datos**: SQL Server
- **ORM**: ADO.NET con SqlConnection
- **Lenguaje**: C# 12

### Estructura del Proyecto
```
PruebaTecnicaIndiGO/
├── Model/              # Entidades y DTOs
├── Repository/         # Acceso a datos
├── Presenter/          # Lógica de negocio
├── Views/              # Interfaces y Forms
├── Configuration/      # Configuración de conexión
```

## Base de Datos

### Tablas Principales
- **`oastudillo.Product`** - Productos (id, code, name, cost, stock, picture)
- **`oastudillo.Sale`** - Ventas (id, date, total)
- **`oastudillo.SaleItems`** - Items de venta (id, saleId, productId, quantity, totalValue)

## Instalación y Configuración

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/OscarAstudilloReyes/PruebaIndiGo_OscarAstudilloReyes.git
   cd PruebaTecnicaIndiGO
   ```

2. **Configurar Base de Datos**

```
--CREATE SCHEMA oastudillo AUTHORIZATION dbo;

CREATE TABLE  oastudillo.Product (
    id [int] PRIMARY KEY  IDENTITY(1,1) NOT NULL,
    name VARCHAR(255) NOT NULL,
	code VARCHAR(255) NOT NULL,
    cost DECIMAL(10, 2) NOT NULL,
    stock INT NOT NULL DEFAULT 0,
    picture VARCHAR(max)
);


CREATE TABLE oastudillo.Sale  (
    id INT PRIMARY KEY  IDENTITY(1,1) NOT NULL,
    date dateTime ,
    total DECIMAL(10, 2) NOT NULL
);

CREATE TABLE oastudillo.SaleItems  (
    id INT  PRIMARY KEY IDENTITY(1,1) NOT NULL,
    saleId INT NOT NULL,
    productId INT NOT NULL,
    quantity INT NOT NULL,
    totalValue DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (saleId) REFERENCES oastudillo.Sale(id),
    FOREIGN KEY (productId) REFERENCES oastudillo.Product(id)

--PRODUCTOS DE PRUEBA

  INSERT INTO oastudillo.Product (name, code, cost, stock, picture)
VALUES
    ('Paracetamol 500 mg - Caja x10',        'PARA-500',  3200.00, 120, NULL),
    ('Ibuprofeno 400 mg - Caja x20',         'IBU-400',   6500.00,  80, NULL),
    ('Amoxicilina 500 mg - Frasco x12 caps', 'AMOX-500', 18000.00,  30, NULL),
    ('Metformina 850 mg - Caja x30',         'MET-850',  12000.00,  60, NULL),
    ('Omeprazol 20 mg - Caja x30',           'OME-20',   15000.00,  50, NULL),
    ('Loratadina 10 mg - Caja x10',          'LOR-10',    8000.00, 100, NULL),
    ('Salbutamol inhalador 100 mcg',         'SALB-100', 45000.00,  25, NULL),
    ('Diclofenaco 50 mg - Caja x20',         'DIC-50',    7500.00,  70, NULL),
    ('Fluconazol 150 mg - Tableta única',    'FLU-150',   6000.00,  40, NULL),
    ('Aspirina 500 mg - Caja x20',           'ASP-500',   4500.00,  90, NULL
);
);
```


## Uso del Sistema

### Inicio de sesion

1. usuario: admin
2. contraseña:  1234 o cualquier valor

### Gestión de Productos
1. Abrir **FrmCrud** desde el menú principal
2. **Agregar**: Completar código y nombre → "Guardar"
3. **Buscar**: Escribir código → boton "buscar"
4. **Actualizar**: Buscar producto → modificar → "Guardar"
5. **Eliminar**: Escribir código → "Eliminar" → confirmar

### Procesar Ventas  
1. Abrir **FrmSales**  dar clic en "registrar ventas"
2. **Seleccionar producto** del ComboBox
3. **Escribir cantidad** (calcula total automáticamente)
4. **"Agregar"** a la rejilla (repite para múltiples productos)
5. **"Guardar venta"** - guarda venta

### Generar Reportes
1. Abrir **FrmReport**
2. **Seleccionar rango de fechas** (inicio y fin)
3. **"Filtrar"** → visualiza ventas del período
4. **"Ver Detalles"** en cualquier venta para productos específicos

## Funcionalidades Pendientes

### Autenticación JWT
- [ ] Implementar **JWT tokens** para autenticación segura


### Gestión de Imágenes  
- [ ] **Blob Storage** integration (Azure)
- [ ] **Upload de imágenes** de productos

