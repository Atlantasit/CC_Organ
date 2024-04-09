using System;
using System.IO;
using System.Reflection;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace CC_Organ_Converter
{
    //Dis Programm was made by Atlantasit (yes im a Furry)
    //and i will place the card AL-Luma'raj XD
    internal class main
    {
        static void Main(string[] args)
        {
            string folder_noteinfos;
            string export_name = "New_Song";

            //initialisation of da objects and shit
            Logger      log         = new Logger();
            Set_folder  set_Folder  = new Set_folder(log);

            log.CreateLog();

            Console.WriteLine("Hello and welcome to the CC Organ converter programm!");
            Console.WriteLine("Version: 1.1");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Please insert a Name for the exported song");
            export_name = Console.ReadLine();
            Console.WriteLine("Converting files pls wait :D");

            folder_noteinfos = set_Folder.set_noteinfo_folder();    //for da reader constructor

            Writer      writer      = new Writer(folder_noteinfos, export_name, log);
            Reader      reader      = new Reader(folder_noteinfos, writer ,log);
            
            reader.read_file();

            Console.WriteLine("Done have fun with da song!");
            return; 
        }

    }
}
