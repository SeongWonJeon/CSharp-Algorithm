using Project_TextRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace project_TextRPG
{
    public class Goblin : Monster
    {
        Random random = new Random();
        private int moveTurn = 0;
        

        public Goblin()
        {
            icon = '㈀';
            name = "고블린";
            curHp = 20;
            maxHp = 20;
            ap = 6;
            dp = 0;


            StringBuilder sb = new StringBuilder();
            sb.AppendLine("     ");
            image = sb.ToString();

        }
        

        public override void MoveAction()
        {
            if(moveTurn++ % 2 != 0)
            {
                return;
            }
            moveTurn = 0;

            switch(random.Next(0, 4))
            {
                case 0:
                    Move(Direction.Up);
                    break;
                case 1:
                    Move(Direction.Down);
                    break;
                case 2:
                    Move(Direction.Left);
                    break;
                case 3:
                    Move(Direction.Right);
                    break;
            }
        }
    }
}
