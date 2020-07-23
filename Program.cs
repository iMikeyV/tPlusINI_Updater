using System;
using System.Collections.Generic;
using System.IO;
/*************************************************************
              TESTED ON LOCAL HELPDESK PC 41 AND TEST LAB
                   Have not tested on any store PC
**************************************************************/
static void Main(string[] args)
        {
              //path of ini
            string path = @"C:\txnplus\ADMIN\";
            //ini name
            string file = "DBSTPS.INI";
            //variable to hold user choice
            string userSelection;
 
            //Stream reader object
            StreamReader inputFile;
            //Set streamreader to path + file
            inputFile = File.OpenText(path + file);
            //List to hold contents of file
            List<string> Lines = new List<string>();
            //Variable to hold individual lines
            string line;
            //While file did not reach the end
            int setTo = 0;
            while (!inputFile.EndOfStream)
            {
                //Sets line to read the line
                line = inputFile.ReadLine();
                //adds line to Lines list
                Lines.Add(line);
                //Shows what it is currently set to: "2 or 3 registers"
                if (line.Equals("ProxyIPAddrs=172.16.250.1;172.16.250.2;172.16.250.3"))
                {
                    Console.WriteLine("Store is set for 3 registers");
                    setTo = 3;
                }
                if (line.Equals("ProxyIPAddrs=172.16.250.1;172.16.250.2"))
                {
                    Console.WriteLine("Store is set for 2 registers");
                    setTo = 2;
                }
            }
            //close file
            inputFile.Close();
            //Ask user how many registers are in the store
            Console.WriteLine("How many registers are in the store?");
            //Gets user choice
            userSelection = Console.ReadLine();
 
            //if choice = 2
            if (userSelection.Equals("2") && setTo == 3)
            {
                //Comments out  the 3 register line, and uncomments the 2 register line
                Lines[Lines.FindIndex(ind => ind.Equals(";ProxyIPAddrs=172.16.250.1;172.16.250.2"))] = "ProxyIPAddrs=172.16.250.1;172.16.250.2";
                Lines[Lines.FindIndex(ind => ind.Equals("ProxyIPAddrs=172.16.250.1;172.16.250.2;172.16.250.3"))] = ";ProxyIPAddrs=172.16.250.1;172.16.250.2;172.16.250.3";
            }
            //if choice = 3
            if (userSelection.Equals("3") && setTo == 2)
            {
                //Comments out the 2 register line, and uncomments the 3 register line
                Lines[Lines.FindIndex(ind => ind.Equals("ProxyIPAddrs=172.16.250.1;172.16.250.2"))] = ";ProxyIPAddrs=172.16.250.1;172.16.250.2";
                Lines[Lines.FindIndex(ind => ind.Equals(";ProxyIPAddrs=172.16.250.1;172.16.250.2;172.16.250.3"))] = "ProxyIPAddrs=172.16.250.1;172.16.250.2;172.16.250.3";
            }
 
            //Backs up DPSTPS.INI to DPSTPS.INIOLD (overwrites any dpstps.iniold by deleting first)
            File.Delete(path + file + "old");
            File.Move(path + file, path + file + "old");
            //Writes new DPSTPS.INI
            StreamWriter newFile = new StreamWriter(path + file, true);
            foreach (string x in Lines)
            {
                newFile.WriteLine(x);
            }
            newFile.Close();
        }
