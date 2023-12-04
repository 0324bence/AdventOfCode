using System.Xml;

namespace _3_1
{
    internal class Program
    {
        static void Main(string[] args) {
            int output = 0;

            bool test = char.IsDigit('$');

            string[] input = File.ReadAllLines("input.txt");

            HashSet<string> done = new HashSet<string>(); 
            
            for (int i = 0; i < input.Length; i++) {
                string line = input[i];
                for (int j = 0; j < line.Length; j++) {
                    char c = line[j];
                    if (!char.IsDigit(c) && c != '.') {
                        //Console.WriteLine($"Checking char at line {i}, index {j} ({input[i][j]})");
                        int[][] numbers = CheckAround(input, i, j);
                        //Console.WriteLine($"Found {numbers.Length} numbers around it.");
                        foreach (int[] number in numbers) {
                            //Console.WriteLine($"Number in line {number[0]} at pos {number[1]} is {input[number[0]][number[1]]}");
                            int[] numPos = GetWholeNumberPos(input[number[0]], number[1]);
                            string positon = $"{number[0]}{numPos[0]}";

                            int debugvar = int.Parse(input[number[0]].Substring(numPos[0], numPos[1] - numPos[0]));
                            //Check if numbers was already read
                            if (!done.Contains(positon)) {
                                //Get the number by substringing
                                output += int.Parse(input[number[0]].Substring(numPos[0], numPos[1] - numPos[0]));
                            }

                            //Save start point of already read numbers
                            done.Add(positon);
                        }
                    }
                }
            }

            Console.WriteLine(output);
        }

        //Function that returns the starting and ending postion of a number based on the position of one digit
        static int[] GetWholeNumberPos(string input, int pos) {
            if (!char.IsDigit(input[pos])) {
                throw new ArgumentException("Char at position is not a digit");
            }
            int startPos = pos;
            int endPos = pos;
            while (startPos - 1 >= 0 && char.IsDigit(input[startPos - 1])) {
                startPos--;
            }
            while (endPos + 1 < input.Length - 1 && char.IsDigit(input[endPos + 1])) {
                endPos++;
            }
            return new int[] { startPos, endPos };
        }

        //function that returns all numbers surrounding a position
        static int[][] CheckAround(string[] input, int line, int pos) {
            List<int[]> outputs = new List<int[]>();

            for (int i = line-1; i <= line+1; i++) {
                bool oneNum = false;
                for (int j = pos-1; j <= pos+1; j++) {
                    try {
                        if (!char.IsDigit(input[i][j]) || oneNum) {
                            oneNum = false;
                            continue;
                        }
                        char debug = input[i][j];
                        if (char.IsDigit(input[i][j])) {
                            outputs.Add(new int[] { i, j });
                            oneNum = true;

                        }
                    } catch {
                        Console.WriteLine("Failed");
                    }
                }
            }

            return outputs.ToArray();
        }
    }
}
