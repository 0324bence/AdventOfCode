namespace _4_1
{
    internal class Program
    {
        static void Main(string[] args) {
            int output = 0;

            string[] input = File.ReadAllLines("input.txt");

            foreach (string line in input) {
                int points = 0;
                string data = line.Split(':')[1];
                string[] splitData = data.Split('|');
                string[] winNums = splitData[0].Trim().Split(' ');
                string[] ownNums = splitData[1].Trim().Split(' ');

                List<string> wonNums = new List<string>();

                foreach (string winNum in winNums) {
                    if (winNum == "" || winNum.Length <= 0) continue;
                    if (ownNums.Contains(winNum)) {
                        if (points == 0) {
                            points = 1;
                        }
                        else {
                            points *= 2;
                        }
                        wonNums.Add(winNum);
                    }
                }
                output += points;
            }
            Console.WriteLine(output);
        }
    }
}