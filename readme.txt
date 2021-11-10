
Descriere aplicatie 

Am considerat unitatea de procesare ca fiind un Job

Avem un folder "_SQLScripts" care contine 2 scripturi SQL si care nu este inclus in proiect

Toate proiectele de mai jos sunt adaugate in solutie - "JobsProcessor.sln"

Proiectele sunt:
1. JobsProcessor 
	- aplicatia consola
	- apeleaza o metoda care creeaza Job-uri de test
	- apealeaza o metoda "Confirm" din Web API pentru fiecare job
	
2. WebAPIMock 
	- simuleaza un API, dar este doar o librarie ( am inteles ca aceste API-uri se presupune ca ar exista )
	- simuleaza metodele definite in requirement si adauga raspunsuri random 
    - pentru a simula un API real, adaug si un sleep time pe fiecare apel
	
3. Contracts 
	- librarie care defineste un set de obiecte comune
	- am presupus ca atat API cat si aplicatia consola sunt interne in companie si este posibila folosirea unui singur set de obiecte pentru comunicare 
	
4. WebAPIWrapper
	- practic ascunde API-ul pentru aplicatia consola
	- daca WEB API este implementat atunci aici putem avea un HTTPClient care sa faca acele apeluri ( in cazul de fata apeleaza direct codul din libraria WebAPIMock )

