﻿<h1 align="center">🛠️ Instalación y ejecución</h1>

***
Esta aplicación fue desarrollada para ejecutarse en una PC con un [Arduino Nano](https://en.wikipedia.org/wiki/Arduino_Nano) conectado al puerto serie **COM4** y configurado con el archivo ***Arduino.ino*** dentro de la carpeta de ***Resources\Arduino***. Sin embargo, el proyecto está preparado para ser ejecutado también en un entorno de pruebas, sin la necesidad de contar con el Arduino.

## 🧰 <u>Dependencias</u>

<ul style="list-style: none; padding-left: 0;">
  <li><span style="text-align:center;display: inline-block; width: 2em;">⚙️</span><a href="https://dotnet.microsoft.com/en-us/download/dotnet/6.0">.NET 6 SDK</a></li>
  <li><span style="text-align:center;display: inline-block; width: 2em;">🛢️</span><a href="https://www.microsoft.com/en-us/download/details.aspx?id=56042">SQL Server 2012</a> <code>(o superior)</code> <code>(instancia local o remota)</code></li>
  <li><span style="text-align:center;display: inline-block; width: 2em;">🏗️</span><a href="https://www.microsoft.com/en-us/download/details.aspx?id=48159">MSBuild 15</a> <code>(o superior)</code></li>
  <li><span style="text-align:center;display: inline-block; width: 2em;">📦</span><a href="https://learn.microsoft.com/en-us/sql/tools/sqlpackage/sqlpackage-download?view=sql-server-2016">sqlpackage</a> <code>(o compatible con la versión de .NET)</code></li>
  <li><span style="text-align:center;display: inline-block; width: 2em;">📻</span><a href="https://www.videolan.org/">VLC Player</a> <code>(debe estar instalado en su ruta predeterminada)</code></li>
</ul>

## 📥 <u>Clonar el repositorio</u>
```
git clone https://github.com/ribriel2911/Eve.API
```

## 🧮 <u>Publicar Base de Datos</u>
Se debe compilar y publicar el proyecto de base de datos que contiene las url de los streams de radios (algunos pueden no funcionar debido a que se han dado de baja o cambiado de dominio). Se puede actualizar o modificar desde base de datos luego de la publicación.

- ### Compilación 
```
cd Eve.API\Resources\DataBase
msbuild Resources.DataBase.sqlproj /p:Configuration=Release
```
Si no se reconoce el comando msbuild luego de la instalación se puede o bien ejecutar con PowerShell desde la ruta de instalación de msbuild, en mi caso:

``` 
& "C:\Program Files (x86)\MSBuild\15.0\Bin" Resources.DataBase.sqlproj /p:Configuration=Release
```

O bien configurar el path, reiniciar la consola y volver a ejecutar el comando de compilación.

```
[Environment]::SetEnvironmentVariable("Path", $env:Path + ";C:\Program Files (x86)\MSBuild\15.0\Bin", [EnvironmentVariableTarget]::Machine)
```
- ### Publicación

```
sqlpackage /Action:Publish /SourceFile:"bin\Release\Resources.DataBase.dacpac" /TargetConnectionString:"Server=localhost\SQLEXPRESS;Database=EveAppDataBase;Trusted_Connection=True;TrustServerCertificate=True;"
```

## 🔧 <u>Configurar variables de entorno</u>

Si se va a ejecutar desde un acceso remoto y se tiene el Ardunio Nano configurado, se puede agregar una ruta de acceso público configurada reemplazándola por variable **API_PROD_URL** del archivo ***launchSettings.json*** de la carpeta ***Properties***. `(de lo contrario, se debe eliminar la variable del archivo)`.

```
"applicationUrl": "http://localhost:5131;API_PROD_URL",
```

## 🚀 <u>Ejecutar API (Desarrollo)</u>
De no contar con el Arduino configurado y para poder probar las respuestas del controlador del gabinete, recomiendo ejecutar la aplicación en modo desarrollo, ya que este ejecuta una implementación simulada de las respuestas que daría el Arduino.

```
cd ..\..
dotnet run --environment Development
```

## 🛰️ <u>Ejecutar API (Producción)</u>

```
cd ..\..
dotnet run --environment Production
```