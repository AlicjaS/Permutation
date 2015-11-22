using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Permutation
{
    public static class PermutationCalc
    {
        static void Main(string[] args)
        {
            foreach (string line in ReadLines(@"C:\Tests\perm.txt"))
            {
                string[] lineSplit = line.Split(' ');
                int n, index, m;
                if (Int32.TryParse(lineSplit[0], out n) && Int32.TryParse(lineSplit[1], out index) && Int32.TryParse(lineSplit[2], out m))
                {
                    ShowPerms(n, index, m);
                    Console.WriteLine();
                }
            }

            Console.ReadLine();
        }

        static IEnumerable<string> ReadLines(Func<TextReader> provider)
        {
            using (TextReader reader = provider())
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        static IEnumerable<string> ReadLines(string filename, Encoding encoding)
        {
            return ReadLines(() => { return new StreamReader(filename, encoding); });
        }

        static IEnumerable<string> ReadLines(string filename)
        {
            return ReadLines(filename, Encoding.UTF8);
        }

        static void FactCheck()
        {
            Console.WriteLine("Enter number");
            string str = Console.ReadLine();
            int num = Int32.Parse(str);
            int x = Factorial(num);
            Console.WriteLine(x);
        }

        public static int Factorial(int n)
        {
            int result = 1;
            try
            {
                checked
                {
                    if (n > 1)
                    {
                        for (int i = 2; i <= n; i++)
                        {
                            result *= i;
                        }
                    }
                }
            }
            catch (OverflowException)
            {
                return Int32.MaxValue - 1;
            }
            catch (Exception)
            {
                throw;
            }           
            return result;
        }

        static int[] CalcPerm(int n, int index)
        {
            int[] perm = new int[n];
            List<int> firstPerm = new List<int>();
            for (int i = 0; i < n; i++)
            {
                firstPerm.Add(i + 1);
            }
            int factor = Factorial(n - 1);
            for (int i = 0; i < n; i++)
            {            
                perm[i] = firstPerm[index / factor];
                firstPerm.RemoveAt(index / factor);
                index = index % factor;
                if((n - i - 1) > 0) factor = factor / (n - i - 1);
            }
            return perm;
        }

        public static void ShowPerms(int n, int index, int m)
        {
            for (int i = index; i < index + m; i++)
            {
                int[] x = CalculatePermutation(n, i);
                foreach (var item in x)
                {
                    Console.Write("{0} ", item);
                }
                Console.WriteLine();
            }
        }

        static int[] CalculatePermutation(int n, int index)
        {
            int[] permutation = new int[n];
            List<int> firstPermutation = new List<int>();
            for (int i = 0; i < n; i++)
            {
                firstPermutation.Add(i + 1);
            }
            int factor = 1;
            int counter = 1;
            do
            {
                factor *= counter;
                counter++;
            } while (factor < index && counter <= n-1);
            for (int i = 0; i < n; i++)
            {
                permutation[i] = firstPermutation[index / factor];
                firstPermutation.RemoveAt(index / factor);
                index = index % factor;
                if ((counter - i - 1) > 0) factor = factor / (counter - i - 1);
            }
            return permutation;
        }
    }
}
