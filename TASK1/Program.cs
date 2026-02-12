using System;
using System.Text;

namespace day2
{
    internal class Task1
    {
        public void Rev() {
            string Sen = "Welcome to c# program by wipro";
            string[] words = Sen.Split();
            for(int i = 0; i < words.Length; i++) {
                if (i % 2 != 0) {
                    StringBuilder sb = new StringBuilder();
                    for(int j = words[i].Length - 1; j >= 0; j--) {
                        sb.Append(words[i][j]);
                    }
                    words[i] = sb.ToString();


                }

            }
            Console.WriteLine(string.Join(" ", words));


        }
        static void Main() {
            Task1 r = new Task1();
            r.Rev();
        }
        }



   
    }

