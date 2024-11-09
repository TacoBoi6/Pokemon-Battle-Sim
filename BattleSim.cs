using System; 
public static class BattleSim { 
    public static void Main() { 
        Console.WriteLine("Starting Project"); 
        const string POKEMON_INFO_PATH = "C:\\Personal Programming\\PokemonBattleSim\\PokemonInfo\\AllPokemon SLIMMED.csv";

        Console.WriteLine("What pokemon are you looking for?"); 
        Pokemon myPoke = new Pokemon(Console.ReadLine(), POKEMON_INFO_PATH); 

        Console.WriteLine(myPoke); 

    }
}