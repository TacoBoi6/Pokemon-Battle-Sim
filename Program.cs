using System; 
using System.IO; 
public class PokemonBattleSim { 
    public static void Main() { 
        Console.Clear(); 
        Console.WriteLine("Starting program..."); 

        string[] monsInfo = Pokemon.GetAllPokemonInfo(); 
        Pokemon[] mons = new Pokemon[1383]; 
        
        for (int i = 0; i < 1382; i++) {
            mons[i] = new Pokemon(monsInfo[i]); 
        } 

        Console.WriteLine("All Pokemon have been generated!"); 

        while (true) { 
            Console.WriteLine("\nIf nothing shows up, you probably spelled it wrong. Or it\'s an alternate form that isn\'t implemented yet.");
            Console.WriteLine("This is an infinite loop. Close the program to exit."); 
            Console.Write("Enter a Pokemon: "); 
            string input = Console.ReadLine().ToLower(); 
            Console.WriteLine(); 

            for (int i = 0; i < mons.Length - 1; i++) { 
                if (mons[i].species.ToLower().Equals(input)) {
                    Console.WriteLine(mons[i]); 
                    break; 
                } 
            }

        }
        
    } 
} 