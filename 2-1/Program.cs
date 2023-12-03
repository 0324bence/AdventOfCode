namespace _2_1
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
                bool possible = true;
                foreach (string set in sets) {
                    Dictionary<string, int> amounts = new Dictionary<string, int>() {
                        {"green", 0},
                        {"blue", 0 },
                        {"red", 0 }
                    };
                    string[] moves = set.Split(", ");
                    foreach (string move in moves) {
                        string[] splitMove = move.Split(" ");
                        amounts[splitMove[1]] = int.Parse(splitMove[0]);
                    }
                    if (!(amounts["red"] <= 12 && amounts["green"] <= 13 && amounts["blue"] <= 14)) {
                        possible = false;
                        break;
                    }
                }
                if (possible) {
                    output += gameNum;
                }
            }
            Console.WriteLine(output);
        }
    }
}