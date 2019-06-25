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

            // Assume equation to be in: 'a*b=c' format
            string a, b, c;
            GetABC(equation, out a, out b, out c);

            if (c.IndexOf('?') != -1) return FindValueOfQuestionMarkFromActual(
                (int.Parse(a) * int.Parse(b)).ToString(),
                c);
            else if (a.IndexOf('?') != -1) return MissingDigitInAOrB(a, b, c);
            else if (b.IndexOf('?') != -1) return MissingDigitInAOrB(b, a, c);
            else return -1;
        }

        public static void GetABC(string equation, out string a, out string b, out string c) {
            // Separate LHS and RHS
            var temp = equation.Split("=");

            // separating a, b, c
            c = temp[1];
            temp = temp[0].Split('*');
            a = temp[0];
            b = temp[1];
        }

        public static int MissingDigitInAOrB(string lhsToFind, string lhsGiven, string c) {
            if (int.Parse(c) % int.Parse(lhsGiven) != 0) return -1;

            string actualValue = (int.Parse(c) / int.Parse(lhsGiven)).ToString();
            return FindValueOfQuestionMarkFromActual(actualValue, lhsToFind);
        }

        ///<summary>
        /// param: actual ->  string that has digit, that we will use to replace the question mark
        /// param: hasQuestionMark -> string that has Question mark
        ///</summary>
        public static int FindValueOfQuestionMarkFromActual(string actual, string hasQuestionMark) {
            if (actual.Length != hasQuestionMark.Length) return -1;

            #region FillQuestionMarkInRHSWithCorrespondingDigitInLHS
                int indexOfQuestionMark = hasQuestionMark.IndexOf('?');
                string temp = hasQuestionMark.Replace('?', actual[indexOfQuestionMark]);
            #endregion

            if (actual != temp) return -1;
            return int.Parse(actual[indexOfQuestionMark].ToString());   
        }
    }
}
