using System;
public class Pokemon { 
    static string RESET_FORMATTING = "\u001b[0m"; 
    int ID, dexNumber, BST, prevoID; 
    int[] stats; 
    string species, form, evoDetails; 
    string[] types, abilities; 
    double weight; 

    public Pokemon(int ID, int dexNumber, string species, string form, double weight, string[] types, string[] abilities, int[] stats, int BST, int prevoID, string evoDetails) { 
        this.ID = ID; 
        this.dexNumber = dexNumber; 
        this.species = species; 
        this.form = form; 
        this.weight = weight; 
        this.types = types; 
        this.abilities = abilities; 
        this.stats = stats; 
        this.BST = BST; 
        this.prevoID = prevoID; 
        this.evoDetails = evoDetails; 
    } 

    public Pokemon(string infoString) { 
        object[] info = infoString.Split(','); 

        // ID 
        this.ID = Convert.ToInt32(info[0]); 
        // dexNumber
        this.dexNumber = Convert.ToInt32(info[1]); 
        // species 
        this.species = (string) info[2]; 
        // form 
        this.form = (string) info[3]; 
        // weight 
        this.weight = Convert.ToDouble(info[4]); 
        // types 
        this.types = new string[] { (string) info[5], (string) info[6] }; 
        // abilities 
        this.abilities = new string[] { (string) info[7], (string) info[8], (string) info[9], (string) info[10] };
        // stats 
        this.stats = new int[] { Convert.ToInt32(info[11]), Convert.ToInt32(info[12]), Convert.ToInt32(info[13]), Convert.ToInt32(info[14]), Convert.ToInt32(info[15]), Convert.ToInt32(info[16]) }; 
        // bst
        this.BST = Convert.ToInt32(info[17]); 
        // prevoID
        this.prevoID = ((string) info[18] == "NULL") ? 0 : Convert.ToInt32(info[18]); 
        // evoDetails 
        this.evoDetails = (string) info[19]; 

    } 

    /*public static Pokemon[] GetAllPokemon() { 
        string[] allPokemonInfo = GetAllPokemonInfo(); 
        Pokemon[] allPokemon = new Pokemon[allPokemonInfo.Length]; 

        for (int i = 0; i < allPokemonInfo.Length; i++) { 
            allPokemon[i] = new Pokemon();
        }
    }*/

    public static string[] GetAllPokemonInfo() { 
        // Back out once from Program folder; End up in PokemonBattleSim; Enter PokemonInfo -> PokemonInfo.csv 
        string Pokemon_Info_Path = Path.GetFullPath("..\\PokemonInfo\\PokemonInfo.csv"); 

        // Get every line of PokemonInfo 
        string[] allInfo = File.ReadAllLines(Pokemon_Info_Path); 

        // Remove the column headers 
        string[] allInfoWithoutHeader = new string[allInfo.Length - 1]; 
        for (int i = 1; i < allInfo.Length; i++)  
            allInfoWithoutHeader[i-1] = allInfo[i]; 

        // Return every line of PokemonInfo (without headers) as an array 
        return allInfoWithoutHeader; 
    }

    public override string ToString() {
        // add species name 
        string str = species; 

        // add form name 
        str += (form == "NULL") ? "" : "-" + form; 

        // add types 
        // Type: TYPE1    or    Types: TYPE1/TYPE2
        str += "\t" + (types[1] == "NULL" ? TypeWithColour(types[0]) : TypeWithColour(types[0]) + "/" + TypeWithColour(types[1])) + "\n"; 

        // add base abilities 
        // Ability: ABILITY    or    Abilities: ABILITY1, ABILITY2 
        str += ((abilities[1] == "NULL") ? "Ability: " + abilities[0] : "Abilities: " + abilities[0] + ", " + abilities[1]) + "\n"; 
        
        // add hidden abilities 
        // empty    or    Hidden Ability: ABILITY3 
        str += ((abilities[2] == "NULL") ? "" : "Hidden Ability: " + abilities[2] + "\n"); 

        // add event abilities 
        // empty    or    Event Ability: ABILITY4 
        str += ((abilities[3] == "NULL") ? "" : "Event Ability: " + abilities[3] + "\n");

        // add stats 
        str += "HP\tAtk\tDef\tSpAtk\tSpDef\tSpe\tTotal\n"; 
        foreach (int statVal in stats) 
            str += statVal + "\t"; 
        str += BST; 

        // PREVOID COLUMN IS WRONG 
        /*
        // add prevo 
        if (prevoID != 0) { 
            str += "\nThis Pokemon evolves from "; 
            str += GetInfo(prevoID, POKEMON_INFO_PATH)[2]; 
        }
        */
        
        return str; 

        // should add evo line and evo stage 
    } 

    /*public void Write() { 
        // Write species name 
        Console.Write(species); 

        // add form name 
        if (form != "NULL")
            Console.Write("-" + form);

        // add types 
        // Type: TYPE1    or    Types: TYPE1/TYPE2
        // First type
        Console.Write("\t"); 
        WriteType(types[0]); 
        // Second type, if it exists 
        if (types[1] != "NULL") { 
            Console.Write("/"); 
            WriteType(types[1]); 
        }
        Console.Write("\n"); 

        // add base abilities 
        // Ability: ABILITY    or    Abilities: ABILITY1, ABILITY2 
        if (abilities[1] == "NULL")
            Console.WriteLine("Ability: " + abilities[0]); 
        else 
            Console.WriteLine("Abilities: {0}, {1}", abilities[0], abilities[1]); 
        
        // add hidden abilities 
        // empty    or    Hidden Ability: ABILITY3 
        if (abilities[2] != "NULL")
            Console.WriteLine("Hidden Ability: {0}", abilities[2]); 

        // add event abilities 
        // empty    or    Event Ability: ABILITY4 
        if (abilities[3] != "NULL")
            Console.WriteLine("Event Ability: {0}", abilities[3]); 

        // add stats 
        Console.WriteLine("HP\tAtk\tDef\tSpAtk\tSpDef\tSpe\tTotal"); 
        foreach (int statVal in stats) 
            Console.Write("{0}\t", statVal); 
        Console.WriteLine(BST); 

    }*/

    public static string TypeWithColour(string type) { 
        // Set the colour according to the given type
        switch (type) { 
            case "Normal": 
                return "\u001b[38;2;255;255;255mNormal\u001b[0m"; // White
            case "Fire": 
                return "\u001b[38;2;252;10;10mFire\u001b[0m"; // Red 
            case "Fighting": 
                return "\u001b[38;2;212;103;0mFighting\u001b[0m"; // Reddish Brown  
            case "Water": 
                return "\u001b[38;2;54;152;249mWater\u001b[0m"; // Blue
            case "Flying": 
                return "\u001b[38;2;129;185;239mFlying\u001b[0m"; // Cyan 
            case "Grass": 
                return "\u001b[38;2;117;194;54mGrass\u001b[0m"; // Green 
            case "Poison": 
                return "\u001b[38;2;146;68;147mPoison\u001b[0m"; // Purple
            case "Electric": 
                return "\u001b[38;2;250;192;0mElectric\u001b[0m"; // Yellow 
            case "Ground": 
                return "\u001b[38;2;205;175;83mGround\u001b[0m"; // Light Brown
            case "Psychic": 
                return "\u001b[38;2;238;72;128mPsychic\u001b[0m"; // Pink
            case "Rock": 
                return "\u001b[38;2;174;152;80mRock\u001b[0m"; // Brown
            case "Ice": 
                return "\u001b[38;2;125;216;247mIce\u001b[0m"; // Light Cyan
            case "Dragon": 
                return "\u001b[38;2;1;77;78mDragon\u001b[0m"; // Blueish Purple
            case "Ghost": 
                return "\u001b[38;2;71;70;146mGhost\u001b[0m"; // Dark Purple 
            case "Dark": 
                return "\u001b[38;2;0;0;0mDark\u001b[0m"; // Black
            case "Steel": 
                return "\u001b[38;2;143;142;158mSteel\u001b[0m"; // Grey 
            case "Fairy": 
                return "\u001b[38;2;225;149;225mFairy\u001b[0m"; // Light Pink
            case "Bug": 
                return "\u001b[38;2;135;150;15mBug\u001b[0m"; // Dull Green
            default: 
                return "INVALID TYPE "; 
        }
    }

} 