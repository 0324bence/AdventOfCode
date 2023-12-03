namespace _2_2
{
    internal class Program
    {
        static void Main(string[] args) {

            int output = 0;

            string[] lines = File.ReadAllLines("input.txt");

            foreach (string line in lines) {
                string[] split1 = line.Split(": ");
                int gameNum = int.Parse(split1[0].Split(' ')[1]);
                string[] sets = split1[1].Trim().Split("; ");
                Dictionary<string, int> amounts = new Dictionary<string, int>() {
                    {"green", 0},
                    {"blue", 0 },
                    {"red", 0 }
                };
                foreach (string set in sets) {
                    string[] moves = set.Split(", ");
                    foreach (string move in moves) {
                        string[] splitMove = move.Split(" ");
                        int colorAmount = int.Parse(splitMove[0]);
                        if (colorAmount > amounts[splitMove[1]]) {
                            amounts[splitMove[1]] = colorAmount;
                        }
                    }
                }
                int power = 1;
                foreach (int value in amounts.Values) {
                    power *= value;
                }
                output += power;
            }
            Console.WriteLine(output);
        }
    }
}