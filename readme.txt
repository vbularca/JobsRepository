
Descriere aplicatie 

Am considerat unitatea de procesare ca fiind un Job

Avem un sln "JobsProcessor.sln"

Proiectele sunt:
1. JobsProcessor 
	- console application 
	- apeleasa o metoda care creeaza Job-uri de test
	- apealeaza o metoda "Confirm" din API
	
2. WebAPIMock 
	- simuleaza un API, dar este doar o librarie
	- simuleaza metodele definite in requirement, si adauga raspunsuri random plus un sleep time pe fiecare apel
	
3. Contracts 
	- librarie care defineste un set de obiecte ce este folosit in toate aplicatiile 
	- obiecte care folosite atat in API cat si in app consola
	- am presupus ca atat API cat si COnsole app sunt interne in companie si am putea folosi un singur set de obiecte pentru comunicare
	
4. WebAPIWrapper
	- practic ascunde API-ul pentru Console application
	- daca WEB API este implementat atunci aici putem avea un HTTPClient care sa faca acele apeluri 
	(in cazul de fata apeleaza direct WebAPIMock )
	
