using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace opp
{


    internal class Program
    {
        static string RandomBilNR(string b)
        {
            Random random = new Random();
            int E = random.Next(65, 90);
            int c = random.Next(65, 90);
            byte[] e = new byte[2];
            e[0] = (byte)E;
            e[1] = (byte)c;
            b += Encoding.ASCII.GetString(e);
            int z = random.Next(1, 9); int d = random.Next(1, 9); int f = random.Next(1, 9); int g = random.Next(1, 9);
            b += " " + z + d.ToString() + f + g.ToString();
            return b;
        }
        class bil
        {

            public string regnr = "";
            public string farge;
            public string aarsmodell;
            public string modell;
            public string navn;
            private bool startet = false;
            private int speed = 0;
            private bool speedup = false;
            public void start()
            {
                Random e = new Random();
                int one = e.Next(0, 5);
                int two = e.Next(0, 5);
                if (one == two)
                {
                    Console.WriteLine("Bilen klarte ikke å starte. Prøv på nytt");
                    return;
                }

                Console.WriteLine(navn + " har startet");
                startet = true;
            }
            public void kjorgammel()
            {
                if (startet)
                {
                    Thread.Sleep(1000);
                    for (int i = 0; speed <= 70; i++)
                    {
                        speed++;

                        if (speed >= 40 && !speedup)
                        {
                            for (int e = 0; speed <= 64; e++)
                            {
                                speed += 2;
                                Thread.Sleep(50);
                                Console.Write(speed + " ");
                            }
                            speedup = true;
                            if (speed > 60)
                            {
                                Console.WriteLine();
                                Console.WriteLine(navn + " kjører fort!");
                                break;
                            }
                        }
                        Thread.Sleep(50);
                        Console.Write(speed + " ");
                    }


                }
                else
                {
                    Console.WriteLine("du må starte " + navn + " hvis du vil kjøre");
                }
            }
            public void kjorny()
            {
                int speed = 0;
                int gear = 1;
                int topSpeed = 180;
                if(!startet) { Console.WriteLine("Kunne ikke kjøre bilen dersom den ikke starta."); }
                else
                {
                    Console.WriteLine(navn + " har startet å kjøre. Bruk piltastene på numpaden til å kjøre");
                }
                while (startet)
                {
                    
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.KeyChar.ToString().ToLower() == "8")
                    {
                        if (speed >= 60 && gear < 2)
                        {
                            speed = 60;
                            Console.WriteLine("Du går så fort som mulig, du må gire!");
                        }

                        else if (speed >= 90 && gear == 2 && !(gear > 2))
                        {
                            speed = 90;
                            Console.WriteLine("Du går så fort som mulig, du må gire!");
                        }
                        else if (speed > topSpeed)
                        {
                            Console.WriteLine("Du kan ikke gå raskere enn " + topSpeed);
                        }
                        else
                        {
                            speed++;
                            Console.WriteLine(speed);
                        }

                    }
                    else if (key.KeyChar.ToString().ToLower() == "2")
                    {
                        if (speed <= -10)
                        {
                            speed = -10;
                            Console.WriteLine("Du går baklengs så fort som mulig");
                        }
                        else
                        {
                            speed--;
                            Console.WriteLine(speed);
                        }
                    }
                    else if (key.KeyChar.ToString() == "6" && gear < 6 )
                    {
                        if(speed < 60 && gear >= 1)
                        {
                            gear -=1;
                            Console.WriteLine("Du kan ikke gire uten å gå til topspeed for gear " + gear);
                        }
                        if(speed<90 && gear >= 2)
                        {
                            gear = 2;
                            Console.WriteLine("Du kan ikke gire uten å gå til topspeed for gear " + gear);
                        }
                        else
                        {
                            gear++;
                            Console.WriteLine("Gear " + gear);
                        }
                        
                    }
                    else if (key.KeyChar.ToString() == "4" && gear > 0)
                    {
                        
                        
                        
                            gear--;
                            Console.WriteLine("Gear " + gear);
                        
                        
                    }

                }
            }
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            bil minbil = new bil();
            minbil.regnr = RandomBilNR(minbil.regnr);
            Console.WriteLine(minbil.regnr);
            minbil.navn = "jimmy";
            minbil.start();
            minbil.kjorny();
            


        }
    }
}
