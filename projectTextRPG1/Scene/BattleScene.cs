using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace projectTextRPG1
{
    internal class BattleScene : Scene
    {
        public BattleScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("1. 공격하기");
            sb.AppendLine("2. 도망가기");
            sb.Append("선택하세요 : ");

            Console.WriteLine(sb.ToString());
        }

        public override void Update()
        {
            string input = Console.ReadLine();
        }
    }
}
