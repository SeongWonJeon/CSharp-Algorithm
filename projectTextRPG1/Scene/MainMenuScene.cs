using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace projectTextRPG1
{
    internal class MainMenuScene : Scene
    {
        public MainMenuScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("1. 게임시작");
            sb.AppendLine("2. 세이브파일");
            sb.AppendLine("3. 옵션");
            sb.AppendLine("4. 게임종료");
            sb.Append("보기를 선택하세요 : ");

            Console.Write(sb.ToString());
        }
        public override void Update()
        {
            string option = Console.ReadLine();

            int command;
            if(!int.TryParse(option, out command))
            {
                Console.WriteLine("다시 입력해주세요.");
                Thread.Sleep(1000);
                return;
            }

            switch (command)
            {
                case 1:
                    game.GameStart();
                    Console.WriteLine("게임시작");
                    Thread.Sleep(1000);
                    break;
                case 2:
                    // 세이브파일 목록 가져오기
                    break;
                case 3:
                    break;
                case 4:
                    game.GameOver();
                    Console.WriteLine("게임종료");
                    Thread.Sleep(1000);
                    break;
                default:
                    Console.WriteLine("다시 입력해주세요.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}
