using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace CC_Organ_Converter
{
    internal class Reader
    {   //Variables for da data
        string path;
        Logger log;
        Writer writer;


        string instrument;
        string great_octave;
        string pitch;

        bool line_has_pitch;

        public Reader(string path ,Writer writer ,Logger log)
        {
            this.path = path;
            this.writer = writer;
            this.log = log;
        }

        public void read_file()
        {
            // Determening the highest folder number
            log.WriteLineToLog("Determening the highest File number" , "Reader");

            int fileNr_highest    = 0;
            int fileNr_current     = 0;

            while (true)
            {

                if (File.Exists(path + @"\" + fileNr_current + ".mcfunction"))
                {
                    fileNr_highest = fileNr_current;
                }

                if(fileNr_current > fileNr_highest + 100)
                {
                    break;
                }

                fileNr_current++;
            }

            log.WriteLineToLog("Highest file number is: " + fileNr_highest, "Reader");

            // Reading all lines of da files
            fileNr_current = 0;

            while (fileNr_current <= fileNr_highest)
            {
                try
                {
                    string[] content = File.ReadAllLines(path + @"\" + fileNr_current + ".mcfunction");

                    foreach (var line in content)
                    {
                        string[] word = line.Split(' ');

                        foreach (var item in word)
                        {
                            if (item.StartsWith("minecraft:block.note_block"))
                            {
                                string[] j = item.Split('.', '_');
                                this.instrument = j[3];


                                try
                                {
                                    this.great_octave = j[4];
                                }
                                catch
                                {
                                    this.great_octave = "0";
                                }
                                line_has_pitch = true;
                            }
                        }

                        if (line_has_pitch == true)
                        {
                            this.pitch = word[8];
                            writer.write_line(fileNr_current, instrument, great_octave, pitch);
                            log.WriteLineToLog("Send information to da Writer", "Reader");
                            line_has_pitch = false;
                        }

                    }
                } 
                catch 
                {
                    log.WriteLineToLog("File Nr:" + fileNr_current + "not found! Skiping to da next." ,"Reader");
                }

                fileNr_current++;
            }
        }
    }
}
