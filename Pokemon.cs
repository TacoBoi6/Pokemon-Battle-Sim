using System; 
using System.IO; 

public class Pokemon { 
    // all of the info included in the sheets 
    // could probably add a nickname spot too 
    int pokemonID; 
    int dexNumber;
    string name; 
    string altForm; 
    double weight; 
    string[] type; // 2 entries: type1, type2 
    string[] ability; // 4 entries: ability1, ability2, hiddenAbility, eventAbility (greninja and rockruff)
    int[] stat; // 6 entries: HP, Atk, Def, SpAtk, SpDef, Spe
    int bst; 
    int prevoID; 
    string evoDetails; 

    // default pokemon 
    public Pokemon() { 
        pokemonID = 0; 
        dexNumber = 0; 
        name = "Placeholder Name"; 
        altForm = "Placeholder AltForm"; 
        weight = 0.0; 
        type = new string[] {"NULL", "NULL"}; 
        ability = new string[] {"Ability 1", "Ability 2", "Hidden Ability", "Event Ability"}; 
        stat = new int[] {1, 1, 1, 1, 1, 1}; 
        int prevoID = 0; 
        evoDetails = "Evo Details"; 
    }

    // pokemon from species name and dataset 
    public Pokemon(string searchedPokemon, string PokemonDataPath) { 
        Console.WriteLine("Searching for {0}...", searchedPokemon); 

        string line = null; 

        try {
            StreamReader sr = new StreamReader(PokemonDataPath);
            // read the first line of text
            line = sr.ReadLine();

            // continue to read until you reach end of file or find the pokemon 
            // need to make this work with alt forms 
            while (line != null && !line.Contains("," + searchedPokemon + ",")) {   // need the commas to make sure the whole name is there 
                // Console.WriteLine(line); 
                // read the next line
                line = sr.ReadLine();
            } 

            // close the file
            sr.Close();
            // Console.ReadLine();  <--- this was freezing the program 
        }
        catch(Exception e) {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally {
            Console.WriteLine("Finished searching for {0}!", searchedPokemon);
        } 

        // pokemon was successfully found 
        if (line != null) {  
            string[] pokemonInfo = line.Split(',');  

            pokemonID = Convert.ToInt32(pokemonInfo[0]); 
            dexNumber = Convert.ToInt32(pokemonInfo[1]); 
            name = pokemonInfo[2]; 
            altForm = pokemonInfo[3]; 
            weight = Convert.ToDouble(pokemonInfo[4]); 
            type = new string[] {pokemonInfo[5], pokemonInfo[6]}; 
            ability = new string[] {pokemonInfo[7], pokemonInfo[8], pokemonInfo[9], pokemonInfo[10]}; 
            stat = new int[] {Convert.ToInt32(pokemonInfo[11]), Convert.ToInt32(pokemonInfo[12]), Convert.ToInt32(pokemonInfo[13]), Convert.ToInt32(pokemonInfo[14]), Convert.ToInt32(pokemonInfo[15]), Convert.ToInt32(pokemonInfo[16])}; 
            prevoID = Convert.ToInt32(pokemonInfo[17]); 
            evoDetails = pokemonInfo[18]; 
        }
        // pokemon not found 
        else { 
            // default constructor 
            // i want to change this somehow and make it a bit cleaner 
            // can i make it default to just doing Pokemon() here? 
            pokemonID = 0; 
            dexNumber = 0; 
            name = "Placeholder Name"; 
            altForm = "Placeholder AltForm"; 
            weight = 0.0; 
            type = new string[] {"NULL", "NULL"}; 
            ability = new string[] {"Ability 1", "Ability 2", "Hidden Ability", "Event Ability"}; 
            stat = new int[] {1, 1, 1, 1, 1, 1}; 
            int prevoID = 0; 
            evoDetails = "Evo Details"; 
        }
    }

    // pokemon from all info 
    public Pokemon(int pID, int dN, string n, string aF, double w, string[] t, string[] a, int[] s, int preID, string eD) { 
        pokemonID = pID; 
        dexNumber = dN; 
        name = n; 
        altForm = aF; 
        weight = w; 
        type = t; 
        ability = a; 
        stat = s; 
        int prevoID = preID; 
        evoDetails = eD; 
    }

    // string representation 
    public override string ToString() { 
        // add species name 
        string str = ""; 
        str += name; 

        // add types 
        str += "\tType: " + (type[1] == "NULL" ? type[0] : type[0] + "\\" + type[1]) + "\n"; 

        // add stats 
        str += "HP\tAtk\tDef\tSpAtk\tSpDef\tSpe\n"; 
        foreach (int statVal in stat) 
            str += statVal + "\t"; 
        
        return str; 

        // should add evo line and evo stage 
    }
}