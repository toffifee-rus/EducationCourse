using System;

namespace Task6
{
    public class Initialize
    {
        public List<string> Words { get; set; }
        public List<string> SortedWords { get; set; }
        public Dictionary<string, int> GroupedWords { get; set; }
        public KeyValuePair<string, int> Max { get; set; }

        public Initialize()
        {
            string raw = File.ReadAllText("words.txt");
            Words = raw.Split(',').Select(w => w.Trim()).ToList();
            SortedWords = Words.OrderBy(w => w).ToList();
            var s = Words.GroupBy(w => w);
            GroupedWords = Words.GroupBy(w => w).ToDictionary(i => i.Key, i => i.Count());
            Max = GroupedWords.OrderByDescending(w => w.Value).First();
        }
        public void ShowData()
        {
            foreach (var word in GroupedWords)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine(Max);

        }
    }
}
