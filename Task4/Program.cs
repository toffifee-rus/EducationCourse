//Дан массив, например:
//{ "вертикаль",    "кильватер",    "апельсин",    "спаниель",    "австралопитек",  "ватерполистка",    "кластер",    "сталкер",    "стрелка",    "корабль" }
//Найти анаграммы и вывести анаграммы на консоль (собрать каждые слова-анаграммы в отдельные коллекции). 

//Пример вывода:
//"вертикаль", "кильватер"
//"апельсин", "спаниель"


namespace Task4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Dictionary<string, string[]> solves = new Dictionary<string, string[]> { };
            List<string> true_words = new List<string>();
            List<string> list = new List<string>() { "вертикаль", "кильватер", "апельсин", "спаниель", "австралопитек", "ватерполистка", "кластер", "сталкер", "стрелка", "корабль" };
            //string[] array = { "вертикаль", "кильватер", "апельсин", "спаниель", "австралопитек", "ватерполистка", "кластер", "сталкер", "стрелка", "корабль" };

            foreach (var word1 in list)
            {
                List<char> arrayword1 = word1.ToList();
                string word_to_char1 = new string(arrayword1.OrderBy(e => e).ToArray());
                //Console.WriteLine(word_to_char1);

                foreach (var word2 in list)
                {

                    List<char> arrayword2 = word2.ToList();
                    string word_to_char2 = new string(arrayword2.OrderBy(e => e).ToArray());
                    //Console.WriteLine(word_to_char2);


                    if (word_to_char1.Contains(word_to_char2))
                        {
                        true_words.Add()
                        solves.Add(word_to_char1, word_to_char2);
                        }
                    else { Console.WriteLine("0");
                    }
                    
                }
            }
        }
    }
}
