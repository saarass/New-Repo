# Toetsdeel B: ICT-DEV-OO-18-ProjectRoseOfSharon

Toetsdeel B: Project Rose of Sharon (grafisch reverse-desertification simulatiemodel) voor module ICT-DEV-OO-18.

 - [Introductie](#introductie)
 - [Inleveren](#inleveren)
 - [Diagrammen en Functionaliteiten](#diagenfunc)
 - [Opdrachten](#opdrachten)
   - [Eindopdracht B.1. Woestijn laten bloeien tot weideveld](#opdrachtb1)
   - [Eindopdracht B.2. Weideveld laten doorgroeien tot bos](#opdrachtb2)
   - [Eindopdracht B.3. Bossen laten gedijen](#opdrachtb3)
   - [EXTENDED 🐱‍👤 Eindopdracht B.4. Eigen spots toevoegen](#opdrachtb4)
   
<a name="introductie"></a>
## Introductie

Dit is de opdrachtbeschrijving voor toetsdeel B voor het vak Object-Oriented Development. In dit toetsonderdeel ligt de nadruk op het demonstreren van jouw implementatie vaardigheden van een object-oriented ontwerp.

Vanaf week 4 werk jij aan dit toetsonderdeel. Zorg dat je op tijd begint met dit toetsonderdeel. De opdrachten staan hieronder beschreven. Alle opdrachten werk jij uit. Met deze opdrachten demonstreer jij aan ons jouw vaardigheden doordat hierin alle aspecten aan bod komen zoals beschreven in de toetsmatrijs, waarin alle beoordelingscriteria staan uitgewerkt.

Vóór de deadline (zie ItsLearning) lever jij jouw code in via ItsLearning (samen met de andere toetsonderdelen).

Let op de volgende zaken:
- Jij wordt niet beoordeeld op de frontend / opmaak / styling van je applicatie (Blazor, Html, CSS).
- Maak gebruik van Git voor versiebeheer. Commit regelmatig. Wij willen je progressie kunnen zien.
- Maak direct een branch van de versie die je krijgt en werk alleen met branches. Wij willen een pull-request krijgen met al jouw wijzigingen ten opzichte van de versie die je van ons krijgt.

<a name="inleveren"></a>
## Inleveren
Voor inleverdetails aan het eind zie [README.md](README.md) in de github repository. Je kunt daarnaast ook je werk tussentijds inleveren. Zorg hiervoor dat je een pull request aanmaakt, dusdanig dat jouw docenten en mede-studenten jouw werk van commentaar en feedback kunnen voorzien.

<a name="diagenfunc"></a>
# Diagrammen en Functionaliteiten
Voor deze opdrachten ga je werken met de classes in de project folder `/Terrain`. Bestudeer hiervan de classes en documentatie nauwkeurig.

![alt Terrain en Spot classes](Images/Class%20diagram%20terrain.drawio.png)

*Figuur: Class diagram van alle aan het terrein en spots gerelateerde classes.*

Wellicht valt je op dat niet alle functionaliteiten geimplementeerd zijn of dat bepaalde classes in het geheel ontbreken. Dat komt omdat we werken met een ontwerp. Het is jouw taak om het ontwerp te gebruiken om de classes te implementeren.

Een `Terrain` bestaat uit een aantal `ISpot`s, waarbij elk `ISpot` een `Position` heeft op dat terrein, dat bestaat uit een `x` en `y` waarde die respectievelijk de horizontale en verticale positie op het terrein aanduidt. Bestudeer de `ISpot` en `SpotBase` class goed om te zien wat elke methode doet.

Op het terrein bevinden zicht verschillende soorten `ISpot`s, namelijk in de varianten `DesertSpot`, `GrassSpot` en `ForestSpot`. Daarnaast ligt aan deze varianten een algemene basis ten grondslag `SpotBase` waar deze varianten gebruik van maken. Bovendien zijn `GrassSpot` en `ForestSpot` beiden `FertileSpot`s, dat wil zeggen dat ze worden gerekend als vruchtbare grond.

![alt Sequence diagram van de applicatie](Images/Sequence%20diagram%20Start.drawio.png)

*Figuur: Sequence diagram met werking zodra gebruiker de simulatie in de applicatie heeft gestart.*

Zodra de simulatie gestart wordt door de gebruiker is het terrein al opgebouwd. Wanneer de simulatie een stap maakt wordt een `Update()` method aangeroepen. Dit propageert door naar alle `IBiological` en `ISpot` classes. Dat wil zeggen dat je het gedrag van levensvormen en terrein hierin kan gaan beschrijven.

<a name="opdrachten"></a>
# Opdrachten
Dit zijn de opdrachten:

<a name="opdrachtb1"></a>
## Eindopdracht B.1. Woestijn laten bloeien tot weideveld

Implementeer aan de hand van de UML (use case, class en sequence) diagrammen de woestijn (`DesertSpot`). In de simulatie zal door de migratie van dieren het terrein tot bloei komen. Zorg ervoor dat een woestijn (`DesertSpot`) na voldoende bemesting (geconfigureerde hoeveelheid) door dieren veranderd in een weideveld (`GrassSpot`). 

Hint: Maak in jouw implementatie gebruik van eventuele base classes en interfaces zoals aangegeven in het object-oriented ontwerp. Zorg ervoor dat de methoden netjes op de juiste plek in de code terecht komen.

Hint: Hou er rekening mee dat `GrassSpot`s niet automatisch op het terrein staan bij aanvang van de simulatie. Het terrein wordt initieel gevuld met alleen `DesertSpot`s. Zorg dat je de code in `Terrain` aanpast dusdanig dat je ook `GrassSpot`s krijgt.

Voorzie je code waar mogelijk van nuttige unit tests.

<a name="opdrachtb2"></a>
## Eindopdracht B.2. Weideveld laten doorgroeien tot bos

Implementeer aan de hand van de UML (use case, class en sequence) diagrammen het weideveld (`GrassSpot`). Zorg ervoor dat een weideveld doorgroeit tot een bos (`ForestSpot`). Zorg hierbij dat bemesting door dieren ook positieve impact hierop heeft. Daarnaast moet een weideveld ook automatisch doorontwikkelen naar een bos. 

Voordat een `GrassSpot` doorgroeit tot een bos neemt de hoeveelheid gras toe `amountOfGrass`. Hiervoor zijn verschillende methoden nodig zoals `GrowGrass`, `EatGrass` en `HasGrass`.

Laat gras iedere vijf iteraties groeien aan de hand van de bemesting volgens de voorafgeconfigureerde fertilizer-gras ratio (`FertilizerToGrassRatio`). Laat daarnaast spontaan gras groeien iedere voorafgeconfigureerde aantal iteraties (`NrOfIterationsForFreeGrass`). Zodra er genoeg bemesting is laat het terrein zich doorontwikkelen naar een bos.

Voorzie je code waar mogelijk van nuttige unit tests.

<a name="opdrachtb3"></a>
## Eindopdracht B.3. Bossen laten gedijen

Implementeer aan de hand van de UML (use case, class en sequence) diagrammen het bos (`ForestSpot`). Zorg ervoor dat een bos (`ForestSpot`) gedijt door aangrenzende te laten doorgroeien tot een bos (`ForestSpot`). Zorg hierbij dat bemesting door dieren ook positieve impact hierop heeft.

Voordat een `ForestSpot` doorgroeit tot een bos neemt de hoeveelheid gras toe `amountOfBranches`. Hiervoor zijn verschillende methoden nodig zoals `GrowBranches`, `EatBranches` en `HasEdibleBranches`.

Zorg ervoor dat takken (`Branches`) blijven groeien iedere vijf iteraties aan de hand van de bemesting. Laat daarnaast spontaan takken groeien. Zodra er genoeg bemesting is laat met een kans van 1 op de 1000 keer een bos (`ForestSpot`) groeien bij één willekeurig gekozen naburige `Spot`.

Voorzie je code waar mogelijk van nuttige unit tests.

<a name="opdrachtb4"></a>
## EXTENDED 🐱‍👤 Eindopdracht B.4. Eigen spots toevoegen

Bedenk een eigen terreinsoort en voeg deze toe. Voorzie je code waar mogelijk van nuttige unit tests. Hier zijn enkele mogelijkheden
- RiverSpot - Implementeer een rivier waarlangs de vruchtbaarheid uiteraard snel toeneemt.
- HillSpot - Implementeer een heuvel die waarschijnlijk een stuk moeilijker vruchtbaar te maken is.
- ...