Start ved at køre "dotnet run" i main directive.



Formular til registrering af brugere:

*AskeOgViktorProjekt\\Areas\\Identity\\Pages\\Account\\Register.cshtml.cs*



Formular til login

*AskeOgViktorProjekt\\Areas\\Identity\\Pages\\Account\\Login.cshtml.cs*



Formularer skal bruge JavaScript og RegEx til at validere brugerinput

*AskeOgViktorProjekt\\wwwroot\\js\\site.js l. 28-47*



Man skal kunne se en liste over brugere et sted

*AskeOgViktorProjekt\\Pages\\Users.cshtml*



Noget skal være responsivt – altså reagere på skærmens størrelse

*AskeOgViktorProjekt\\wwwroot\\css\\site.scc l. 5-10*



Der skal laves et ajax kald

*AskeOgViktorProjekt\\Pages\\Users.cshtml.cs l. 23-27*



I skal sikre jer mod Cross-Site Scripting (CXX)

* Da koden er skrevet i the backend så er der ikke adgang til cross-site scripting
* Bruget af @ expression i .cshtml filer undgår at brugere kan bruge karakterer som <, >, \& og "
* Desuden så kan man ikke køre kode igennem ASP.net uploaded materiale



I skal sikre jer mod SQL Injection

* Asp validering af brugere beskytter imod SQL injection



**Arbejdsfordeling**

Aske:

*-Login*

*-Logout*

*-Visning baseret på login status*



Viktor:

*-Opsætning af DB*

*-Bruger registrering*

*-Liste af brugere*

*-Upload af billeder*

*-Visning af billeder*

