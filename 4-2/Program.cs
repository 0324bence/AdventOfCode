namespace _4_2
{
    internal class Program
    {
        static void Main(string[] args) {
            int output = 0;

            string[] input = File.ReadAllLines("input.txt");
            int[] cardAmounts = new int[input.Length];
            int[] cardWins = new int[input.Length];
            for (int i = 0; i < cardAmounts.Length; i++) {
                cardAmounts[i] = 1;
                cardWins[i] = 0;
            }

            for (int i = 0; i < cardAmounts.Length; i++) {
                for (int j = 0; j < cardAmounts[i]; j++) {
                    int wins = 0;
                    if (cardWins[i] > 0) {
                        wins= cardWins[i];
                    } else {
                        string line = input[i];
                        string data = line.Split(':')[1];
                        string[] splitData = data.Split('|');
                        string[] winNums = splitData[0].Trim().Split(' ');
                        string[] ownNums = splitData[1].Trim().Split(' ');

                        foreach (string winNum in winNums) {
                            if (winNum == "" || winNum.Length <= 0) continue;
                            if (ownNums.Contains(winNum)) {
                                wins++;
                            }
                        }
                        cardWins[i] = wins;
                    }
                    for (int h = 1; h <= wins; h++) {
                        cardAmounts[i + h]++;
                    }
                }
            }

            output = cardAmounts.Sum();

            Console.WriteLine(output);
        }
    }
}