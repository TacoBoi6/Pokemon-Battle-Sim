//Read a Text File
using System;
using System.IO;
public class FileReading {
    // read an entire file and write it to the screen 
    public static void ReadWholeFile(string DataPath) {
        String line;

        try {
            StreamReader sr = new StreamReader(DataPath);
            // read the first line of text
            line = sr.ReadLine().Replace(',', '\t');

            // continue to read until you reach end of file 
            while (line != null) {
                //write the line to console window
                Console.WriteLine(line);
                //Read the next line
                line = sr.ReadLine().Replace(',', '\t');
            } 

            // close the file
            sr.Close();
            Console.ReadLine();
        }
        catch(Exception e) {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally {
            Console.WriteLine("Finished with the file.");
        } 
    }
}