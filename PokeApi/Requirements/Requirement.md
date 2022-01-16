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

1. Launch the app in Visual Studio, VS Code, or on the command line (outside docker).  View the app at http://localhost:5000/  This creates the `db/Site.db` file needed in other demos.  (Note that the Dockerfile doesn't support Visual Studio's assumptions, so we're not debugging inside the container from Visual Studio.)

2. Run the "dev" solution with `docker-compose -f docker-compose.dev.yaml up` and browse to http://localhost:5010/.  Note that the local run content is already in place -- the `db/Site.db` file is copied into the container in `Dockerfile.dev`.  Run `docker-compose -f docker-compose.dev.yaml down` to stop it.  Now start it again, and notice the new data created in this container is gone.  This is great for development when you want to reset the database with each run.

3. Run the "prod" solution with `docker-compose -f docker-compose.prod.yaml up` and browse to http://localhost:5020/.  In this example, a volume maps the `db/Site.db` into the container, so rows created in the container are available after restart.  Run `docker-compose -f docker-compsoe.prod.yaml down` to stop it.  Restart it, and notice the previous content is still present.  This is great for production scenarios when we need to preserve customer data across container restarts.
