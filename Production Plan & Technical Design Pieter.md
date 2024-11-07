# Production Plan & Technical Design Document

## 1. Production Plan

### 1.1. Project Overview

- **Projectnaam**: Saviour of Starvation Maze
- **Teamleden**: Pieter: Programmeur, Artist, Project Manager
- **Projectdoel**: Starvation Maze is een spel waarbij de speler door een doolhof loopt en verhongerde mensen probeert te redden door ze eten te geven wat in de maze te vinden is.
- **Tijdlijn**: 11-11-2024 / 26-01-2025

### 1.2. Milestones en Deadlines

| Milestone                        | Deadline  | Omschrijving                                                                 |
|-----------------------------------|-----------|------------------------------------------------------------------------------|
| Pre-production voltooid           | Week 1  | GDD compleet, technische vereisten gedefinieerd, projectstructuur opgezet.    |
| Eerste prototype concept          | Week 2-4  | Kernmechaniek geïmplementeerd, placeholder assets en UI aanwezig.             |
| Tweede prototype                  | Week 5-6  | Gameplay-elementen verfijnd, AI of physics toegevoegd, objectinteracties werken.|
| Playtesting en iteratie           | Week 7-8  | Playtesting, bugfixing, iteraties op basis van feedback.                      |
| Finale prototype presentatie      | Week 9 | Functioneel prototype, presentatie voorbereid, klaar voor demonstratie.       |


### 1.3. Taakverdeling

- **Programmeur(s)**: Verantwoordelijk voor het schrijven van code, game mechanics en Unity scripting.
- **Artist(s)**: Verantwoordelijk voor het maken van 2D/3D assets, textures en animaties.
- **Project Manager**: Coördinatie van het team, bewaakt deadlines en zorgt voor goede communicatie.

### 1.4. Risicomanagement

- **Technische risico's**: Ik heb nog niet met een groot unity project gewerkt en verw3acht dus tegen problemen aan te lopen die hier mee te maken hebben.
- **Planning risico's**: Spriting zal een issue worden omdat ik totaal niet betekend ben met sprites en hoe ik deze moet vinden/maken/aanpassen.
- **Oplossingen**: Voor het techinische risico zal versiebeheer een hele goede oplossing zijn omdat dit ervoor zorgt dat niet alleen updates goed genoteerd staan, maar ik omdat ik terug zou kunnen gaan naar een versie die een bepaald probleem niet ingebakken heeft.
					Voor het planning risico, ik kan sprites altijd simpeler maken. Hiermee wordt de game uiteraard mkinder mooi maar hij zal wel functioneel blijven.

### 1.5. Budget

- **Tijd**: Het vak is 5 EC en ik werk er alleen aan dus is er een budget van 28*5 = 140 uur

### 1.6. Communicatie en Samenwerking

- **Meetingschema**: Eens per week met Lex, eens per week met ander ontwikkelteam
- **Communicatiemiddelen**: GitHub, Microsoft 365 (Teams, Outlook)

---

## 2. Technical Design Document (TDD)

### 2.1. Inleiding

Voor het spel moeten doolhoven van verschilende groten gemaakt worden. Een speler moet zich hierdoor kunnen navigeren met beperkt zicht.
Er moet een verhongerd persoon in het midden van het doolhof te vinden zijn. Dit persoon moet verschijdende voedingsmiddelen nodig hebben en dit moet met de speler gecomuniceerd worden.
In het doolhof moeten verschilende soorten voedseld te vinden zijn. De speler moet deze kunnen oppakken en in hun inventory de voedingswaarde van het voedsel kunnen zien.
Als de speler voedsel naar het verhongerde persoon brengt moet deze het kunnen eten en door hebben wanneer hij genoeg heeft gegeten en de speler kan doorsturen naar het volgende level.
- **Link naar Game Design Document**: *Plaats een link naar je GDD.*

### 2.2. Systeemarchitectuur

- **Softwaree**: Unity 6000.0.16f1, Visual Studio Code 1.95.1,
- **Platformen**: Browser(e.g. Chrome, safari, firefox)
- **Technologie Stacks**: C#
- **Hardware**: Pc met toetsenbord en muis.
- **Minimum systeemvereisten**: Onbekent maar laag

### **2.3. Gameplay Mechanics**

- **Core Mechanics**: De speler moet kunnen rondlopen door het doolhof, het doolhof is van te voren gemaakt met random voedsel spawns. De speler moet eten kunnen oppakken en meenemen.
						Het verhongerde persoon moet random eten nodig hebben.
- **Physics**: Het spel heeft geen physics. De speler loopt met een vaste snelheid door het doolhof heen.
- **User Interface (UI)**: De UI tijdens het spel bestaat ui het hoofdsscherm waar de speler zichzelf en het doolhof om zich heen ziet. Hier loopt de speler doorheen. Rechts onder in het scherm is de spelers "Inventory" te vinden. Hier vind de speler voedsel wat ze bij zich hebben.
							Boeven het inventory is een informatie pannel. Als de speler bij het verhongerde persoon is zal hier staan wat deze nog nodig heeft. Als de speler in het doolhof zit met een lege inventory staat hier niks. Als de speler wel iets bij zich heeft staat hier het voedignswaardelabel.					
- **Input System**: De speler kan bewegen met de pijltjes of met w,a,s,d. Met backspace kan de speler naar het menu. Met Enter laat de speler voedsel vallen. In het hoofdmenu en de settings kan de speller met pijltjes en enter of met de muis navigeren.

### 2.4. Code Architectuur

- **Projectstructuur**: [Best practices for organizing your Unity project | Unity](https://unity.com/how-to/organizing-your-project)
- **Class Diagram**: globaal gezein: Er zal een object "player" zijn. Een object "food". Een object "starving_person". Food is een superclassen met paramters zoals: calories, fat, suger, etc. Hieruit kunnen subclassen komen die net iets anders(tbd). De starving person heeft vergelijkbare atributen als food maar kan deze omhoog laten gaan door food van de player te krijgen.
						De player class checked collision met de muren de starving person en food.
- **Design Patterns**: Game_manager die het doolhof bijhoud en voedselitems beheerd. Een player singleton(omdat er maar 1 speler kan zijn). There is also likly going to be a command patern to handle player movement and interaction.
- **Scripting Guidelines**:
  - [Naming and code style tips for C# scripting in Unity](https://unity.com/how-to/naming-and-code-style-tips-c-scripting-unity)
  - [Formatting best practices for C# scripting in Unity](https://unity.com/how-to/formatting-best-practices-c-scripting-unity)

### 2.5. AI en NPC Systemen

- **AI-Systemen**: Het spel heeft geen AI in het bewegen van poppetjes oid. Wel zal er een slim spawn systeem gemaakt worden. Dit systeem creeert eerst een random starving person met random needs. Dan wordt er eten gespand wat hierbij helpt of juist tegen werkt. Dit wordt door de gamemanager gedaan.
- **Decision-making**: De AI hoeft niet vooruit te denken, daarmee is er ook geen ingewikelde discision making nodig.

### 2.6. Audio en Animatie

- **Audio Systemen**: Hiervoor zal het standaar unitiy systeem gebruikt gaan worden.
- **Animatie Pipelines**: Unity's Animator., Dit zal gebruikt worden voor de speler die beweegt en dingen zoals toortsen aan de muur.

### 2.7. Versiebeheer en Backups

- **Version Control**: GitHub via GitHub classroom.
- **Werkwijze**: Feature en bugfix branches met pull requests
  - Clone de repository en maak een nieuwe branch
  - Werk in Unity, gebruik prefabs en multi-scene editing
  - Commit en push regelmatig kleine wijzigingen
  - Maak een pull request aan en laat het reviewen
  - Rebase of merge main naar je branch indien nodig
  - Los feedback op en merge de naar main
  - Verwijder oude branches en houd je repository up-to-date

- **Backup Procedures**: 2x per week, op woensdag en vrijdag.

### 2.8. Testplan

- **Playtesting Plan**: Naast de testdag en persoonlijke test tijdens development ben ik ook van plan om de game met mijn huisgnoot te testen.
- **Unit Tests**: Het generen van food zal een unit test krijgen om te testen of er genoeg maar niet te veel eten is voor de starving person.
