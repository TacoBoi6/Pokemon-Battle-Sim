public class Pokemon { 
    String name; 
    int[] baseStats = new int[6]; 
    int[] ivs = new int[6]; 
    int[] evs = new int[6]; 
    String[] type = new string[2]; 
    String nature; 
    int level; 

    // new pokemon with no info  
    public Pokemon() { 
        name = "N/A"; 
        baseStats = new int[] {1, 1, 1, 1, 1, 1}; 
        ivs = new int[] {0, 0, 0, 0, 0, 0}; 
        evs = new int[] {0, 0, 0, 0, 0, 0}; 
        level = 1; 
        type[1] = "none"; 
        type[2] = "none"; 
        nature = "serious"; 
    }

    // new pokemon with name, base stats, level, typing, nature 
    public Pokemon(String n, int[] bS, int lvl, String[] t, String nat) { 
        name = n; 
        for (int i = 0; i < 6; i++) 
            baseStats[i] = bS[i]; 
        level = lvl; 
        type[1] = t[1];
        type[2] = t[2];  
        nature = nat; 
    }

    // string representation 
    public override String ToString() { 
        String str = ""; 
        str += name + "\n"; 

        str += "HP\tAtk\tDef\tSpAtk\tSpDef\tSpe\n"; 
        foreach (int statVal in baseStats) 
            str += statVal + "\t"; 
        


        return str; 

        // should add evo line and stage 
    }
} 