using System;
using System.Collections.Generic;
using System.Threading;

namespace SHA256_Cripto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Stringbit32 x = new Stringbit32("000000000000000000000111111111111111111111111").InputPadding(32);
            Stringbit32 y = new Stringbit32("111100000011011111111000001111111100000001111").InputPadding(32);
            Stringbit32 z = new Stringbit32("010000111111110101001111111111100000111101011").InputPadding(32);
            SHA256 hashfunction = new SHA256("abc");

            
            Scenes.Scene_SHR(x, 32);
            Console.ReadKey();
            Scenes.Scene_ROTR(x, 64);
            Console.ReadKey();
            Scenes.Scene_lowercasesigma0(x);
            Console.ReadKey();
            Scenes.Scene_lowercasesigma1(x);
            Console.ReadKey();
            Scenes.Scene_uppercasesigma0(x);
            Console.ReadKey();
            Scenes.Scene_uppercasesigma1(x);
            Console.ReadKey();
            Scenes.Scene_marjority(x,y,z);
            Console.ReadKey();
            Scenes.Scene_choice(x, y, z);
            Console.ReadKey();

        }
    }
    
    class Scenes
    {
        private static void _console_clear_line()
        {
            int position = Console.CursorLeft;
            string temp = "".PadLeft(Console.WindowWidth-1);
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(temp);
            Console.SetCursorPosition(position, Console.CursorTop);
        }

        private static void _console_clear_length(int length)
        {
            int position = Console.CursorLeft;
            string temp = "".PadLeft(Console.WindowWidth - 1 - length);
            Console.Write(temp);
            Console.SetCursorPosition(position, Console.CursorTop);
        }

        private static void _console_alter_text(List<string> text, int delayms)
        {
            foreach (string element in text)
            {
                int position = Console.CursorLeft;
                Console.Write(element);
                Console.SetCursorPosition(position, Console.CursorTop);
                Thread.Sleep(delayms);
            }
        }

        private static void _console_alter_text(List<string> text, int delayms, bool clear)
        {
            foreach (string element in text)
            {
                int position = Console.CursorLeft;
                if (clear)
                    _console_clear_length(element.Length);
                Console.Write(element);
                Console.SetCursorPosition(position, Console.CursorTop);
                Thread.Sleep(delayms);
            }
        }
        private static void _console_alter_text(List<List<string>> texts, List<int[]> positions, int delayms)
        {


            for(int t = 0; t < texts[0].Count; t++)
            {
                for (int i = 0; i < texts.Count; i++)
                {
                    Console.SetCursorPosition(positions[i][0], positions[i][1]);
                    Console.Write(texts[i][t]);
                }
                Thread.Sleep(delayms);
            }
        }
        


        public static void Scene_SHR(Stringbit32 input , int amount)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("      x: " + input.Content);
            Console.SetCursorPosition(9, Console.CursorTop);
            Console.WriteLine("".PadLeft(32, '-'));
            Console.Write    ("  SHA32: " + input.Content);
            Console.SetCursorPosition(9, 2);

            Thread.Sleep(2000);

            List<string> result = new List<string>();

            for(int i = 1; i < amount + 1; i++)
            {
                result.Add( Stringbit32.SHR(input, i).Content);
            }
            _console_alter_text(result, 100);
        }

        public static void Scene_ROTR(Stringbit32 input, int amount)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("      x: " + input.Content);
            Console.SetCursorPosition(9, Console.CursorTop);
            Console.WriteLine("".PadLeft(32, '-'));
            Console.Write    (" ROTR64: " + input.Content);
            Console.SetCursorPosition(9, 2);

            Thread.Sleep(2000);

            List<string> result = new List<string>();

            for (int i = 1; i < amount + 1; i++)
            {
                result.Add(Stringbit32.ROTR(input, i).Content);
            }
            _console_alter_text(result, 100);
        }

        public static void Scene_lowercasesigma0(Stringbit32 input)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.WriteLine("      x: " + input.Content);
            
            Console.SetCursorPosition(9, Console.CursorTop);
            Console.WriteLine("".PadLeft(32, '-'));

            Console.WriteLine("  ROTR7: " + input.Content);
            Console.WriteLine(" ROTR18: " + input.Content);
            Console.WriteLine("   SHR3: " + input.Content);

            Console.SetCursorPosition(9, Console.CursorTop);
            Console.WriteLine("".PadLeft(32, '-'));

            Console.Write("     σ0: ");
            
            Thread.Sleep(2000);

            List<string> ROTR7 = new List<string>();
            List<string> ROTR18 = new List<string>();
            List<string> SHR3 = new List<string>();

            for (int i = 1; i < 7 + 1; i++)
                ROTR7.Add(Stringbit32.ROTR(input, i).Content);
            for (int i = 1; i < 18 + 1; i++)
                ROTR18.Add(Stringbit32.ROTR(input, i).Content);
            for (int i = 1; i < 3 + 1; i++)
                SHR3.Add(Stringbit32.SHR(input, i).Content);

            Thread.Sleep(1000);
            Console.SetCursorPosition(9, 2);
            _console_alter_text(ROTR7, 100);

            Thread.Sleep(1000);
            Console.SetCursorPosition(9, 3);
            _console_alter_text(ROTR18, 100);

            Thread.Sleep(1000);
            Console.SetCursorPosition(9, 4);
            _console_alter_text(SHR3, 100);


            List<string> results = new List<string>();
            for (int i = 0; i < 32 + 1; i++)
            {
                results.Add(Stringbit32.lowercasesigma0(input).Content.Substring(32 - i).PadLeft(32,' '));
            }

            Thread.Sleep(1000);
            Console.SetCursorPosition(9 + 32, 3);
            Console.Write("  XOR");
            Console.SetCursorPosition(9 + 32, 4);
            Console.Write("  XOR");

            Thread.Sleep(1000);
            Console.SetCursorPosition(9, 6);
            _console_alter_text(results,100);
            Console.SetCursorPosition(0, 7);
        }

        public static void Scene_lowercasesigma1(Stringbit32 input)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.WriteLine("      x: " + input.Content);

            Console.SetCursorPosition(9, Console.CursorTop);
            Console.WriteLine("".PadLeft(32, '-'));

            Console.WriteLine(" ROTR17: " + input.Content);
            Console.WriteLine(" ROTR19: " + input.Content);
            Console.WriteLine("  SHR10: " + input.Content);

            Console.SetCursorPosition(9, Console.CursorTop);
            Console.WriteLine("".PadLeft(32, '-'));

            Console.Write("     σ1: ");

            Thread.Sleep(2000);

            List<string> ROTR17 = new List<string>();
            List<string> ROTR19 = new List<string>();
            List<string> SHR10 = new List<string>();

            for (int i = 1; i < 17 + 1; i++)
                ROTR17.Add(Stringbit32.ROTR(input, i).Content);
            for (int i = 1; i < 19 + 1; i++)
                ROTR19.Add(Stringbit32.ROTR(input, i).Content);
            for (int i = 1; i < 10 + 1; i++)
                SHR10.Add(Stringbit32.SHR(input, i).Content);

            Thread.Sleep(1000);
            Console.SetCursorPosition(9, 2);
            _console_alter_text(ROTR17, 100);

            Thread.Sleep(1000);
            Console.SetCursorPosition(9, 3);
            _console_alter_text(ROTR19, 100);

            Thread.Sleep(1000);
            Console.SetCursorPosition(9, 4);
            _console_alter_text(SHR10, 100);


            List<string> results = new List<string>();
            for (int i = 0; i < 32 + 1; i++)
            {
                results.Add(Stringbit32.lowercasesigma1(input).Content.Substring(32 - i).PadLeft(32, ' '));
            }

            Thread.Sleep(1000);
            Console.SetCursorPosition(9 + 32, 3);
            Console.Write("  XOR");
            Console.SetCursorPosition(9 + 32, 4);
            Console.Write("  XOR");

            Thread.Sleep(1000);
            Console.SetCursorPosition(9, 6);
            _console_alter_text(results, 100);
            Console.SetCursorPosition(0, 7);
        }

        public static void Scene_uppercasesigma0(Stringbit32 input)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.WriteLine("      x: " + input.Content);

            Console.SetCursorPosition(9, Console.CursorTop);
            Console.WriteLine("".PadLeft(32, '-'));

            Console.WriteLine("  ROTR2: " + input.Content);
            Console.WriteLine(" ROTR13: " + input.Content);
            Console.WriteLine(" ROTR22: " + input.Content);

            Console.SetCursorPosition(9, Console.CursorTop);
            Console.WriteLine("".PadLeft(32, '-'));

            Console.Write("     Σ0: ");

            Thread.Sleep(2000);

            List<string> ROTR2 = new List<string>();
            List<string> ROTR13 = new List<string>();
            List<string> ROTR22 = new List<string>();

            for (int i = 1; i < 2 + 1; i++)
                ROTR2.Add(Stringbit32.ROTR(input, i).Content);
            for (int i = 1; i < 13 + 1; i++)
                ROTR13.Add(Stringbit32.ROTR(input, i).Content);
            for (int i = 1; i < 22 + 1; i++)
                ROTR22.Add(Stringbit32.ROTR(input, i).Content);

            Thread.Sleep(1000);
            Console.SetCursorPosition(9, 2);
            _console_alter_text(ROTR2, 100);

            Thread.Sleep(1000);
            Console.SetCursorPosition(9, 3);
            _console_alter_text(ROTR13, 100);

            Thread.Sleep(1000);
            Console.SetCursorPosition(9, 4);
            _console_alter_text(ROTR22, 100);


            List<string> results = new List<string>();
            for (int i = 0; i < 32 + 1; i++)
            {
                results.Add(Stringbit32.uppercasesigma0(input).Content.Substring(32 - i).PadLeft(32, ' '));
            }

            Thread.Sleep(1000);
            Console.SetCursorPosition(9 + 32, 3);
            Console.Write("  XOR");
            Console.SetCursorPosition(9 + 32, 4);
            Console.Write("  XOR");

            Thread.Sleep(1000);
            Console.SetCursorPosition(9, 6);
            _console_alter_text(results, 100);
            Console.SetCursorPosition(0, 7);
        }

        public static void Scene_uppercasesigma1(Stringbit32 input)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.WriteLine("      x: " + input.Content);

            Console.SetCursorPosition(9, Console.CursorTop);
            Console.WriteLine("".PadLeft(32, '-'));

            Console.WriteLine("  ROTR6: " + input.Content);
            Console.WriteLine(" ROTR11: " + input.Content);
            Console.WriteLine(" ROTR25: " + input.Content);

            Console.SetCursorPosition(9, Console.CursorTop);
            Console.WriteLine("".PadLeft(32, '-'));

            Console.Write("     Σ1: ");

            Thread.Sleep(2000);

            List<string> ROTR6 = new List<string>();
            List<string> ROTR11 = new List<string>();
            List<string> ROTR25 = new List<string>();

            for (int i = 1; i < 6 + 1; i++)
                ROTR6.Add(Stringbit32.ROTR(input, i).Content);
            for (int i = 1; i < 11 + 1; i++)
                ROTR11.Add(Stringbit32.ROTR(input, i).Content);
            for (int i = 1; i < 25 + 1; i++)
                ROTR25.Add(Stringbit32.ROTR(input, i).Content);

            Thread.Sleep(1000);
            Console.SetCursorPosition(9, 2);
            _console_alter_text(ROTR6, 100);

            Thread.Sleep(1000);
            Console.SetCursorPosition(9, 3);
            _console_alter_text(ROTR11, 100);

            Thread.Sleep(1000);
            Console.SetCursorPosition(9, 4);
            _console_alter_text(ROTR25, 100);


            List<string> results = new List<string>();
            for (int i = 0; i < 32 + 1; i++)
            {
                results.Add(Stringbit32.uppercasesigma1(input).Content.Substring(32 - i).PadLeft(32, ' '));
            }

            Thread.Sleep(1000);
            Console.SetCursorPosition(9 + 32, 3);
            Console.Write("  XOR");
            Console.SetCursorPosition(9 + 32, 4);
            Console.Write("  XOR");

            Thread.Sleep(1000);
            Console.SetCursorPosition(9, 6);
            _console_alter_text(results, 100);
            Console.SetCursorPosition(0, 7);
        }

        public static void Scene_marjority(Stringbit32 x, Stringbit32 y, Stringbit32 z)
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine("▼".PadLeft(32 + 9, ' '));
            Console.WriteLine("      x: " + x.Content);
            Console.WriteLine("      y: " + y.Content);
            Console.WriteLine("      z: " + z.Content);

            Console.SetCursorPosition(9, Console.CursorTop);
            Console.WriteLine("".PadLeft(32, '-'));

            Console.Write("    MJR: ");

            List<string> results = new List<string>();
            List<string> arrows = new List<string>();

            for (int i = 0; i < 32 + 1; i++)
                results.Add(Stringbit32.majority(x, y, z).Content.Substring(32 - i).PadLeft(32, ' '));
            for (int i = 32 + 1; i > 0; i--)
                arrows.Add("".PadLeft(i - 1, ' ') + "▼" + "".PadRight(32, ' '));


            List<List<string>> texts = new List<List<string>>() { results, arrows };
            List<int[]> positions = new List<int[]> { new int[] { 9, 5 }, new int[] { 9, 0 } };
        
            Thread.Sleep(2000);
            _console_alter_text( texts , positions, 300);
        }

        public static void Scene_choice(Stringbit32 x, Stringbit32 y, Stringbit32 z)
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine("▼".PadLeft(32 + 9, ' '));
            Console.WriteLine("      x: " + x.Content);
            Console.WriteLine("      y: " + y.Content);
            Console.WriteLine("      z: " + z.Content);

            Console.SetCursorPosition(9, Console.CursorTop);
            Console.WriteLine("".PadLeft(32, '-'));

            Console.Write(" CHOICE ");

            List<string> results = new List<string>();
            List<string> arrows = new List<string>();

            List<string> liney = new List<string>();
            List<string> linez = new List<string>();



            for (int i = 0; i < 32 + 1; i++)
                results.Add(Stringbit32.choice(x, y, z).Content.Substring(32 - i).PadLeft(32, ' '));

            for (int i = 32; i > - 1; i--)
            {
                if (i > 30)
                    arrows.Add("▼".PadLeft(32, ' '));
                else
                    arrows.Add("".PadLeft(i, ' ') + "▼" + "".PadRight(32, ' '));

            }
            for (int i = 32 ; i > -1; i--)
            {
                if (i > 31)
                {
                    liney.Add(y.Content);
                    linez.Add(z.Content);
                }
                else if (x.Content.Substring(i,1) == "1")
                {
                    liney.Add( y.Content + " ◄ ");
                    linez.Add( z.Content + "   ");
                }
                else
                {
                    liney.Add( y.Content + "   ");
                    linez.Add( z.Content + " ◄ ");
                }
            }

            List<List<string>> texts = new List<List<string>>() { arrows, liney, linez, results};
            List<int[]> positions = new List<int[]> { new int[] { 9, 0 }, new int[] { 9, 2 }, new int[] { 9, 3 }, new int[] { 9, 5 } };

            Thread.Sleep(2000);
            _console_alter_text(texts, positions, 300);
        }


    }

    class Stringbit32
    {
        public string Content
        {
            get
            {
                string temp = "";
                foreach (bool element in _content)
                {
                    if (element) temp += "1";
                    else temp += "0";
                }
                return temp;
            }

            set
            {
                List<bool> temp = new List<bool>();
                foreach (char element in value)
                {
                    if (element == '0') temp.Add(false);
                    else temp.Add(true);
                }
                _content = temp;
            }
        }

        public Stringbit32 InputPadding(int length)
        {
            while(Content.Length < length)
            {
                Content += "0";
            }
            if (Content.Length > 32)
                Content = Content.Remove(32);
            return this;
        }

        private List<bool> _content = new List<bool>();

        public Stringbit32(string content)
        {
            Content = content;
        }

        public static Stringbit32 XOR(string input1, string input2)
        {
            if (input1.Length != input2.Length)
            {
                return null;
            }

            string temp = "";
            for (int i = 0; i < input1.Length; i++)
            {
                if (input1.Substring(i, 1) == input2.Substring(i, 1))
                    temp += "0";
                else
                    temp += "1";
            }

            return new Stringbit32(temp);
        }

        public static Stringbit32 XOR(Stringbit32 stringbit1, Stringbit32 stringbit2)
        {
            return XOR(stringbit1.Content, stringbit2.Content);
        }

        public static Stringbit32 SUM(string input1, string input2)
        {
            if (input1.Length != input2.Length)
            {
                return null;
            }
            string temp = "";
            bool carry = false;
            for (int i = input1.Length - 1; i > -1; i--)
            {
                int number1 = int.Parse(input1.Substring(i, 1));
                int number2 = int.Parse(input2.Substring(i, 1));
                int sum = number1 + number2;
                if (sum == 0)
                {
                    if (carry)
                        temp = temp.Insert(0, "1");
                    else
                        temp = temp.Insert(0, "0");
                    carry = false;
                }
                else if (sum == 1)
                {
                    if (carry)
                        temp = temp.Insert(0, "0");
                    else
                        temp = temp.Insert(0, "1");
                }
                else if (sum == 2)
                {
                    if (carry)
                        temp = temp.Insert(0, "1");
                    else
                        temp = temp.Insert(0, "0");
                    carry = true;
                }
            }
            return new Stringbit32(temp);
        }

        public static Stringbit32 SUM(Stringbit32 stringbit1, Stringbit32 stringbit2)
        {
            return SUM(stringbit1.Content, stringbit2.Content);
        }

        public static Stringbit32 SUM(List<Stringbit32> inputarray)
        {
            Stringbit32 result = inputarray[0];
            for (int i = 1; i < inputarray.Count; i++)
            {
                result = SUM(result, inputarray[i]);
            }
            return result;
        }

        public static Stringbit32 SHR(string input, int amount)
        {
            if (amount > input.Length)
                amount = input.Length;
            
            if (amount < 0)
                return new Stringbit32(input);

            int inputlength = input.Length;
            string zeros = "";
            for (int i = 0; i < amount; i++)
                zeros += "0";
            input = input.Insert(0, zeros);
            input = input.Remove(inputlength);
            return new Stringbit32(input);
        }

        public static Stringbit32 SHR(Stringbit32 input, int amount)
        {
            input = SHR(input.Content, amount);
            return input;
        }

        public static Stringbit32 ROTR(string input, int amount)
        {
            if (amount >= input.Length)
                amount = amount % input.Length;
            if (amount <= 0)
                return new Stringbit32(input);
            int inputlength = input.Length;

            string substring = input.Substring(input.Length - amount, amount);
            input = input.Insert(0, substring);
            input = input.Remove(inputlength);
            return new Stringbit32(input);
        }

        public static Stringbit32 ROTR(Stringbit32 input, int amount)
        {
            input = ROTR(input.Content, amount);
            return input;
        }

        public static Stringbit32 lowercasesigma0(string input)
        {
            string ROTR7 = ROTR(input, 7).Content;
            string ROTR18 = ROTR(input, 18).Content;
            string SHR3 = SHR(input, 3).Content;

            String result = XOR(ROTR7, ROTR18).Content;
            result = XOR(result, SHR3).Content;
            return new Stringbit32(result);
        }

        public static Stringbit32 lowercasesigma0(Stringbit32 input)
        {
            input = lowercasesigma0(input.Content);
            return input;
        }

        public static Stringbit32 lowercasesigma1(string input)
        {
            string ROTR17 = ROTR(input, 17).Content;
            string ROTR19 = ROTR(input, 19).Content;
            string SHR10 = SHR(input, 10).Content;

            String result = XOR(ROTR17, ROTR19).Content;
            result = XOR(result, SHR10).Content;
            return new Stringbit32(result); ;
        }

        public static Stringbit32 lowercasesigma1(Stringbit32 input)
        {
            input = lowercasesigma1(input.Content);
            return input;
        }

        public static Stringbit32 uppercasesigma0(string input)
        {
            string ROTR2 = ROTR(input, 2).Content;
            string ROTR13 = ROTR(input, 13).Content;
            string ROTR22 = ROTR(input, 22).Content;

            String result = XOR(ROTR2, ROTR13).Content;
            result = XOR(result, ROTR22).Content;
            return new Stringbit32(result);
        }

        public static Stringbit32 uppercasesigma0(Stringbit32 input)
        {
            input = uppercasesigma0(input.Content);
            return input;
        }

        public static Stringbit32 uppercasesigma1(string input)
        {
            string ROTR6 = ROTR(input, 6).Content;
            string ROTR11 = ROTR(input, 11).Content;
            string ROTR25 = ROTR(input, 25).Content;

            String result = XOR(ROTR6, ROTR11).Content;
            result = XOR(result, ROTR25).Content;
            return new Stringbit32(result); ;
        }

        public static Stringbit32 uppercasesigma1(Stringbit32 input)
        {
            input = uppercasesigma1(input.Content);
            return input;
        }

        public static Stringbit32 choice(string x, string y, string z)
        {
            string temp = "";
            for (int i = 0; i < x.Length; i++)
            {
                int selection_number = int.Parse(x.Substring(i, 1));
                if (selection_number == 1)
                    temp += y.Substring(i, 1);
                else
                    temp += z.Substring(i, 1);
            }

            return new Stringbit32(temp);;
        }

        public static Stringbit32 choice(Stringbit32 x, Stringbit32 y, Stringbit32 z)
        {
            return choice(x.Content, y.Content, z.Content);
        }

        public static Stringbit32 majority(string x, string y, string z)
        {
            string temp = "";
            for (int i = 0; i < x.Length; i++)
            {
                int numberx = int.Parse(x.Substring(i, 1));
                int numbery = int.Parse(y.Substring(i, 1));
                int numberz = int.Parse(z.Substring(i, 1));
                int sum = numberx + numbery + numberz;

                if (sum > 1.5)
                    temp += "1";
                if (sum < 1.5)
                    temp += "0";
            }
            return new Stringbit32(temp);
        }

        public static Stringbit32 majority(Stringbit32 x, Stringbit32 y, Stringbit32 z)
        {
            return majority(x.Content, y.Content, z.Content);
        }

        public static string StringToByte(string input)
        {
            string temp = "";
            for (int i = 0; i < input.Length; i++)
            {
                string characeter = input.Substring(i, 1);
                int ascii_number = characeter.ToCharArray()[0];
                string binary_number = Convert.ToString(ascii_number, 2);
                binary_number = binary_number.PadLeft(8, '0');

                temp += binary_number;
            }
            return temp;
        }

    }

    class SHA256
    {
        private Stringbit32 _input;
        public string Output { get; private set; }

        public SHA256(string input)
        {
            _input = new Stringbit32(Stringbit32.StringToByte(input));
        }

        public SHA256(Stringbit32 input)
        {
            _input = input;
        }
        
        private void _padding()
        {
            int block_count = 0;
            while (block_count * 512 < _input.Content.Length)
                block_count++;

            int bit_count = 512 * block_count;
            string bit_massage_length = Convert.ToString(_input.Content.Length, 2);

            _input.Content += "1";
            _input.Content = _input.Content.PadRight(512 - bit_massage_length.Length, '0');
            _input.Content = _input.Content.Insert(_input.Content.Length, bit_massage_length);
        }

        private List<Stringbit32> _massage_schadule()
        {
            List<Stringbit32> Words = new List<Stringbit32>();

            for(int i = 0; i < 64; i++)
            {
                if (i < 16)
                    Words.Add(new Stringbit32(_input.Content.Substring(i * 32, 32)));
                else
                {
                    Words.Add(Stringbit32.SUM(new List<Stringbit32> {Stringbit32.lowercasesigma1(Words[i - 2]),
                               Words[i - 7], Stringbit32.lowercasesigma0(Words[i - 15]), Words[i - 16] }));
                }
            }
            return Words;
        }

        private static bool isPrime(int number)
        {
            int maxNumber = 315;
            bool prime = true;
            for (int i = 2; i < maxNumber; i++)
            {
                if (number % i == 0 && number > i)
                    prime = false;
            }
            return prime;
        }

        private static List<int> GetFirstPrimes(int amount)
        {
            List<int> result = new List<int>();
            int maxNumber = 315;
            for (int i = 2; i < maxNumber; i++)
            {
                if (isPrime(i) && result.Count < amount)
                    result.Add(i);
            }
            return result;
        }

        private List<Stringbit32> _constants()
        {
            List<int> primes = GetFirstPrimes(64);
            List<Stringbit32> thirdroot_prime = new List<Stringbit32>();

            foreach (int prime in primes)
            {
                double value = Math.Pow(prime, 1.0 / 3.0);
                string temp = "";
                for (int i = 0; i < 8; i++)
                {
                    value -= Math.Floor(value);
                    value *= 16;
                    temp += Convert.ToString((int)Math.Floor(value), 16);

                }
                string bytevalue = Convert.ToString(Convert.ToInt32(temp,16), 2).PadLeft(32,'0');
                Stringbit32 stringbit = new Stringbit32(bytevalue);
                thirdroot_prime.Add(stringbit);
            }

            return thirdroot_prime;
        }

        private List<Stringbit32> _initial_hash_values()
        {
            List<int> primes = GetFirstPrimes(8);
            List<Stringbit32> thirdroot_prime = new List<Stringbit32>();

            foreach (int prime in primes)
            {
                double value = Math.Pow(prime, 1.0 / 2.0);
                value -= Math.Floor(value);
                value *=  Math.Pow(2,32);
                value = Math.Floor(value);
                string bytevalue = Convert.ToString((Int64)value,2).PadLeft(32,'0');
                Stringbit32 stringbit = new Stringbit32(bytevalue);
                thirdroot_prime.Add(stringbit);
            }

            return thirdroot_prime;
        }

        public string Compression()
        {
            _padding();

            List<Stringbit32> state_registers = _initial_hash_values();
            List<Stringbit32> words = _massage_schadule();
            List<Stringbit32> constants = _constants();

            Stringbit32 T1 = null;
            Stringbit32 T2 = null;

            for (int i = 0; i < 64; i++)
            {
                T1 = Stringbit32.SUM( new List<Stringbit32>{ Stringbit32.uppercasesigma1(state_registers[4]), constants[i], words[i],
                     Stringbit32.choice(state_registers[4], state_registers[5], state_registers[6]), state_registers[7]});



                T2 = Stringbit32.SUM(new List<Stringbit32>{ Stringbit32.uppercasesigma0(state_registers[0]),
                    Stringbit32.majority(state_registers[0], state_registers[1], state_registers[2])});

                for (int j = 7; j > 0; j--)
                    state_registers[j] = state_registers[j - 1];

                state_registers[0] = Stringbit32.SUM(T1, T2);
                state_registers[4] = Stringbit32.SUM(state_registers[4], T1);
            }

            for (int i = 0; i < 8; i++)
                state_registers[i] = Stringbit32.SUM(state_registers[i], _initial_hash_values()[i]);

            string temp = "";
            foreach (Stringbit32 element in state_registers)
            {

                string bin = element.Content;

                int rest = bin.Length % 4;
                bin = bin.PadLeft(rest, '0');

                string output = "";

                for (int i = 0; i <= bin.Length - 4; i += 4)
                {
                    output += string.Format("{0:X}", Convert.ToByte(bin.Substring(i, 4), 2));
                }


                temp += output;
            }

            Output = temp;
            return temp;
        }

    }

}
