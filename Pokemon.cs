public class Pokemon { 
    String name; 
    int[] baseStats = new int[6]; 
    int[] ivs = new int[6]; 
    int[] evs = new int[6]; 
    String[] type = new string[2]; 
    //String nature; 
    int level; 
    // should add nickname 

    // new pokemon with no info  
    public Pokemon() { 
        name = "N/A"; 
        baseStats = new int[] {1, 1, 1, 1, 1, 1}; 
        ivs = new int[] {0, 0, 0, 0, 0, 0}; 
        evs = new int[] {0, 0, 0, 0, 0, 0}; 
        level = 1; 
        type[0] = "none"; 
        type[1] = "none"; 
        //nature = "serious"; 
    }

    // new pokemon with name, base stats, level, typing 
    public Pokemon(String n, int[] bS, int lvl, String[] t) { 
        name = n; 
        for (int i = 0; i < 6; i++) 
            baseStats[i] = bS[i]; 
        level = lvl; 
        type[0] = t[0];
        type[1] = t[1];  
        //nature = nat; 
    }

    // string representation 
    public override String ToString() { 
        // add species name 
        String str = ""; 
        str += name; 

        // add types 
        str += "\tType: " + (type[1] == "none" ? Capitalize(type[0]) : Capitalize(type[0]) + "\\" + Capitalize(type[1])) + "\n"; 

        // add stats 
        str += "HP\tAtk\tDef\tSpAtk\tSpDef\tSpe\n"; 
        foreach (int statVal in baseStats) 
            str += statVal + "\t"; 
        
        return str; 

        // should add evo line and evo stage 
    }

    // capitalize the first letter of a string
    //      i dont really know what class to put this in tbh 
    //      i want it to be able to be called on a String like .Substring() but idk how to access that class 
    //      (or if im even supposed to) 
    public static String Capitalize(String str) { 
        str = Char.ToUpper(str[0]) + str.Substring(1, str.Length - 1); 
        
        return str; 
    }
} 