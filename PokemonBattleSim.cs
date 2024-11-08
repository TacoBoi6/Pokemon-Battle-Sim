using System; 
public static class PokemonBattleSim { 
    public static void Main() { 
        Pokemon venusaur = new Pokemon("Venusaur", new int[] {80, 82, 83, 100, 100, 80}, 100, new string[] {"grass", "poison"}, "serious"); 
        Pokemon charizard = new Pokemon("Charizard", new int[] {78, 84, 78, 109, 85, 100}, 100, new string[] {"fire", "flying"}, "serious"); 
        Pokemon blastoise = new Pokemon("Blastoise", new int[] {79, 83, 100, 85, 105, 78}, 100, new string[] {"water", "none"}, "serious"); 

        Console.WriteLine(venusaur); 
        Console.WriteLine(charizard); 
        Console.WriteLine(blastoise); 
    }
}