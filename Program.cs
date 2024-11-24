using System; 
using System.IO; 
public class PokemonBattleSim { 
    public static void Main() { 
        Console.Clear(); 

        string[] mons = Pokemon.GetAllPokemonInfo(); 
        
        for (int i = 0; i < 1382; i++) {
            Pokemon mon = new Pokemon(mons[i]); 
            Console.WriteLine(mon); 
        } 
        
        Console.ReadLine(); 
    } 
} 