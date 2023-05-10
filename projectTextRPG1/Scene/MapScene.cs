using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace projectTextRPG1
{
    internal class MapScene : Scene
    {
        public MapScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            PrintMap();
        }

        public override void Update()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    Data.player.Move(Moving.Up);
                    break;
                case ConsoleKey.DownArrow:
                    Data.player.Move(Moving.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    Data.player.Move(Moving.Left);
                    break;
                case ConsoleKey.RightArrow:
                    Data.player.Move(Moving.Right);
                    break;
            }

            foreach(Monstar monstar in Data.monstars)
            {
                monstar.MoveAction();
            }
        }
        private void PrintMap()
        {
            Console.ForegroundColor = ConsoleColor.White;
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < Data.map.GetLength(0); y++)
            {
                for (int x = 0; x < Data.map.GetLength(1); x++)
                {
                    if (Data.map[y, x])
                        sb.Append('　');
                    else
                        sb.Append('▩');
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(Data.player.pos.x * 2, Data.player.pos.y);
            Console.Write(Data.player.icon);

            Console.ForegroundColor = ConsoleColor.Green;
            foreach(Monstar monstar in Data.monstars)
            {
                Console.SetCursorPosition(monstar.pos.x * 2, monstar.pos.y);
                Console.Write(monstar.icon);
            }
        }
    }
}
