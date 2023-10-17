# API Voorbeeld

In dit voorbeeld kun je zien hoe je met een backend API kunt communiceren.
In dit geval betreft het een [Cockpit CMS](https://getcockpit.com) backend met een standaard JSON API.

Deze solution is weliswaar een "gewone" console applicatie, maar de indeling is zo gemaakt dat de `App`-class uitwisselbaar is met andere C# projecten.

## Structuur
Het programma begint bij `Program.cs`, dit is het main entry point voor de applicatie. 
Andere files:  
`App.cs`: deze class bevat de "hoofd routine", hierin staan 2 public functies: `getCustomers` en `createCustomer`. Deze public methods roepen op hun beurt 2 (generieke) private methods aan. 

In `fetchData` wordt op basis van de URL (die via `Config.CreateUrl` geconstrueerd wordt) de API van Cockpit aangesproken. De "collection" `Customers` wordt vervolgens in [JSON-formaat](https://www.json.org/json-en.html) gedownload.

De generieke functie `putData` verwacht ook een url (een `public static string` in  `Config.cs`) en een JSON object in de vorm van een "geserializede" string. Deze functie **POST** middels een `HttpWebRequest` naar het juiste API-endpoint op de Cockpit Server.

Je ziet dat zowel in de `getCustomers` en `createCustomer` functies gebruik gemaakt wordt van de methode `JavaScriptSerializer().Deserialize<Object>(var)`. Waarbij `Object` staat voor het specifieke object in Model en `var` de gedownloade stream van data is. 

Hoewel deze introductie verre van compleet is, is dit wel een mooi startpunt om een API laag voor C# te maken. 


## Update
Toegevoegd aan de `Customer` collection (Veld: Task, type `Repeater`): 
````json
{
  "field": {
    "type": "set",
    "options": {
      "fields": [
        {
          "name": "titel",
          "type": "text",
          "label": "Titel van de taak"
        },
        {
          "name": "beschrijving",
          "type": "wysiwyg",
          "toolbar": [
            "bold",
            "italic"
          ],
          "label": "Handelingen"
        },
        {
          "name": "activate",
          "label": "Activeren?",
          "type": "boolean",
          "default": true
        },
        {
          "name": "taskCompleted",
          "label": "Uitgevoerd",
          "type": "boolean",
          "default": false
        }
      ]
    }
  }
}
````
Hierdoor is het `Customer` model uitgebreid met de `Tasks` property. 