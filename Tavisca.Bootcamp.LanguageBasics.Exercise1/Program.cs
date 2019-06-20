using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            var str = equation.Split("=");
            var c = str[1];
            str = str[0].Split('*');
            var a = str[0];
            var b = str[1];

            var res = "";
            if (c.IndexOf('?') != -1) {
                res = (int.Parse(a) * int.Parse(b)).ToString();

                if (res.Length != c.Length) return -1;

                var temp_c = "";
                int returnDig = 0;
                foreach (var ch in c) {
                    if (ch == '?') {
                        temp_c += res[c.IndexOf(ch)];
                        returnDig = int.Parse(res[c.IndexOf(ch)].ToString());
                    } else {
                        temp_c += ch;
                    }
                }

                if (res != temp_c) return -1;
                return returnDig;
            } else if (a.IndexOf('?') != -1) {
                if (int.Parse(c) % int.Parse(b) != 0) return -1;
                res = (int.Parse(c) / int.Parse(b)).ToString();

                if (res.Length != a.Length) return -1;

                var temp_a = "";
                int returnDig = 0;
                foreach (var ch in a) {
                    if (ch == '?') {
                        temp_a += res[a.IndexOf(ch)];
                        returnDig = int.Parse(res[a.IndexOf(ch)].ToString());
                    } else {
                        temp_a += ch;
                    }
                }

                if (res != temp_a) return -1;
                return returnDig;
            } else if (b.IndexOf('?') != -1) {
                if (int.Parse(c) % int.Parse(a) != 0) return -1;
                res = (int.Parse(c) / int.Parse(a)).ToString();

                if (res.Length != b.Length) return -1;

                var temp_b = "";
                int returnDig = 0;
                foreach (var ch in b) {
                    if (ch == '?') {
                        temp_b += res[b.IndexOf(ch)];
                        returnDig = int.Parse(res[b.IndexOf(ch)].ToString());
                    } else {
                        temp_b += ch;
                    }
                }

                if (res != temp_b) return -1;
                return returnDig;
            } else return -1;
        }
    }
}
