using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace projectTextRPG1
{
    internal static class Data
    {
        public static bool[,] map;
        public static Player player;
        public static List<Monstar> monstars;

        public static void Init()
        {
            monstars = new List<Monstar>();
            player = new Player();
        }

        public static void Release()
        {

        }
        public static void StartMap1()
        {
            map = new bool[,]
            {// 15,15
                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                {false,  true,  true, false,  true,  true, false,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true, false, false,  true,  true, false,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true, false,  true,  true,  true, false,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true, false,  true,  true,  true, false,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true, false,  true,  true,  true, false,  true,  true, false,  true,  true,  true,  true, false },
                {false,  true, false,  true,  true,  true, false,  true,  true, false,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true,  true, false,  true,  true, false,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true,  true, false,  true,  true, false,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true,  true,  true,  true,  true, false,  true,  true,  true,  true, false },
                {false, false, false,  true,  true,  true,  true,  true,  true, false,  true,  true,  true,  true, false },
                {false,  true,  true,  true, false,  true,  true,  true,  true, false, false, false, false,  true, false },
                {false,  true,  true,  true, false,  true,  true,  true,  true, false, false, false,  true,  true, false },
                {false,  true,  true,  true, false,  true,  true,  true,  true, false, false, false,  true,  true, false },
                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }
            };
            player.pos = new Position(2, 12);       // x, y 순으로

            Goblin goblin1 = new Goblin();
            goblin1.pos = new Position(2, 7);
            monstars.Add(goblin1);

            Goblin goblin2 = new Goblin();
            goblin2.pos = new Position(5, 2);
            monstars.Add(goblin2);

            Goblin goblin3 = new Goblin();
            goblin3.pos = new Position(8, 12);
            monstars.Add(goblin3);

            Goblin goblin4= new Goblin();
            goblin4.pos = new Position(13, 3);
            monstars.Add(goblin4);

            Goblin goblin5 = new Goblin();
            goblin5.pos = new Position(11, 8);
            monstars.Add(goblin5);
        }
        public static void StartMap2()
        {
            map = new bool[,]
            {// 15,15
                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                {false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }
            };
        }
    }
}
