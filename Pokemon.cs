using System;
using StringExtensions;
public class Pokemon { 
    public static string RESET_FORMATTING = "\u001b[0m"; // Reset console output to default formatting 
    public int ID { get; private set; }             // POKEMON ID
    public int DexNumber { get; private set; }      // POKEDEX NUMBER 
    public string Species { get; private set; }     // SPECIES NAME 
    public string Form { get; private set; }        // FORM NAME (hyphenated)
    public double Weight { get; private set; }      // WEIGHT 
    public string[] Types { get; private set; }     // TYPES 
    public string[] Abilities { get; private set; } // ABILITIES (1/2 Base, Hidden, Event)
    public int[] Stats { get; private set; }        // STATS (HP, Atk, Def, SpAtk, SpDef, Spe)
    public int BST { get; private set; }            // BASE STAT TOTAL 
    public int PrevoID { get; private set; }        // PRE-EVOLUTION ID (not DexNumber)
    public string EvoDetails { get; private set; }  // EVOLUTION DETAILS/METHOD 

    // Method:       Pokemon(int, int, string, string, double, string[], string[], int[], int, int, string) 
    // Description:  Generate a new Pokemon object, given all of its info separately. 
    // Parameters:   All of the values of the Pokemon object's member variables.   
    //               Can be found at the top of the class. 
    // Returns:      N/A; Constructor. 
    public Pokemon(int ID, int dexNumber, string species, string form, double weight, string[] types, string[] abilities, int[] stats, int bst, int prevoID, string evoDetails) { 
        this.ID = ID; 
        this.DexNumber = dexNumber; 
        this.Species = species; 
        this.Form = form; 
        this.Weight = weight; 
        this.Types = types; 
        this.Abilities = abilities; 
        this.Stats = stats; 
        this.BST = bst; 
        this.PrevoID = prevoID; 
        this.EvoDetails = evoDetails; 
    } 

    // Method:       Pokemon(string) 
    // Description:  Generate a new Pokemon object, given all of its info in one line. 
    // Parameters:   string infoString  : The string containing all of the values of the Pokemon's info, in order.
    // Returns:      N/A; Constructor  
    public Pokemon(string infoString) { 
        object[] info = infoString.Split(','); 

        // ID 
        this.ID = Convert.ToInt32(info[0]); 
        // dexNumber
        this.DexNumber = Convert.ToInt32(info[1]); 
        // species 
        this.Species = (string) info[2]; 
        // form 
        this.Form = (string) info[3]; 
        // weight 
        this.Weight = Convert.ToDouble(info[4]); 
        // types 
        this.Types = new string[] { (string) info[5], (string) info[6] }; 
        // abilities 
        this.Abilities = new string[] { (string) info[7], (string) info[8], (string) info[9], (string) info[10] };
        // stats 
        this.Stats = new int[] { Convert.ToInt32(info[11]), Convert.ToInt32(info[12]), Convert.ToInt32(info[13]), Convert.ToInt32(info[14]), Convert.ToInt32(info[15]), Convert.ToInt32(info[16]) }; 
        // bst
        this.BST = Convert.ToInt32(info[17]); 
        // prevoID
        this.PrevoID = ((string) info[18] == "NULL") ? 0 : Convert.ToInt32(info[18]); 
        // evoDetails 
        this.EvoDetails = (string) info[19]; 

    } 

    // Method:       GetAllPokemonInfo()  
    // Description:  Collect every line from a file containing info on every Pokemon. 
    //               Every line should be an individual Pokemon, formatted as shown in PokemonInfo.csv and the README. 
    // Parameters:   N/A
    // Returns:      Every line in the PokemonInfo.csv file, as an array. 
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

    // Method:       IndexOfPokemon(Pokemon[], Pokemon) 
    // Description:  Find the index of a Pokemon in an array of Pokemon. 
    // Parameters:   pokemonArray:      The array to search. 
    //               searchedPokemon:   The Pokemon to find. 
    // Returns:      The index of the given Pokemon in the array; -1 if it does not exist. 
    public static int IndexOfPokemon(Pokemon[] pokemonArray, Pokemon searchedPokemon) { 
        for (int i = 0; i < pokemonArray.Length; i++) { 
            if (pokemonArray[i].Equals(searchedPokemon)) 
                return i; 
        }

        return -1; 
    }

    // Method:       IndexOfPokemon(Pokemon[], string) 
    // Description:  Overload of the previous method. 
    //               Find the index of a Pokemon in an array of Pokemon, using its Species. 
    // Parameters:   pokemonArray:      The array to search. 
    //               searchedPokemon:   The Pokemon Species to find. 
    // Returns:      The index of the given Pokemon Species in the array; -1 if it does not exist. 
    public static int IndexOfPokemon(Pokemon[] pokemonArray, string searchedPokemon) { 
        for (int i = 0; i < pokemonArray.Length; i++) { 
            if (pokemonArray[i].Species.ToLower().Equals(searchedPokemon.ToLower())) 
                return i; 
        }

        return -1; 
    }

    // Method:       ToString() 
    // Description:  Generate a string representation of the given Pokemon. 
    //               Species, form, types, abilities, stats. 
    // Parameters:   N/A
    // Returns:      A string representation of the given Pokemon including species, form, types, 
    //               abilities, and stats. Types have their colour.   
    public override string ToString() {
        // Add species name and form (if there is one) (left aligned), and types (right aligned)
        string str = (Species + ((Form == "NULL") ? "" : "-" + Form)).PadVisible(27) + ((Types[1] == "NULL") ? TypeWithColour(Types[0]) : TypeWithColour(Types[0]) + "/" + TypeWithColour(Types[1])).PadVisible(26, -1) + "\n"; 
        
        // Add base abilities 
        // Ability: ABILITY    or    Abilities: ABILITY1, ABILITY2 
        str += ((Abilities[1] == "NULL") ? "Ability: " + Abilities[0] : "Abilities: " + Abilities[0] + ", " + Abilities[1]) + "\n"; 
        
        // Add hidden abilities 
        // empty    or    Hidden Ability: ABILITY3 
        str += ((Abilities[2] == "NULL") ? "" : "Hidden Ability: " + Abilities[2] + "\n"); 

        // Add event abilities 
        // empty    or    Event Ability: ABILITY4 
        str += ((Abilities[3] == "NULL") ? "" : "Event Ability: " + Abilities[3] + "\n");

        // Add stats 
        str += "HP\tAtk\tDef\tSpAtk\tSpDef\tSpe\tTotal\n"; 
        foreach (int statVal in Stats) 
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

    // Method:       Equals(Pokemon) 
    // Description:  Check if the referenced Pokemon is the same as the Parameter Pokemon.
    //               They are equal if they are the same species and form.  
    // Parameters:   Pokemon otherMon:  The Pokemon to be compared to. 
    // Returns:      True if the Pokemon are equal; 
    //               False otherwise. 
    public bool Equals(Pokemon otherMon) { 
        return this.Species.Equals(otherMon.Species) && this.Form.Equals(otherMon.Form); 
    }

    // Method:       TypeWithColour(string) 
    // Description:  Generate a coloured string for the given type. 
    //               Ordered by number of Pokemon in each type for a lil cool efficiency :]
    // Parameters:   string type:   The type to be given its colour. 
    // Returns:      The given type with its corresponding colour. 
    //               If the type is invalid, returns an empty string. 
    public static string TypeWithColour(string type) { 
        // Set the colour according to the given type
        switch (type.ToLower()) { 
            case "water": 
                return "\u001b[38;2;54;152;249mWater" + RESET_FORMATTING; // Blue
            case "normal": 
                return "\u001b[38;2;255;255;255mNormal" + RESET_FORMATTING; // White
            case "grass": 
                return "\u001b[38;2;117;194;54mGrass" + RESET_FORMATTING; // Green 
            case "flying": 
                return "\u001b[38;2;129;185;239mFlying" + RESET_FORMATTING; // Cyan 
            case "psychic": 
                return "\u001b[38;2;238;72;128mPsychic" + RESET_FORMATTING; // Pink
            case "bug": 
                return "\u001b[38;2;135;150;15mBug" + RESET_FORMATTING; // Dull Green
            case "fire": 
                return "\u001b[38;2;252;10;10mFire" + RESET_FORMATTING; // Red 
            case "poison": 
                return "\u001b[38;2;146;68;147mPoison" + RESET_FORMATTING; // Purple
            case "fighting": 
                return "\u001b[38;2;212;103;0mFighting" + RESET_FORMATTING; // Reddish Brown  
            case "dark": 
                return "\u001b[38;2;0;0;0mDark" + RESET_FORMATTING; // Black
            case "rock": 
                return "\u001b[38;2;174;152;80mRock" + RESET_FORMATTING; // Brown
            case "ground": 
                return "\u001b[38;2;205;175;83mGround" + RESET_FORMATTING; // Light Brown
            case "steel": 
                return "\u001b[38;2;143;142;158mSteel" + RESET_FORMATTING; // Grey 
            case "dragon": 
                return "\u001b[38;2;1;77;78mDragon" + RESET_FORMATTING; // Blueish Purple
            case "electric": 
                return "\u001b[38;2;250;192;0mElectric" + RESET_FORMATTING; // Yellow 
            case "ghost": 
                return "\u001b[38;2;71;70;146mGhost" + RESET_FORMATTING; // Dark Purple 
            case "fairy": 
                return "\u001b[38;2;225;149;225mFairy" + RESET_FORMATTING; // Light Pink
            case "ice": 
                return "\u001b[38;2;125;216;247mIce" + RESET_FORMATTING; // Light Cyan
            default: 
                return ""; 
        }
    }

    // Method:       GetTypeColour(string) 
    // Description:  Get the escape sequence to make text the colour of the given type. 
    //               Ordered by number of Pokemon in each type for a lil cool efficiency :]
    // Parameters:   string type:   The type to get the colour of. 
    // Returns:      The escape sequence with the colour corresponding to the given type. 
    //               If the type is invalid, returns an empty string. 
    public static string GetTypeColour(string type) { 
        switch (type.ToLower()) { 
            case "water": 
                return "\u001b[38;2;54;152;249m"; // Blue
            case "normal": 
                return "\u001b[38;2;255;255;255m"; // White
            case "grass": 
                return "\u001b[38;2;117;194;54m"; // Green 
            case "flying": 
                return "\u001b[38;2;129;185;239m"; // Cyan 
            case "psychic": 
                return "\u001b[38;2;238;72;128m"; // Pink
            case "bug": 
                return "\u001b[38;2;135;150;15m"; // Dull Green
            case "fire": 
                return "\u001b[38;2;252;10;10m"; // Red 
            case "poison": 
                return "\u001b[38;2;146;68;147m"; // Purple
            case "fighting": 
                return "\u001b[38;2;212;103;0m"; // Reddish Brown  
            case "dark": 
                return "\u001b[38;2;0;0;0m"; // Black
            case "rock": 
                return "\u001b[38;2;174;152;80m"; // Brown
            case "ground": 
                return "\u001b[38;2;205;175;83m"; // Light Brown
            case "steel": 
                return "\u001b[38;2;143;142;158m"; // Grey 
            case "dragon": 
                return "\u001b[38;2;1;77;78m"; // Blueish Purple
            case "electric": 
                return "\u001b[38;2;250;192;0m"; // Yellow 
            case "ghost": 
                return "\u001b[38;2;71;70;146m"; // Dark Purple 
            case "fairy": 
                return "\u001b[38;2;225;149;225m"; // Light Pink
            case "ice": 
                return "\u001b[38;2;125;216;247m"; // Light Cyan

            default: 
                return " "; 
        }
    }

} 