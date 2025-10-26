﻿<h1 align="center">📻 Eve API – Reproductor de radio y hub</h1>

***
Una API RESTful desarrollada en .NET 6 que permite reproducir estaciones de radio configuradas por base de datos además de gestionar el screen case, los ventiladores e iluminación de un gabinete de pc a través de una interfaz de Arduino. Está destinada a la reutilización de un equipo antiguo con Windows 7, por lo que las versiones de las tecnologías están acotadas para que sean ejecutables en él. Este es un proyecto personal a modo de practica que me permite aplicar y compartir conocimientos.

# ✨ <u>Características principales</u>
<ul style="list-style: none; padding-left: 0;">
  <li><span style="text-align:center;display: inline-block; width: 2em;">🔊</span> Reproducción de estaciones vía streaming</li>
  <li><span style="text-align:center;display: inline-block; width: 2em;">🧱</span> Arquitectura basada en CQRS, SOLID y Clean Architecture</li>
  <li><span style="text-align:center;display: inline-block; width: 2em;">🛡️</span> Validación de entrada y manejo de errores centralizado</li>
  <li><span style="text-align:center;display: inline-block; width: 2em;">📄</span> Manejo de Logs</li>
  <li><span style="text-align:center;display: inline-block; width: 2em;">🧪</span> Tests unitarios con MSTest y Moq</li>
</ul>

# 💻 <u>Tecnologías utilizadas</u>

<table>
  <tr>
    <td>
      <span style="text-align:center;display: inline-block; width: 2em;">⚙️</span> .NET 6
    </td>
    <td>Backend y API REST</td>
  </tr>
  <tr>
    <td>
      <span style="text-align:center;display: inline-block; width: 2em;">🔣</span> C#
    </td>
    <td>Lógica de negocio y controladores</td>
  </tr>
  <tr>
    <td>
      <span style="text-align:center;display: inline-block; width: 2em;">🛢️</span> SQL Server
    </td>
    <td>Persistencia de datos</td>
  </tr>
  <tr>
    <td>
      <span style="text-align:center;display: inline-block; width: 2em;">🔗</span> Entity Framework
    </td>
    <td>Acceso a datos optimizado</td>
  </tr>
  <tr>
    <td>
      <span style="text-align:center;display: inline-block; width: 2em;">🧪</span> MSTest + Moq
    </td>
    <td>Testing unitario</td>
  </tr>
  <tr>
    <td>
      <span style="text-align:center;display: inline-block; width: 2em;">📟</span> C++
    </td>
    <td>Configuración Arduino</td>
  </tr>
</table>

</table>

# 🎯 <u>Objetivo del proyecto</u>
Este proyecto fue creado con el objetivo de:
- Mostrar dominio técnico en backend y diseño de APIs
- Aplicar patrones modernos y buenas prácticas
- Servir como base para futuros proyectos comerciales

# 📚 <u>Documentación</u>
<ul style="list-style: none; padding-left: 0;">
  <li><span style="text-align:center;display: inline-block; width: 2em;">🛠️</span> <a href="Docs/Install&Play.md" target="_blank">Instalación y ejecución</a></li>
  <li><span style="text-align:center;display: inline-block; width: 2em;">📻</span> <a href="Docs/RadioController.md" target="_blank">Controlador de Radio</a></li>
  <li><span style="text-align:center;display: inline-block; width: 2em;">🗄️</span> <a href="Docs/CaseController.md" target="_blank">Controlador de Gabinete</a></li>
</ul>