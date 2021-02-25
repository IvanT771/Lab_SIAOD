using System;


namespace DopTaskSIAOD
{
    class Player
    {
        private int height = 0;
        private int wingsan = 0;
        private int battingAverage = 0;
        private int selection = 0;
        private int pass = 0;

        public int rang = 3;
        public Player(int h,int w, int b, int s, int p)
        {
            height = h;
            wingsan = w;
            battingAverage = b;
            selection = s;
            pass = p;

            SetRang();
        }

        private void SetRang()
        {
            //rang 0:
            int countHeight = 0;
            int countMedium = 0;
            int countLow = 0;

            if (height > 220) {countHeight++;}else
            if (height >= 205) { countMedium++;}
            if (height >= 190) { countLow++;}

            if (wingsan > 250) { countHeight++; }else
            if (wingsan >= 225) { countMedium++; }
            if (wingsan >= 200) { countLow++; }

            if (battingAverage > 20) { countHeight++; }else
            if (battingAverage >= 15) { countMedium++; }
            if (battingAverage >= 10) { countLow++; }

            if (selection > 6) { countHeight++; }else
            if (selection >= 4) { countMedium++; }
            if (selection >= 2) { countLow++; }

            if (pass > 7) { countHeight++; }else
            if (pass >= 5) { countMedium++; }
            if (pass >= 3) { countLow++; }

            if (countHeight >= 3 && (height>220 || wingsan >250)) { rang = 0; return;}
            if((countHeight >= 2 && countMedium > 0)|| (countMedium >= 3 && countLow==5)) { rang = 1; return;}
            if((countMedium>=1 && countHeight >= 1) || (countMedium >= 3)) { rang = 2; return;}

            rang = 3;


        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0;
            Console.WriteLine("Введите кол-во игроков");
            N = int.Parse(Console.ReadLine());

            Player[] players = new Player[N];
            for (int i = 0; i < players.Length; i++)
            {
                int h,w,s,r,p;
                h = int.Parse(Console.ReadLine());
                w = int.Parse(Console.ReadLine());
                s = int.Parse(Console.ReadLine());
                r = int.Parse(Console.ReadLine());
                p = int.Parse(Console.ReadLine());

                players[i] = new Player(h,w,s,r,p);
               
            }

            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine("Player № " + i + " rang: " + players[i].rang);
            }
            Console.Read();
        }
    }
}
