using System; 
using System.IO; 
public class PokemonBattleSim { 
    public static void Main() { 
        Console.Clear(); 
        Console.WriteLine(Pokemon.RESET_FORMATTING + "Starting program..."); 

        string[] monsInfo = Pokemon.GetAllPokemonInfo(); 
        Pokemon[] mons = new Pokemon[1383]; 
        
        for (int i = 0; i < 1382; i++) {
            mons[i] = new Pokemon(monsInfo[i]); 
        } 

        Console.WriteLine("All Pokemon have been generated!"); 

        while (true) { 
            Console.WriteLine("This is an infinite loop. Close the program to exit."); 
            Console.Write("Enter a Pokemon: "); 
            string input = Console.ReadLine().ToLower(); 
            Console.WriteLine(); 

            try {
                Console.WriteLine(mons[Pokemon.IndexOfPokemon(mons, input)]); 
            }
            catch { 
                Console.WriteLine("\"{0}\" may not exist, or you spelled it wrong, or it is unimplemented.\n", input); 
            }

        }
        
    } 
} 