using System.Collections.Generic;
using System.IO;

namespace MegaDesk
{

    public class DeskQuotes
    {
        private List<DeskQuote> quotes;
        private const string fileName = @"quotes.txt";

        public DeskQuotes()
        {
            quotes = new List<DeskQuote>();
            LoadFromFile();
        }

        public List<DeskQuote> GetAll()
        {
            return quotes;
        }

        public List<DeskQuote> GetFiltered(string materialDescr)
        {
            if (materialDescr.Equals("All"))
            {
                return quotes;
            }
            else
            {
                return quotes.FindAll
                (
                    delegate (DeskQuote quote)
                    {
                        return quote.QuotedDesk.SurfaceMaterial.ToString() == materialDescr;
                    }
                );
            }
        }

        public void Add(DeskQuote quote)
        {
            quotes.Add(quote);
            string[] lines = quotes.ConvertAll(x => x.MakeFileRecord()).ToArray();
            try
            {
                File.WriteAllLines(fileName, lines);
            }
            catch (System.Exception e)
            {
                throw new System.Exception("Can't write to " + fileName + ". " + e.Message);
            }
            
        }

        private void LoadFromFile()
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    quotes.Add(new DeskQuote(line));
                }
            }
        }
    }
}
