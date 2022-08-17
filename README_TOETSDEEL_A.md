# Toetsdeel A: ICT-DEV-OO-18-ProjectRoseOfSharon

Toetsdeel A: Project Rose of Sharon (grafisch reverse-desertification simulatiemodel) voor module ICT-DEV-OO-18.

 - [Introductie](#introductie)
 - [Inleveren](#inleveren)
 - [Opdrachten](#opdrachten)
   - [Eindopdracht A.1. Migratiestrategie hulpmethodes](#opdrachta1)
   - [Eindopdracht A.2. Unit testen van migratiestrategie hulpmethodes](#opdrachta2)
   - [Eindopdracht A.3. Migratiestrategie I: Clockwise](#opdrachta3)
   - [Eindopdracht A.4. Migratiestrategie II: MaxSpots](#opdrachta4)
   - [Eindopdracht A.5. Unit testen van migratiestrategieën](#opdrachta5)
   - [EXTENDED 🐱‍👤 Eindopdracht A.6. Eigen Migratiestrategie](#opdrachta6)
   
<a name="introductie"></a>
## Introductie

Dit is de opdrachtbeschrijving voor toetsdeel A voor het vak Object-Oriented Development. In dit toetsonderdeel ligt de nadruk op het demonstreren van jouw imperatieve-programmeervaardigheden in C#.

Vanaf week 1 werk jij aan dit toetsonderdeel. Zorg dat je op tijd begint met dit toetsonderdeel. De opdrachten staan hieronder beschreven. Alle opdrachten werk jij uit. Met deze opdrachten demonstreer jij aan ons jouw vaardigheden doordat hierin alle aspecten aan bod komen zoals beschreven in de toetsmatrijs, waarin alle beoordelingscriteria staan uitgewerkt.

Vóór de deadline (zie ItsLearning) lever jij jouw code in via ItsLearning (samen met de andere toetsonderdelen).

Let op de volgende zaken:
- Jij wordt niet beoordeeld op de frontend / opmaak / styling van je applicatie (Blazor, Html, CSS).
- Maak gebruik van Git voor versiebeheer. Commit regelmatig. Wij willen je progressie kunnen zien.
- Maak direct een branch van de versie die je krijgt en werk alleen met branches. Wij willen een pull-request krijgen met al jouw wijzigingen ten opzichte van de versie die je van ons krijgt.

<a name="inleveren"></a>
## Inleveren
Voor inleverdetails aan het eind zie [README.md](README.md) in de github repository. Je kunt daarnaast ook je werk tussentijds inleveren. Zorg hiervoor dat je een pull request aanmaakt, dusdanig dat jouw docenten en mede-studenten jouw werk van commentaar en feedback kunnen voorzien.

<a name="opdrachten"></a>
# Opdrachten

Voor deze opdrachten ga je werken met de classes in de project folder `/Migration`. Bestudeer hiervan de classes en documentatie nauwkeurig.

Dit zijn de opdrachten:

<a name="opdrachta1"></a>
## Eindopdracht A.1. Migratiestrategie hulpmethoden

Een herder maakt gebruik van een migratiestrategie. Deze strategie bepaalt voor de herder in welke richting de herder moet bewegen.

In de komende opdrachten zullen wij de migratiestrategiën `MaxSpotsMigrationStrategy` en `ClockwiseMigrationStrategy` gaan ontwikkelen. Om dit straks te kunnen doen moet je eerst enkele handige hulpmethoden implementeren om deze strategiën te kunnen implementeren. Aangezien meerdere strategiën gebruik gaan maken van deze handige hulpmethoden, maken we hiervoor gebruik van een base class `MigrationStrategyBase` met enkele gedocumenteerde niet-geimplementeerde methodes. 

Implementeer de lege methoden in de `MigrationStrategyBase` class en volg hierin de gegeven documentatie. Hint: Het is waarschijnlijk handig om te beginnen met de eenvoudige methode zoals `IsFree`, aangezien je die waarschijnlijk nodig gaat hebben in de andere methoden.

<a name="opdrachta2"></a>
## Eindopdracht A.2. Unit testen van migratiestrategie hulpmethoden

Implementeer voor elke methode een nuttige unit tests waaruit blijkt dat de methode doet wat het moet doen. Controleer of alle unit tests (terecht) slagen. Maak hierbij gebruik van het given-when-then principe en denk aan naming conventions.

<a name="opdrachta3"></a>
## Eindopdracht A.3. Migratiestrategie I: Clockwise

De migratiestrategie `ClockwiseMigration` laat de herder altijd in dezelfde richting bewegen tot het niet meer kan. Hiervoor zal gebruik gemaakt moeten worden van de zojuist geïmplementeerde `IsFree` methode en de methode `GetRelativeSpot` van de interface `ISpot`. Zodra de herder niet meer verder kan past hij de richting aan met de klok mee en maakt hierbij gebruik van de zojuist geïmplementeerde `GetNextDirectionClockwise` methode. 

Eén op de tien iteraties (simulatiestappen) doet de herder een beweegactie. Dat wil zeggen dat één op de tien iteraties de herder vooruit loopt in de huidige richting óf van richting veranderd met de klok mee. Alle overige iteraties staat de herder stil.

Implementeer de methode `GetDirection` in de class `ClockwiseMigrationStrategy` en volg hierbij de documentatie.

<a name="opdrachta4"></a>
## Eindopdracht A.4. Migratiestrategie II: MaxSpots

De migratiestrategie `MaxSpotsMigrationStrategy` laat de herder altijd in dezelfde richting bewegen tot het niet meer kan. Hiervoor wordt wederom gebruik gemaakt van de zojuist geïmplementeerde `IsFree` en de methode `GetRelativeSpot` van de interface `ISpot`. Zodra de herder niet meer verder kan past hij de richting aan naar de richting waar hij de meeste vrije spots voor zich ziet liggen en maakt hierbij gebruik van de zojuist geïmplementeerde methoden `MaxSpotsFree` en `GetNextDirectionClockwise`.  

Implementeer de methode `GetDirection` in de class `MaxSpotsMigrationStrategy` en volg hierbij de documentatie.

<a name="opdrachta5"></a>
## Eindopdracht A.5. Unit testen van migratiestrategieën

Schrijf een unit test voor beide strategieën. Controleer of alle unit tests (terecht) slagen.

<a name="opdrachta7"></a>
## EXTENDED 🐱‍👤 Eindopdracht A.6. Eigen Migratiestrategie

Deze opdracht is een EXTENDED opdracht, en dus niet verplicht voor het inleveren van jouw eindopdracht. Je kunt hiermee jouw vaardigheden nog beter demonstreren.

Implementeer nog een strategie, mogelijke ideeën:
- **Langste pad** - Schrijf een migratiestrategie dat de richting kiest waarin het langste pad te zien is voor de herder. Een pad bestaat uit een hoeveelheid lege spots die buren van elkaar zijn.
- **Vrij gebied** - Schrijft een migratiestrategie dat de richting kiest waarin het grootste vrije gebied te zien is voor de herder.
- ...

Voorzie je migratiestrategie van nuttige unit tests.