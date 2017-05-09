using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hackthissite___prog_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] SWlines = System.IO.File.ReadAllLines("scrambledword.txt");
            string[] WLLines = System.IO.File.ReadAllLines("wordlist.txt");

            int wordfound = 0;
            int i = 0;
            int goodChar = 0;
            List<int> idxUsedSW = new List<int>();
            List<int> idxUsedWL = new List<int>();
            List<string> finalWord = new List<string>();
            

            foreach (string SWLine in SWlines) // loop for each scrambled words
            {
                i++;
                Console.WriteLine("Scrambled Word n°{0} : {1} ",i, SWLine);

                foreach (string WLLine in WLLines)
                {
                    if (wordfound != i)
                    {
                        if (SWLine.Length == WLLine.Length) // Check if ScrambleWord length === WordList length
                        {
                           for (int idx = 0; idx <= (SWLine.Length - 1); idx++)
                           {
                                for (int idx2 = 0; idx2 <= (WLLine.Length - 1); idx2++)
                                {
                                    if (SWLine[idx] == WLLine[idx2])
                                    {
                                        if (!idxUsedSW.Contains(idx) && !idxUsedWL.Contains(idx2))
                                        {
                                            idxUsedSW.Add(idx);
                                            idxUsedWL.Add(idx2);
                                            goodChar++;
                                        }
                                        
                                    }
                                }
                            }
                            
                        }

                        if (SWLine.Length == goodChar)
                        {
                            Console.WriteLine("-------> {0}", WLLine);
                            Console.WriteLine("\t");
                            wordfound++;
                            finalWord.Add(WLLine);
                        }
                    }
                    idxUsedSW.Clear();
                    idxUsedWL.Clear();
                    goodChar = 0;

                }

            }

            string FinalText = string.Empty;
            foreach (string Word in finalWord)
            {
                FinalText = FinalText + Word + ",";
               
            }
            FinalText = FinalText.Remove(FinalText.Length - 1); // Take off the last character " , "

            System.IO.File.WriteAllText("finalwords.txt", FinalText);
            Console.ReadLine();
           
        }
    }
}
