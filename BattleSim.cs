using System; 
public static class BattleSim { 
    public static void Main() { 
        Pokemon venusaur = new Pokemon("Venusaur", new int[] {80, 82, 83, 100, 100, 80}, 100, new string[] {"grass", "poison"}); 
        Pokemon charizard = new Pokemon("Charizard", new int[] {78, 84, 78, 109, 85, 100}, 100, new string[] {"fire", "flying"}); 
        Pokemon blastoise = new Pokemon("Blastoise", new int[] {79, 83, 100, 85, 105, 78}, 100, new string[] {"water", "none"}); 

        Console.WriteLine(venusaur + "\n"); 
        Console.WriteLine(charizard + "\n"); 
        Console.WriteLine(blastoise + "\n"); 
    }
}