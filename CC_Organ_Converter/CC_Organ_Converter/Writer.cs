using System;
using System.IO;

namespace CC_Organ_Converter{ 
    internal class Writer
    {

        private readonly string[,] notes =
        //Array Format
        //  { Great Octave , pitch , Note }
        {
            // Under Octaves are marked with a _-1 after the instroment tag
            {"-1", "0.500000", "F#1"},
            {"-1", "0.529732", "G1"},
            {"-1", "0.561231", "G#1"},
            {"-1", "0.594604", "A1"},
            {"-1", "0.629961", "A#1"},
            {"-1", "0.667420", "B1"},
            {"-1", "0.707107", "C2"},
            {"-1", "0.749154", "C#2"},
            {"-1", "0.793701", "D2"},
            {"-1", "0.840896", "D#2"},
            {"-1", "0.890899", "E2"},
            {"-1", "0.943874", "F2"},
            {"-1", "1.000000", "F#2"},
            {"-1", "1.059463", "G2"},
            {"-1", "1.122462", "G#2"},
            {"-1", "1.189207", "A2"},
            {"-1", "1.259921", "A#2"},
            {"-1", "1.334840", "B2"},
            {"-1", "1.414214", "C3"},
            {"-1", "1.498307", "C#3"},
            {"-1", "1.587401", "D3"},
            {"-1", "1.681793", "D#3"},
            {"-1", "1.781797", "E3"},
            {"-1", "1.887749", "F3"},
        // Start of the normal Range for Noteblocks
            {"0", "0.500000", "F#3"},
            {"0", "0.529732", "G3"},
            {"0", "0.561231", "G#3"},
            {"0", "0.594604", "A3"},
            {"0", "0.629961", "A#3"},
            {"0", "0.667420", "B3"},
            {"0", "0.707107", "C4"},
            {"0", "0.749154", "C#4"},
            {"0", "0.793701", "D4"},
            {"0", "0.840896", "D#4"},
            {"0", "0.890899", "E4"},
            {"0", "0.943874", "F4"},
            {"0", "1.000000", "F#4"},
            {"0", "1.059463", "G4"},
            {"0", "1.122462", "G#4"},
            {"0", "1.189207", "A4"},
            {"0", "1.259921", "A#4"},
            {"0", "1.334840", "B4"},
            {"0", "1.414214", "C5"},
            {"0", "1.498307", "C#5"},
            {"0", "1.587401", "D5"},
            {"0", "1.681793", "D#5"},
            {"0", "1.781797", "E5"},
            {"0", "1.887749", "F5"},
            {"0", "2.000000", "F#5"},
        //End of the Normal Range for Noteblocks
        //Upper Octaves are marked with a _1 after the instroment tag
            {"1", "0.529732", "G5"},
            {"1", "0.561231", "G#5"},
            {"1", "0.594604", "A5"},
            {"1", "0.629961", "A#5"},
            {"1", "0.667420", "B5"},
            {"1", "0.707107", "C6"},
            {"1", "0.749154", "C#6"},
            {"1", "0.793701", "D6"},
            {"1", "0.840896", "D#6"},
            {"1", "0.890899", "E6"},
            {"1", "0.943874", "F6"},
            {"1", "1.000000", "F#6"},
            {"1", "1.059463", "G6"},
            {"1", "1.122462", "G#6"},
            {"1", "1.189207", "A6"},
            {"1", "1.259921", "A#6"},
            {"1", "1.334840", "B6"},
            {"1", "1.414214", "C7"},
            {"1", "1.498307", "C#7"},
            {"1", "1.587401", "D7"},
            {"1", "1.681793", "D#7"},
            {"1", "1.781797", "E7"},
            {"1", "1.887749", "F7"},
            {"1", "2.000000", "F#7"}
        };

        // More of da Variables

        string path;
        string export_name;
        Logger log;

        public Writer(string path, string export_name, Logger log)
        {
            this.path = path;
            this.export_name = export_name;
            this.log = log;
        }

        // Writen Format
        /*
         time, instrument, note (convertet for the pitch value and the Grate Octave)
         */

        public void write_line(int time, string instroment, string great_octave , string pitch)
        {
            string output_note = "Null";
            // Using the great_octave and the pitch to find da note
            for(int i = 0; i < notes.GetLength(0); i++) 
            {
                
                if (great_octave == notes[i,0])
                {
                    if(pitch == notes[i, 1])
                    {
                        output_note = notes[i,2];
                    }
                }
            }
            //writing da expo file
            using (StreamWriter writer = new StreamWriter(path + "\\" + export_name + ".txt", true))
            {
                writer.WriteLine($"{time},{instroment},{output_note}");
            }
            
        }
    }
}
