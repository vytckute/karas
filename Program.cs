using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Kortos
{
    class Korta
    {
        public string simbolis;
        public int skaicius;
        public char raide;
        public string skaiciukas;

        private void Is_string_i_char()
        {
            switch (simbolis)
            {
                case "kryzius":
                    raide = 'K';
                    break;
                case "sirdis":
                    raide = 'S';
                    break;
                case "vynus":
                    raide = 'V';
                    break;
                case "bugnai":
                    raide = 'B';
                    break;


            }
        }

        private void Is_int_i_char()
        {
            switch (skaicius)
            {
                case 14:
                    skaiciukas = "A";
                    break;
                case 11:
                    skaiciukas = "J";
                    break;
                case 13:
                    skaiciukas = "K";
                    break;
                case 12:
                    skaiciukas = "Q";
                    break;
                default:
                    skaiciukas = skaicius.ToString();
                    break;
            }

        }

        public Korta(string simbolis, int skaicius)
        {
            this.simbolis = simbolis;
            this.skaicius = skaicius;
            Is_string_i_char();
            Is_int_i_char();

        }


        class Program
        {
            static void Main(string[] args)
            {/*
                Korta kortele = new Korta("Kryzius", 2);
                Console.WriteLine(kortele.simbolis + " " + kortele.skaicius);
                Console.ReadKey(); */
                Random rng = new Random();
                string[] visi_simboliai = { "kryzius", "sirdis", "vynus", "bugnai" };
                List<Korta> kalade = new List<Korta>();
                int i = 0;
                while (i < 12) //52
                {
                    Korta kortele = new Korta(visi_simboliai[rng.Next(4)], rng.Next(2, 14));
                    int flag = 0;
                    foreach (Korta koort in kalade)
                    {
                        if (koort.skaicius == kortele.skaicius && koort.simbolis == kortele.simbolis)
                        {
                            flag++;
                        }
                    }
                    if (flag == 0)
                    {
                        kalade.Add(kortele);
                        i++;
                    }


                }
                List<Korta> kaladeA = new List<Korta>();
                kaladeA = kalade.Take(12 / 2).ToList<Korta>();//52
                List<Korta> kaladeB = new List<Korta>();
                kaladeB = kalade.Skip(12 / 2).ToList<Korta>();//52
                foreach (Korta koort in kalade)
                {
                    Console.WriteLine(koort.raide + " " + koort.skaiciukas);
                }
                // Console.ReadKey();
                //      }
                karas(kaladeA, kaladeB);
            }


                   public static void karas(List<Korta> kaladeA, List<Korta> kaladeB)
            {
                int index = 0;

                while (kaladeA.Count != 0 & kaladeB.Count != 0)
                {
                    foreach (var item in ((List<Korta>)kaladeA.ToList()).Zip((List<Korta>)kaladeB.ToList(), (a, b) => new { a, b }))

                    {
                        if (item.a.skaicius > item.b.skaicius)
                        {
                            kaladeA.Add(item.b);
                            kaladeB.Remove(item.b);
                        }
                        else if (item.a.skaicius < item.b.skaicius)
                        {
                            kaladeB.Add(item.a);
                            kaladeA.Remove(item.a);
                        }
                        ///sutapo
                        else
                        {
                            /*               if (item.a.skaicius > item.b.skaicius)
                                           {
                                               kaladeA.Add(item.b);
                                               kaladeB.Remove(item.b);
                                               kaladeA.Add(item.b);
                                               kaladeB.Remove(item.b);
                                               kaladeA.Add(item.b);
                                               kaladeB.Remove(item.b);
                                           }
                                           else if (item.a.skaicius++ < item.b.skaicius++)
                                           {
                                               kaladeB.Add(item.a);
                                               kaladeA.Remove(item.a);
                                           }
                                           */
                            continue;
                        }
                        index++;
                    }
                                    }
                if (kaladeA.Count == 0)
                {
                    Console.WriteLine("Laimejo A zaidejas");
                }
                else if (kaladeB.Count == 0)
                {
                    Console.WriteLine("Laimejo B zaidejas");
                }
                                Console.ReadKey();
            } }
        }
    }







