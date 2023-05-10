using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectTextRPG1
{
    internal class Goblin : Monstar
    {
        Random random = new Random();
        private int MoveCount = 0;
        public string image;

        public Goblin()
        {
            icon = 'ⓖ';
            name = "고블린";
            HP = 30;
            MaxHP = 30;
            MP = 10;
            MaxMP = 10;
            AP = 7;
            DP = 1;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("      **         ");
            sb.AppendLine("     *^^*     ** ");
            sb.AppendLine("      **     **  ");
            sb.AppendLine("     ****   **   ");
            sb.AppendLine("    * ** *  **   ");
            sb.AppendLine("   *  **  **     ");
            sb.AppendLine("      **         ");
            sb.AppendLine("     *  *        ");
            sb.AppendLine("    *    *       ");
            sb.AppendLine("    *    *       ");
            sb.AppendLine("    *    *       ");
            image = sb.ToString();
        }
        
        public override void MoveAction()
        {
            
            if (MoveCount++ < 2)
            {
                return;
            }
            MoveCount = 0;

            switch(random.Next(0, 4))
            {
                case 0:
                    Move(Moving.Up);
                    break;
                case 1:
                    Move(Moving.Down);
                    break;
                case 2:
                    Move(Moving.Left);
                    break;
                case 3:
                    Move(Moving.Right);
                    break;
            }
            
        }
    }
}
