# Requirements 
 
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