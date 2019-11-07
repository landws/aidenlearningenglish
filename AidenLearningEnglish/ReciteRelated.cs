using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidenLearningEnglish
{
    class ReciteRelated
    {
        public int Position { get; set; }
        List<string> Words = new List<string>();
        public string Name { get; set; }
        public ReciteRelated(string name)
        {
            this.Name = name;

            using (Stream stream = this.GetType().Assembly.GetManifestResourceStream("AidenLearningEnglish.recite." + name + ".txt"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var str = reader.ReadToEnd();
                    var lines = str.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in lines)
                    {
                        if (!string.IsNullOrWhiteSpace(word)) Words.Add(word);
                    }
                }
            }

            Position = -1;
            Random = true;
        }
        public int Length { get { return Words.Count; } }
        public bool Available { get { return Words.Count > 0; } }
        public bool Random { get; set; }
        public string PickOne()
        {
            if (!Available) return "";
            int pos = -1;
            do
            {
                pos = new Random().Next(0, Words.Count - 1);
            }
            while (Sequence.Contains(pos));

            if (pos == -1) return "";

            Position = pos;
            Sequence.Add(pos);
            seqindex = Sequence.Count - 1;

            return Words[pos];
        }
        public string PickPreviousWord()
        {
            if (seqindex > 0)
            {
                var pos = Sequence[seqindex - 1];
                seqindex--;
                return Words[pos];
            }
            return "";
        }
        public string PickNextWord()
        {
            if (seqindex > -1 && seqindex < Sequence.Count - 1)
            {
                var pos = Sequence[seqindex + 1];
                seqindex++;
                return Words[pos];
            }
            return PickOne();
        }
        int seqindex = -1;
        public List<int> Sequence = new List<int>();
    }
}
