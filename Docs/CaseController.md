<h1 align="center">🗄️ Controlador de Gabinete</h1>

***
<div style="display:flex">
  <h2 style="padding-right:10px">🗄️🔍 GetState</h2>
  <h4><code style='color:green'>GET</code></h4> 
</div>

Obtiene el estado general de los periféricos del gabinete.

```
http://localhost:5131/api/Case/GetState
```
<h4>📥 Salida</h4> 

| | Tipo | Descripción |
| :-: | :-: | --- |
|   | *boolean* | Estatus general de los periféricos del gabinete<br>`( true ✅ Uno o más componentes se encuentran encendidos )`<br>`( false ❌ Todos los componentes se encuentran apagados )`|
```
false
```
***
<div style="display:flex">
  <h2 style="padding-right:10px">🗄️🟢 TurnOn</h2>
  <h4><code style='color:green'>GET</code></h4> 
</div>

Enciende todos los periféricos del gabinete.

```
http://localhost:5131/api/Case/TurnOn
```
<h4>📥 Salida</h4> 

| | Tipo | Descripción |
| :-: | :-: | --- |
|   | *boolean* | Estatus general de los periféricos del gabinete<br>`( true ✅ Uno o más componentes se encuentran encendidos )`<br>`( false ❌ Todos los componentes se encuentran apagados )`|
```
true
```
***
<div style="display:flex">
  <h2 style="padding-right:10px">🗄️🔴 TurnOff</h2>
  <h4><code style='color:green'>GET</code></h4> 
</div>

Apaga todos los periféricos del gabinete.

```
http://localhost:5131/api/Case/TurnOff
```
<h4>📥 Salida</h4> 

| | Tipo | Descripción |
| :-: | :-: | --- |
|   | *boolean* | Estatus general de los periféricos del gabinete<br>`( true ✅ Uno o más componentes se encuentran encendidos )`<br>`( false ❌ Todos los componentes se encuentran apagados )`|
```
false
```
***
<div style="display:flex">
  <h2 style="padding-right:10px">🖥️🔍 Screen/GetState</h2>
  <h4><code style='color:green'>GET</code></h4> 
</div>

Obtiene el estado de la pantalla del gabinete.

```
http://localhost:5131/api/Case/Screen/GetState
```
<h4>📥 Salida</h4> 

| | Tipo | Descripción |
| :-: | :-: | --- |
|   | *boolean* | Estatus de la pantalla del gabinete<br>`( true ✅ Uno o más componentes se encuentran encendidos )`<br>`( false ❌ Todos los componentes se encuentran apagados )`|
```
false
```
***
<div style="display:flex">
  <h2 style="padding-right:10px">🖥️🟢 Screen/TurnOn</h2>
  <h4><code style='color:green'>GET</code></h4> 
</div>

Enciende la pantalla del gabinete.

```
http://localhost:5131/api/Case/Screen/TurnOn
```
<h4>📥 Salida</h4> 

| | Tipo | Descripción |
| :-: | :-: | --- |
|   | *boolean* | Estatus de la pantalla del gabinete<br>`( true ✅ Uno o más componentes se encuentran encendidos )`<br>`( false ❌ Todos los componentes se encuentran apagados )`|
```
true
```
***
<div style="display:flex">
  <h2 style="padding-right:10px">🖥️🔴 Screen/TurnOff</h2>
  <h4><code style='color:green'>GET</code></h4> 
</div>

Apaga la pantalla del gabinete.

```
http://localhost:5131/api/Case/Screen/TurnOff
```
<h4>📥 Salida</h4> 

| | Tipo | Descripción |
| :-: | :-: | --- |
|   | *boolean* | Estatus de la pantalla del gabinete<br>`( true ✅ Uno o más componentes se encuentran encendidos )`<br>`( false ❌ Todos los componentes se encuentran apagados )`|
```
false
```
***
<div style="display:flex">
  <h2 style="padding-right:10px">💡🔍 Lights/GetState</h2>
  <h4><code style='color:green'>GET</code></h4> 
</div>

Obtiene el estado de la iluminación del gabinete.

```
http://localhost:5131/api/Case/Lights/GetState
```
<h4>📥 Salida</h4> 

| | Tipo | Descripción |
| :-: | :-: | --- |
|   | *boolean* | Estatus de la iluminación del gabinete<br>`( true ✅ Uno o más componentes se encuentran encendidos )`<br>`( false ❌ Todos los componentes se encuentran apagados )`|
```
false
```
***
<div style="display:flex">
  <h2 style="padding-right:10px">💡🟢 Lights/TurnOn</h2>
  <h4><code style='color:green'>GET</code></h4> 
</div>

Enciende la iluminación del gabinete.

```
http://localhost:5131/api/Case/Lights/TurnOn
```
<h4>📥 Salida</h4> 

| | Tipo | Descripción |
| :-: | :-: | --- |
|   | *boolean* | Estatus de la iluminación del gabinete<br>`( true ✅ Uno o más componentes se encuentran encendidos )`<br>`( false ❌ Todos los componentes se encuentran apagados )`|
```
true
```
***
<div style="display:flex">
  <h2 style="padding-right:10px">💡🔴 Lights/TurnOff</h2>
  <h4><code style='color:green'>GET</code></h4> 
</div>

Apaga la iluminación del gabinete.

```
http://localhost:5131/api/Case/Lights/TurnOff
```
<h4>📥 Salida</h4> 

| | Tipo | Descripción |
| :-: | :-: | --- |
|   | *boolean* | Estatus de la iluminación del gabinete<br>`( true ✅ Uno o más componentes se encuentran encendidos )`<br>`( false ❌ Todos los componentes se encuentran apagados )`|
```
false
```
***
<div style="display:flex">
  <h2 style="padding-right:10px">🌀🔍 Fans/GetState</h2>
  <h4><code style='color:green'>GET</code></h4> 
</div>

Obtiene el estado de los ventiladores del gabinete.

```
http://localhost:5131/api/Case/Fans/GetState
```
<h4>📥 Salida</h4> 

| | Tipo | Descripción |
| :-: | :-: | --- |
|   | *boolean* | Estatus de los ventiladores del gabinete<br>`( true ✅ Uno o más componentes se encuentran encendidos )`<br>`( false ❌ Todos los componentes se encuentran apagados )`|
```
false
```
***
<div style="display:flex">
  <h2 style="padding-right:10px">🌀🟢 Fans/TurnOn</h2>
  <h4><code style='color:green'>GET</code></h4> 
</div>

Enciende los ventiladores del gabinete.

```
http://localhost:5131/api/Case/Fans/TurnOn
```
<h4>📥 Salida</h4> 

| | Tipo | Descripción |
| :-: | :-: | --- |
|   | *boolean* | Estatus de los ventiladores del gabinete<br>`( true ✅ Uno o más componentes se encuentran encendidos )`<br>`( false ❌ Todos los componentes se encuentran apagados )`|
```
true
```
***
<div style="display:flex">
  <h2 style="padding-right:10px">🌀🔴 Fans/TurnOff</h2>
  <h4><code style='color:green'>GET</code></h4> 
</div>

Apaga los ventiladores del gabinete.

```
http://localhost:5131/api/Case/Fans/TurnOff
```
<h4>📥 Salida</h4> 

| | Tipo | Descripción |
| :-: | :-: | --- |
|   | *boolean* | Estatus de los ventiladores del gabinete<br>`( true ✅ Uno o más componentes se encuentran encendidos )`<br>`( false ❌ Todos los componentes se encuentran apagados )`|
```
false
```