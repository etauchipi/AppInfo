# AppInfo

## 1. Descripción del Proyecto
**AppInfo** es una biblioteca de clases (Class Library) ligera desarrollada en C# que facilita la extracción de metadatos y atributos del ensamblado en ejecución (Assembly). A través de la clase y la interfaz `IAppInfo`, proporciona una forma estandarizada y sencilla de obtener información de la aplicación como el título, descripción, compañía, derechos de autor (copyright), marca registrada y versión.

## 2. Tech Stack (Pila Tecnológica)
Basado en el análisis del código fuente, el proyecto utiliza las siguientes tecnologías:
- **Lenguaje:** C#
- **Framework:** .NET Framework 4.5
- **IDE Base:** Microsoft Visual Studio (creado originalmente con la versión 2013)
- **Conceptos y Librerías Clave:** `System.Reflection` (utilizado para inspeccionar los metadatos de los ensamblados en tiempo de ejecución).

## 3. Instalación y Configuración del Entorno
Al ser una biblioteca de clases (.dll), no se ejecuta por sí sola, sino que se integra como una dependencia en otro proyecto de .NET.

### Prerrequisitos
- Tener instalado [Visual Studio](https://visualstudio.microsoft.com/) (2013 o una versión más reciente).
- Tener instalado .NET Framework 4.5 o superior.

### Pasos para compilación local
1. Clona este repositorio en tu máquina local:
   ```bash
   git clone <URL_DEL_REPOSITORIO>
   cd <NOMBRE_DEL_REPOSITORIO>
   ```
2. Abre el archivo de la solución `AppInfo.sln` haciendo doble clic sobre él o desde Visual Studio (`File > Open > Project/Solution`).
3. Para compilar el proyecto:
   - En Visual Studio, ve al menú superior y selecciona **Build > Build Solution** (o usa el atajo `Ctrl + Shift + B`).
   - Alternativamente, si usas MSBuild desde línea de comandos:
     ```bash
     msbuild AppInfo.sln /p:Configuration=Release
     ```
4. Una vez compilado correctamente, encontrarás el archivo compilado `AppInfo.dll` en la ruta `AppInfo/bin/Debug/` o `AppInfo/bin/Release/` (dependiendo de la configuración elegida).

## 4. Estructura de Carpetas
La estructura principal del repositorio se compone de los siguientes elementos:

```text
.
├── AppInfo.sln                  # Archivo principal de la Solución de Visual Studio.
└── AppInfo/                     # Directorio principal del proyecto.
    ├── AppInfo.csproj           # Archivo del proyecto de C# que define configuración y referencias.
    ├── AppInfo.cs               # Archivo fuente que contiene la interfaz IAppInfo y la clase AppInfo con la lógica principal.
    └── Properties/              # Directorio de propiedades del proyecto.
        └── AssemblyInfo.cs      # Archivo que contiene los metadatos y atributos del propio ensamblado AppInfo.
```

## 5. Guía Básica de Uso
Para hacer uso de la biblioteca en tu proyecto principal, sigue estos pasos:

1. Agrega la referencia de la DLL compilada (`AppInfo.dll`) a tu proyecto de .NET, o incluye el proyecto `AppInfo.csproj` dentro de tu solución y referéncialo.
2. Utiliza el espacio de nombres (namespace) de la biblioteca.

### Ejemplo de código

```csharp
using System;
using AppInfo; // Importar el namespace de la biblioteca

namespace MiProyectoEjemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciar la clase AppInfo usando la interfaz
            IAppInfo info = new AppInfo.AppInfo();

            // Extraer y mostrar la información del ensamblado en ejecución
            Console.WriteLine("Título: " + info.Title);
            Console.WriteLine("Descripción: " + info.Description);
            Console.WriteLine("Compañía: " + info.Company);
            Console.WriteLine("Copyright: " + info.Copyright);
            Console.WriteLine("Marca Registrada: " + info.Trademark);
            Console.WriteLine("Versión: " + info.Version);

            Console.ReadLine();
        }
    }
}
```

**⚠️ Nota Importante:**
La clase `AppInfo` utiliza `System.Reflection.Assembly.GetExecutingAssembly()` en su constructor. Esto significa que extraerá los atributos del ensamblado donde la clase **AppInfo fue compilada**. Si necesitas que extraiga la información del proyecto que la invoca (tu aplicación principal), es posible que requieras extender la clase para que acepte `Assembly.GetCallingAssembly()` o `Assembly.GetEntryAssembly()` en lugar de utilizar solo `GetExecutingAssembly()`.