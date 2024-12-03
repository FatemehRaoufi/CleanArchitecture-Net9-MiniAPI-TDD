Projektübersicht: Architektur und Technologien
Dieses Projekt wurde nach den Prinzipien der Clean Architecture entwickelt, um Wartbarkeit, Skalierbarkeit und Testbarkeit zu gewährleisten. Im Folgenden finden Sie eine kurze Erklärung der Architektur und der verwendeten Technologien:

//***************************************************
Architektur
//***************************************************
Clean Architecture:

Zentrale Ausrichtung auf die Geschäftslogik mit klarer Trennung der Verantwortlichkeiten.
Aufteilung in Schichten:
API-Schicht (Präsentation): Verarbeitet HTTP-Anfragen und liefert entsprechende Antworten.
Service-Schicht (Anwendung): Beinhaltet die Geschäftslogik und vermittelt zwischen API- und Datenebene.
Daten-Schicht (Infrastruktur): Zuständig für die Datenbankzugriffe und Repositories.
Shared Layer: Enthält wiederverwendbare Komponenten wie DTOs und Modelle.

//-------------------------
Minimal APIs:
//-------------------------
Nutzt die Minimal-API-Funktionen von .NET für eine kompakte Endpunkt-Definition und reduziert Boilerplate-Code.
Fördert Einfachheit und Performance.

//-------------------------
Repository Pattern:
//-------------------------
Abstrahiert Datenbankinteraktionen und bietet Flexibilität bei Änderungen an der zugrunde liegenden Datenquelle.

//------------------------
Testen mit TDD:
//--------------------------
Test-Driven Development mit xUnit.
Beinhaltet Unit-Tests für Services, Repositories.

//******************************************************
Technologien
//******************************************************

.NET 9: Verwendung der neuesten Funktionen von .NET, einschließlich verbesserter Performance und neuer APIs.
In-Memory-Datenbank: Microsoft.EntityFrameworkCore.InMemory für eine vereinfachte Datenbankeinrichtung während Entwicklung und Test.
Entity Framework Core: Für nahtlose Datenbankoperationen.
Swagger/OpenAPI: Automatisch generierte API-Dokumentation und Testoberfläche.
Dependency Injection: Eingebaute Unterstützung zur Verwaltung von Servicelebenszyklen und Abhängigkeiten.
In-Memory-Datenbank: Optimiert für die Entwicklung, aber nicht für die Produktion geeignet. In der Produktion sollte auf SQL Server oder eine andere relationale Datenbank umgestellt werden.
Minimal APIs: Verbessert die Startleistung und die Laufzeiteffizienz durch geringeren Overhead.
Native AOT (Optional): Kann für weitere Performance-Verbesserungen durch Vorabkompilierung integriert werden.

//*************************************************
Fazit
//*************************************************
Dieses Projekt demonstriert einen modernen Ansatz zur API-Entwicklung mit Clean Architecture und den neuesten Funktionen von .NET. 
Es ist gut strukturiert für Erweiterungen, geeignet für Unternehmensanwendungen und bietet eine solide Basis für robuste Tests.
