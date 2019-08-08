
namespace Code
{
    using System;
    using System.IO;
    using System.Text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;


    //using IronOcr.AutoOcr;
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = ReadFileLocations();
            using (System.IO.StreamWriter outFile = new System.IO.StreamWriter(@"C:\Users\cgomez\source\repos\Code\Code\output-text-1.txt"))
            {
                foreach (string file in files)
                {
                    string newFile = file.Replace("\"", "").Trim();
                    //Console.WriteLine(newFile);
                    outFile.WriteLine(ExtractTextFromPdf_KeyWord1(newFile));  //sends found words to output-text-1
                }
            }
            using (System.IO.StreamWriter outFile = new System.IO.StreamWriter(@"C:\Users\cgomez\source\repos\Code\Code\output-text-2.txt"))
            {
                foreach (string file in files)
                {
                    string newFile = file.Replace("\"", "").Trim();
                    //Console.WriteLine(newFile);
                    outFile.WriteLine(ExtractTextFromPdf_KeyWord2(newFile));  //sends found words to output-text-2
                }
            }
            using (System.IO.StreamWriter outFile = new System.IO.StreamWriter(@"C:\Users\cgomez\source\repos\Code\Code\output-text-3.txt"))
            {
                foreach (string file in files)
                {
                    string newFile = file.Replace("\"", "").Trim();
                    //Console.WriteLine(newFile);
                    outFile.WriteLine(ExtractTextFromPdf_KeyWord3(newFile));  //sends found words to output-text-3
                }
            }
            //PrintDoc();
        }

        public static string[] ReadFileLocations() //Reads the PathLocations text file.
        {
            string fileLocations = "C:/Users/cgomez/source/repos/Code/Code/Path-Locations.txt";
            string[] files = File.ReadAllLines(fileLocations);
            return files;
        }
        public static string ExtractTextFromPdf_KeyWord1(string path) //Reads every line from the pdf and grabs key information.
        {
            using (PdfReader reader = new PdfReader(path))
            {
                StringBuilder text = new StringBuilder();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string thePage = PdfTextExtractor.GetTextFromPage(reader, i, new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy());
                    string[] theLines = thePage.Split('\n');
                    foreach (var theLine in theLines)
                    {

                        //text.AppendLine(theLine);
                        //if (theLine.Contains("Alternate Keyword") && theLine.Length > 13) //&& !theLine.Contains("Some word"))
                        if (theLine.Contains("Keyword"))
                        {
                            string[] splitLine = theLine.Split(" ");
                            for (int j = Array.IndexOf(splitLine, "Keyword") + 1; j < splitLine.Length; j++)
                            {
                                text.Append(splitLine[j] + " ");

                            }
                            //if (text.ToString().Contains("Alternate word")) //All if statements below are optional to clean up outputs.
                            if (text.ToString().Contains("word"))
                            {
                                text.Remove(0, 9);
                                //text.Remove(0, 18);
                            }
                            if (text.ToString().Contains("word"))
                            {
                                text.Remove(0, 9);
                            }
                            /*if (text.ToString().Contains("word"))
                            {
                                text.Remove(text.ToString().IndexOf('w'), (text.ToString().Length - (text.ToString().IndexOf('w'))));
                            }
                            
                            if (text.ToString().Contains("wordOne"))
                            {
                                text.Remove(0, 8);
                            }
                            if (text.ToString().Contains("wordTwo"))
                            {
                                text.Remove(0, 9);
                            }
                            if (text.ToString().Contains("wordThree"))
                            {
                                text.Remove(text.ToString().IndexOf('W'), (text.ToString().Length - (text.ToString().IndexOf('W'))));
                            }
                            if (text.ToString().Contains("wordFour") && text.ToString().Length - text.ToString().Replace("WordFour", "").Length > 4) // makes sure the same word appears twice
                            {
                                text.Remove(text.ToString().LastIndexOf('w'), (text.ToString().Length - (text.ToString().LastIndexOf('w'))));
                            }
                            if (text.ToString().Contains("•"))
                            {
                                text.Replace("•", "");
                            }*/
                            goto here;
                        }
                    }
                }
            here:
                //file.WriteLine(text);
                Console.WriteLine(text);
                return text.ToString();
            }
        }
        public static string ExtractTextFromPdf_KeyWord2(string path) //Reads every line from the pdf and grabs key information.
        {
            using (PdfReader reader = new PdfReader(path))
            {
                StringBuilder text = new StringBuilder();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string thePage = PdfTextExtractor.GetTextFromPage(reader, i, new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy());
                    string[] theLines = thePage.Split('\n');
                    //int lineNum = 0;
                    foreach (var theLine in theLines)
                    {
                        if (theLine.Contains("Keyword2"))
                        //if (theLine.Contains("AltKeyword"))
                        {
                            string[] splitLine = theLine.Split(" ");
                            for (int j = Array.IndexOf(splitLine, "Keyword2") + 1; j < splitLine.Length; j++)
                            //for (int j = Array.IndexOf(splitLine, "AltKeyword"); j < Array.IndexOf(splitLine, "AltKeywordEnd"); j++)
                            {
                                text.Append(splitLine[j] + " ");
                                if (text.ToString().Contains("AnotherWord"))
                                {
                                    text.Remove(0, 17);
                                }
                            }
                            goto here;
                        }
                    }
                }
            here:
                Console.WriteLine(text);
                return text.ToString();
            }
        }

        public static string ExtractTextFromPdf_KeyWord3(string path) //Reads every line from the pdf and grabs key information.
        {
            using (PdfReader reader = new PdfReader(path))
            {
                StringBuilder text = new StringBuilder();
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string thePage = PdfTextExtractor.GetTextFromPage(reader, i, new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy());
                    string[] theLines = thePage.Split('\n');
                    //int lineNum = 0;
                    foreach (var theLine in theLines)
                    {
                        //text.AppendLine(theLine);

                        if (theLine.Contains("KeyWord3"))
                        //if (theLine.Contains("AltWord"))
                        {
                            string[] splitLine = theLine.Split(" ");
                            for (int j = Array.IndexOf(splitLine, ("KeyWord3")) + 1; j < splitLine.Length; j++)
                            {
                                text.Append(splitLine[j] + " ");
                                text.ToString();
                            }
                            if (text.ToString().Contains("RedundantWord1"))//If statements below are to cleanup the outputs.
                            {
                                text.Remove(text.ToString().IndexOf('R'), (text.ToString().Length - (text.ToString().IndexOf('R'))));
                            }
                            if (text.ToString().Contains("RedundantWord2"))
                            {
                                text.Remove(0, 11);
                            }
                            if (text.ToString().Contains("RedundantWord3"))
                            {
                                text.Remove(text.ToString().IndexOf('R'), (text.ToString().Length - (text.ToString().IndexOf('R'))));
                                //Console.WriteLine(text.ToString().IndexOf('P') + "   " + (text.ToString().Length - (text.ToString().IndexOf('P'))));
                            }
                            if (text.ToString().Contains("("))
                            {
                                text.Remove(text.ToString().IndexOf('('), (text.ToString().Length - (text.ToString().IndexOf('('))));

                            }
                            if (text.ToString().Contains("-"))
                            {
                                text.Replace("-", "");
                            }
                            if (text.ToString().Contains("—"))
                            {
                                text.Replace("—", "");
                            }
                            if (text.ToString().Contains("•"))
                            {
                                text.Replace("•", "");
                            }
                            goto here;
                        }
                        if (theLine.Contains("KeyWord3")) // Or this word
                        //if (theLine.Contains("AltWord"))
                        {
                            string[] splitLine = theLine.Split(" ");
                            for (int j = Array.IndexOf(splitLine, ("KeyWord3")) + 1; j < splitLine.Length; j++)
                            {
                                text.Append(splitLine[j] + " ");
                                text.ToString();
                            }
                            if (text.ToString().Contains("RedundantWord1"))//If statements below are to cleanup the outputs.
                            {
                                text.Remove(text.ToString().IndexOf('R'), (text.ToString().Length - (text.ToString().IndexOf('R'))));
                            }
                            if (text.ToString().Contains("RedundantWord2"))
                            {
                                text.Remove(0, 11);
                            }
                            if (text.ToString().Contains("RedundantWord3"))
                            {
                                text.Remove(text.ToString().IndexOf('R'), (text.ToString().Length - (text.ToString().IndexOf('R'))));
                                //Console.WriteLine(text.ToString().IndexOf('P') + "   " + (text.ToString().Length - (text.ToString().IndexOf('P'))));
                            }
                            if (text.ToString().Contains("("))
                            {
                                text.Remove(text.ToString().IndexOf('('), (text.ToString().Length - (text.ToString().IndexOf('('))));

                            }
                            if (text.ToString().Contains("-"))
                            {
                                text.Replace("-", "");
                            }
                            if (text.ToString().Contains("—"))
                            {
                                text.Replace("—", "");
                            }
                            if (text.ToString().Contains("•"))
                            {
                                text.Replace("•", "");
                            }
                            goto here;
                        }
                        if (theLine.Contains("KeyWord3")) // Or this word
                        //if (theLine.Contains("AltWord"))
                        {
                            string[] splitLine = theLine.Split(" ");
                            for (int j = Array.IndexOf(splitLine, ("KeyWord3")) + 1; j < splitLine.Length; j++)
                            {
                                text.Append(splitLine[j] + " ");
                                text.ToString();
                            }
                            if (text.ToString().Contains("RedundantWord1"))//If statements below are to cleanup the outputs.
                            {
                                text.Remove(text.ToString().IndexOf('R'), (text.ToString().Length - (text.ToString().IndexOf('R'))));
                            }
                            if (text.ToString().Contains("RedundantWord2"))
                            {
                                text.Remove(0, 11);
                            }
                            if (text.ToString().Contains("RedundantWord3"))
                            {
                                text.Remove(text.ToString().IndexOf('R'), (text.ToString().Length - (text.ToString().IndexOf('R'))));
                                //Console.WriteLine(text.ToString().IndexOf('P') + "   " + (text.ToString().Length - (text.ToString().IndexOf('P'))));
                            }
                            if (text.ToString().Contains("("))
                            {
                                text.Remove(text.ToString().IndexOf('('), (text.ToString().Length - (text.ToString().IndexOf('('))));

                            }
                            if (text.ToString().Contains("-"))
                            {
                                text.Replace("-", "");
                            }
                            if (text.ToString().Contains("—"))
                            {
                                text.Replace("—", "");
                            }
                            if (text.ToString().Contains("•"))
                            {
                                text.Replace("•", "");
                            }
                            goto here;
                        }

                    }
                }
            here:
                //file.WriteLine(text);
                Console.WriteLine(text);
                return text.ToString();
            }
        }
        public static string PrintDoc() //Prints out page so you can debug.
        {
            string thePage = "";
            using (System.IO.StreamWriter outFile = new System.IO.StreamWriter(@"C:\Users\cgomez\source\repos\Code\Code\output-text-1.txt"))
            {

                using (PdfReader reader = new PdfReader("C:/Some-File"))
                {
                    //StringBuilder text = new StringBuilder();

                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        thePage = PdfTextExtractor.GetTextFromPage(reader, i, new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy());
                        Console.WriteLine(thePage);
                        outFile.WriteLine(thePage);

                    }
                }
            }
            return thePage;
        }
    }
}