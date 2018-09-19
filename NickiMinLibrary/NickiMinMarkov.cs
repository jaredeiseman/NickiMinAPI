using System;
using System.Collections.Generic;
using System.IO;
using Markov;
using Newtonsoft.Json;
using NickiMinLibrary.Models;

namespace NickiMinLibrary
{
    public class NickiMinMarkov
    {
        public List<string> _Corpus;

        private MarkovChain<string> _MarkovChainer = new MarkovChain<string>(1);

        public NickiMinMarkov()
        {
            using (StreamReader r = new StreamReader(@"C:\Code\NickiMinAPI\seed.json"))
            {
                string contents = r.ReadToEnd();
                List<Entry> data = JsonConvert.DeserializeObject<List<Entry>>(contents);

                foreach (Entry entry in data)
                {
                    var lines = entry.Lyrics.Split("\n");
                    foreach (var line in lines)
                    {
                        _MarkovChainer.Add(line.Split("\n"));
                    }
                }
            }
        }

        public string GenerateLine()
        {
            var rand = new Random();
            var sentence = string.Join(" ", _MarkovChainer.Chain(rand));
            sentence = string.IsNullOrWhiteSpace(sentence) ? GenerateLine() : sentence;

            return sentence;
        }

        public string GenerateVerse()
        {
            List<string> output = new List<string>() { };
            var rand = new Random();
            for (var i = 0; i < rand.Next(3, 8); i++)
            {
                string line = GenerateLine().Replace("\n", "");
                output.Add(line);
            }

            return string.Join("\r\n", output);
        }
    }
}
