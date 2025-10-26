<h1 align="center">📻 Controlador de Radio</h1>

***
<div style="display:flex">
  <h2 style="padding-right:10px">▶️ Play</h2>
  <h4><code style='color:DarkOrange'>POST</code></h4> 
</div>

Reanuda o inicializa una lista de reproducción nueva con las radios disponibles en base de datos segun los parametros de entrada. De no poder reproducir la pista se remueve de la lista de reproducción y se agrega marca en base de datos.

```
http://localhost:5131/api/Radio/Play
```

<h4>📥 Parámetros de Entrada</h4> 

|  | Nombre | Tipo | Obligatorio | Descripción | Default |
| :-: | --- | :-: | :-: | --- | :-: |
| 🎚️ | volume | *number* | NO | Volumen al que se iniciara la reproducción | 0 |
| 🔀 | aleatory | *boolean* | NO | Flag indicador de si se debe reproducir una radio aleatoria | false |
| 🔁 | repeatMode | *number* | NO | Modo de repetición<br>`( 0 ❌ No repite )` <br>`( 1 🔂 Repite la misma radio )` <br>`( 2 🔁 Repite toda la lista )` | 0 |
| 🆔 | mediaId | *number / null* | NO | Identificador de la radio en base de datos. Si no se ingresa se buscara la primer radio reproducible en la lista segun los parametros ingresados | null |

```
{
    "volume": 100,
    "aleatory": true,
    "repeatMode": 2,
    "mediaId": 11
}
```

<h4>📥 Parámetros de Salida</h4> 

|  | Nombre | Tipo | Descripción |
| :-: | --- | :-: | --- |
| 📡 | frequency | *number* | Frecuencia de la radio |
| 📈 | wave | *string* | Banda de la radio |
| 🏷️ | name | *string* | Nombre para mostrar |
| 🎵 | type | *string* | Tipo de medio de reproducción |
| 🕒 | duration | *string / null* | Duración de la pista |
| ⏳ | played | *string / null* | Tiempo de reproducción actual |
| ✅ | playing | *boolean* | Flag indicador de si se pudo reproducir |
```
{
    "frequency": 710.0,
    "wave": "AM",
    "name": "Radio 10",
    "type": "Radio",
    "duration": null,
    "played": null,
    "playing": true
}
```
***
<div style="display:flex">
  <h2 style="padding-right:10px">⏭️ Next</h2>
  <h4><code style='color:DarkOrange'>POST</code></h4> 
</div>

Reproduce la siguiente radio de la lista segun los parametros ingresados. De no poder reproducir la pista se remueve de la lista de reproducción y se agrega marca en base de datos.

```
http://localhost:5131/api/Radio/Next
```

<h4>📥 Parámetros de Entrada</h4> 

|  | Nombre | Tipo | Obligatorio | Descripción | Default |
| :-: | --- | :-: | :-: | --- | :-: |
| 🎚️ | volume | *number* | NO | Volumen al que se iniciara la reproducción | 0 |
| 🔀 | aleatory | *boolean* | NO | Flag indicador de si se debe reproducir una radio aleatoria | false |
| 🔁 | repeatMode | *number* | NO | Modo de repetición<br>`( 0 ❌ No repite )` <br>`( 1 🔂 Repite la misma radio )` <br>`( 2 🔁 Repite toda la lista )` | 0 |

```
{
    "volume": 100,
    "aleatory": true,
    "repeatMode": 2
}
```

<h4>📥 Parámetros de Salida</h4> 

|  | Nombre | Tipo | Descripción |
| :-: | --- | :-: | --- |
| 📡 | frequency | *number* | Frecuencia de la radio |
| 📈 | wave | *string* | Banda de la radio |
| 🏷️ | name | *string* | Nombre para mostrar |
| 🎵 | type | *string* | Tipo de medio de reproducción |
| 🕒 | duration | *string / null* | Duración de la pista |
| ⏳ | played | *string / null* | Tiempo de reproducción actual |
| ✅ | playing | *boolean* | Flag indicador de si se pudo reproducir |
```
{
    "frequency": 97.9,
    "wave": "FM",
    "name": "Cultura",
    "type": "Radio",
    "duration": null,
    "played": null,
    "playing": true
}
```
***
<div style="display:flex">
  <h2 style="padding-right:10px">⏮️ Previous</h2>
  <h4><code style='color:DarkOrange'>POST</code></h4> 
</div>

Reproduce la anterior radio de la lista segun los parametros ingresados. De no poder reproducir la pista se remueve de la lista de reproducción y se agrega marca en base de datos.

```
http://localhost:5131/api/Radio/Previous
```

<h4>📥 Parámetros de Entrada</h4> 

|  | Nombre | Tipo | Obligatorio | Descripción | Default |
| :-: | --- | :-: | :-: | --- | :-: |
| 🎚️ | volume | *number* | NO | Volumen al que se iniciara la reproducción | 0 |
| 🔀 | aleatory | *boolean* | NO | Flag indicador de si se debe reproducir una radio aleatoria | false |
| 🔁 | repeatMode | *number* | NO | Modo de repetición<br>`( 0 ❌ No repite )` <br>`( 1 🔂 Repite la misma radio )` <br>`( 2 🔁 Repite toda la lista )` | 0 |

```
{
    "volume": 100,
    "aleatory": true,
    "repeatMode": 2
}
```

<h4>📥 Parámetros de Salida</h4> 

|  | Nombre | Tipo | Descripción |
| :-: | --- | :-: | --- |
| 📡 | frequency | *number* | Frecuencia de la radio |
| 📈 | wave | *string* | Banda de la radio |
| 🏷️ | name | *string* | Nombre para mostrar |
| 🎵 | type | *string* | Tipo de medio de reproducción |
| 🕒 | duration | *string / null* | Duración de la pista |
| ⏳ | played | *string / null* | Tiempo de reproducción actual |
| ✅ | playing | *boolean* | Flag indicador de si se pudo reproducir |
```
{
    "frequency": 650.0,
    "wave": "AM",
    "name": "Belgrano-650",
    "type": "Radio",
    "duration": null,
    "played": null,
    "playing": true
}
```
***
<div style="display:flex">
  <h2 style="padding-right:10px">⏹️ Stop</h2>
  <h4><code style='color:green'>GET</code></h4> 
</div>

Detiene por completo la reproducción en curso.

```
http://localhost:5131/api/Radio/Stop
```
***
<div style="display:flex">
  <h2 style="padding-right:10px">⏸️ Pause</h2>
  <h4><code style='color:green'>GET</code></h4> 
</div>

Pausa la reproducción en curso. `(a diferencia del anterior se puede reanudar la reproducción desde el punto pausado si el medio lo permite)`

```
http://localhost:5131/api/Radio/Pause
```
***
<div style="display:flex">
  <h2 style="padding-right:10px">🎵 GetPlaying</h2>
  <h4><code style='color:green'>GET</code></h4> 
</div>

Obtiene el estado actual del reproductor y su medio.

```
http://localhost:5131/api/Radio/GetPlaying
```
<h4>📥 Parámetros de Salida</h4> 

|  | Nombre | Tipo | Descripción |
| :-: | --- | :-: | --- |
| 🎶 | media | *object* | Medio de reproducción en curso |
| 📡 | media.frequency | *number* | Frecuencia de la radio |
| 📈 | media.wave | *string* | Banda de la radio |
| 🏷️ | media.name | *string* | Nombre para mostrar |
| 🎵 | media.type | *string* | Tipo de medio de reproducción |
| 🕒 | media.duration | *string / null* | Duración de la pista |
| ⏳ | media.played | *string / null* | Tiempo de reproducción actual |
| ✅ | media.playing | *boolean* | Flag indicador de si se pudo reproducir |
| 🎚️ | volume | *number* | Volumen al que se encuentra la reproducción |
| 🔀 | aleatory | *boolean* | Flag indicador de si se reproduce una radio aleatoria |
| 🔁 | repeatMode | *number* | Modo de repetición<br>`( 0 ❌ No repite )` <br>`( 1 🔂 Repite la misma radio )` <br>`( 2 🔁 Repite toda la lista )` |
```
{
    "media": {
        "name": "Radio 10",
        "type": "Radio",
        "playing": true,
        "duration": null,
        "played": null,
        "frequency": 710.0,
        "wave": "AM"
    },
    "volume": 100,
    "aleatory": true,
    "repeatMode": 2
}
```
***
<div style="display:flex">
  <h2 style="padding-right:10px">🔊 SetVolume</h2>
  <h4><code style='color:DarkOrange'>POST</code></h4> 
</div>

Establece el volumen del reproductor.

```
http://localhost:5131/api/Radio/SetVolume
```

<h4>📥 Parámetros de Entrada</h4> 

|  | Nombre | Tipo | Obligatorio | Descripción | Default |
| :-: | --- | :-: | :-: | --- | :-: |
| 🎚️ | volume | *number* | NO | Volumen al que se iniciara la reproducción | 0 |

```
{
    "volume": 50
}
```