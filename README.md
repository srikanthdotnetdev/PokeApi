# PokeApi

# About the App

##### The App is about developing 2 end points for the Poekmon.co api. The first endpoint gets the pokemon with below-mentioned schema.
##### If pokemon does not exist then it sends a message that pokemon does not exist, the second endpoint brings the pokemon data but the description will be translated using Yoda translation if the habitat of pokemon cave or the pokemon is legendary. 
##### For other pokemons the description will be translated to Shakespeare translation. The app uses following URLs for translating the description. 

##### ShakespeareUrl = "https://api.funtranslations.com/translate/shakespeare.json";
##### YodaUrl = "https://api.funtranslations.com/translate/yoda.json";

##### when the the application failed to translate the data from above apis . then the application keeps the default description.

##### The following decisions are made based on nature of data that the application retrieves from an external api(pokeapi.co). The data of pokemon is always constant, it's not dynamic data like stock market nifty. so for static data, it's not good always for our application to make a call to external API and bring the same data.

##### The second type of data that our application retrieves is translations from fun translations. which only can serve 60 API calls.

##### Just avoid fetching data several times from poke API and fun translations, it's better to maintain our own local database. The database needs to be very lightweight and NoSQL(since we are not doing transactions here.)  so I chose one lightweight database (lite db). 

##### so when ever a call is made to fetch the pokemon, the application look for the requested pokemon in the database. if it is not found in the database then it fetches from pokeapi.co. and write the pokemon into the database. So when the next time we requested the same database the application delivers it from the local database.


##### For translated pokemons, the application stores data after translating it. to make things very clear. the application  maintains different collections in database for translated and non translated pokemons.

##### But sometimes the translation API fails in this case the application only stores non translated pokemon. in these cases, we need to delete the local datastore and again request the pokemon to get from an external API.

# Decision Making and Architecture

##### The Diagram below shows the architecture of the application.



### creaing a Pokemon api

###### 1) Endpoint 1: 
/Get/Pokemon/PokemonName
ex: localhost:5000/pokemon/mewtwo

###### Pokemon schema
{
Name,
StandardDescription,
Habitat,
IsLegendary
}

##### 2) Endpoint 2
/Get/pokemon/translated/PokemonName
same schema but one condition
if Habitat is cave or IsLegendary is true then apply yoda translation

### for all other PokeMon apply shakespeare translation
incase if we are not able to translate then we use standard description.
<img width="881" alt="architecture" src="https://user-images.githubusercontent.com/41447370/149819909-8fe13d40-dbf4-4b67-874b-043c0d3622be.PNG">

# Understanding the read and writes in the application

#### The application implements CQRS(Command Query responsibilty saggregation)

![Cqrs](https://user-images.githubusercontent.com/41447370/149825415-0b33d943-e9e0-420d-a7da-6f01dab70824.png)

#### As shown in Diagram the The read and writes are perfomed through readquery and create or delete commands.

##### In addition to mentioned api(end point 1 and end point 2), the application also supports (delete and post requsts) and a graphql end point.

##### delete request is useful to delete the complete data in the local database. Each endpoint is having one delete action which delete only data of a particular collection.The post request takes a list of pokemon names as part body and returns them as response.

##### The graphQL end point solves the problem of under or overfetching of data.


