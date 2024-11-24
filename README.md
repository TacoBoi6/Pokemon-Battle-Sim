exe is in the `program` folder.  
Currently a work in progress.  

## Plans  
This is a personal, fun project which aims to replicate Pokemon's battling system!  
It will include all of the necessary info about the Pokemon, and that info will be customizable.  
The actual battling portion will be coming a little while later. 
More precise plans can be found in `todo.txt`.  

## Dex  
Necessary columns for a Pokemon to function, if you want to add your own Fakemon, in order:  
- `Pokemon Id`,`Pokedex Number`,`Pokemon Name`, `Alternate Form Name` for identification  
    - `Pokedex Number` is the Pokemon's National Pokedex number, as it appears in game  
    - `Pokemon Id` is similar to the Pokedex number, but alternate forms have their own unique number  
        - More info on how IDs work can be found further down  
- `Pokemon Weight`  
- `Primary Type`, `Secondary Type`  
- `Primary Ability` , `Secondary Ability` , `Hidden Ability` , `Special Event Ability`  
- `Health Stat` , `Attack Stat` , `Defense Stat` , `Special Attack Stat` , `Special Defense Stat` , `Speed Stat` , `Base Stat Total`  
- `Pre-Evolution Pokemon Id` , `Evolution Details`  
    - Remember, `Pre-Evolution Pokemon Id` is the ID, not Pokedex Number  
    - `Evolution Details` is just a description of how to evolve, and is not really used aside from being written to the screen  

## Moves  
To be added.  

## Abilities  
To be added.  
Technically, Pokemon already have their abilities listed, but I will need to add a way for them to function within the game. Currently they just sit there and look pretty.  

## Items  
To be added.  
Lowest priority.  

## Other Notes  
Any time a Pokemon has nothing for a certain parameter, such as Charmander having no second ability or second type, enter "NULL". No quotation marks, of course.  

<dl>
    <dt>How do Pokemon IDs work?</dt>  
    <dd>Pokemon IDs are found using the following:</dd>  
    <dd>If the Pokemon has no alternate forms (AKA its Pokedex Number is unique), the ID is just the Pokedex Number</dd>  
    <dd>If the Pokemon has alternate form(s) (AKA there are duplicate Pokedex Numbers), the ID is the Pokedex Number + 2000 + the number of preceding Alternate Forms</dd>  
</dl>

<dl>
    <dt>For example, consider Mega Venusaur and Gigantamax Charizard</dd>  
    <dd>Mega Venusaur has the Pokedex Number 3, but that is already taken by base form Venusaur</dd>  
    <dd>Thus, the ID is 3 (Pokedex) + 2000 (Alt Form) + 0 (Preceding Alt Forms), which is 2003</dd>  
    <dd>    Mega Venusaur is the first Alt Form in the list, so there are no preceding Alt Forms</dd>  
    <dd>Gigantamax Charizard has the Pokedex Number 6, but that is already taken by base form Charizard  
    <dd>Thus, the ID is 6 (Pokedex) + 2000 (Alt Form) + 4 (Preceding Alt Forms), which is 2010</dd>  
    <dd>    Keep in mind that there are 4 alternate forms before Gigantamax Charizard:  
    <dd>    Mega Venusaur, Gigantamax Venusaur, Mega Charizard Y, Mega Charizard X  
</dl>

<dl>
    <dt>Any Pokemon you add needs to follow these guidelines, otherwise the program may fall apart!</dt> 
</dl>
