namespace _5_1
{
    internal class Program
    {
        static void Main(string[] args) {
            int output = 0;

            string[] input = File.ReadAllLines("input.txt");

            Dictionary<string, long[]> values = new Dictionary<string, long[]>() {
                {"seed", new long[0]}
            };

            string[] currentComponents = new string[0];
            List<long> currentDestStarts = new List<long>();
            List<long> currentSourceStarts = new List<long>();
            List<long> currentRanges = new List<long>();

            void AddValues() {
                if (currentComponents.Length > 0) {
                    List<long> results = new List<long>();
                    foreach (long seed in values[currentComponents[0]]) {
                        bool seedAdded = false;
                        for (int i = 0; i < currentSourceStarts.Count(); i++) {
                            if (seedAdded) {
                                break;
                            }
                            long sourceStart = currentSourceStarts[i];
                            long sourceEnd = sourceStart + currentRanges[i] - 1;
                            if (seed >= sourceStart && seed <= sourceEnd) {
                                long difference = seed - sourceStart;
                                results.Add(currentDestStarts[i] + difference);
                                seedAdded = true;
                                continue;
                            }
                        }
                        if (!seedAdded) {
                            results.Add(seed);
                        }
                    }

                    values.Add(currentComponents[1], results.ToArray());
                }
            }

            foreach (string line in input) {
                if (line.Length == 0 || line == "") continue;

                string[] data = line.Split(':');
                if (data[0] == "seeds") {
                    values["seed"] = data[1].Trim().Split(' ').Select(long.Parse).ToArray();
                    continue;
                }


                string[] dataLine = line.Split(" ");
                if (!char.IsDigit(dataLine[0][0])) {
                    //values.Add(components[1], new int[0]);
                    AddValues();
                    
                    currentComponents = dataLine[0].Split("-to-");
                    currentDestStarts = new List<long>();
                    currentSourceStarts = new List<long>();
                    currentRanges = new List<long>();
                    continue;
                }

                currentDestStarts.Add(long.Parse(dataLine[0]));
                currentSourceStarts.Add(long.Parse(dataLine[1]));
                currentRanges.Add(long.Parse(dataLine[2]));
            }
            AddValues();
            Console.WriteLine(values["location"].Min());
        }
    }
}