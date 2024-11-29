// A class for extra operators on strings. 
namespace StringExtensions {
    using System;
    using System.Text.RegularExpressions;
    public static class StringExtension { 
        // Method:       RemoveEscapeSequences(string)  
        // Description:  Remove all of the invisible escape sequences from the given string.  
        // Parameters:   input:     The string to have its escape sequences removed. 
        // Returns:      The given string with all escape sequences removed. 
        public static string RemoveEscapeSequences(string input) { 
            return Regex.Replace(input, @"\x1B\[[0-9;]*m", ""); 
        }

        // Method:       PadVisible(this string, int, int = -1, char = ' ')  
        // Description:  Pad the given string based on the visible characters. 
        //               Negative side is left, positive side is right. 
        //               Does nothing if side is 0. 
        // Parameters:   input:         The string to be padded based on its visible characters. 
        //               width:         The width to pad to. 
        //               side = 1       Which side to pad. Negative = left; Positive = right. 
        //                              1 (right) by default. 
        //               padChar = ' '  The character to pad with. 
        //                              Space by default. 
        // Returns:      The string padded to the given width, on the given side, using the given char. 
        public static string PadVisible(this string input, int width, int side = 1, char padChar = ' ') { 
            int inputLength = RemoveEscapeSequences(input).Length; 
            string padding = ""; 

            for (int i = 0; i < width - inputLength; i++) { 
                padding += padChar; 
            }
            
            if (side > 0) 
                return input + padding;  
            else if (side < 0) 
                return padding + input; 
            return input;  
        }
    }
}