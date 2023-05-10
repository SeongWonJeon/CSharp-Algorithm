using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace projectTextRPG1
{
    public class Player
    {
        public char icon = '♥';
        public Position pos;
        private string image;

        public Player()
        {
            HP = 100;
            MaxHP = 100;
            MP = 30;
            MaxMP = 30;
            Level = 1;
            CurExp = 0;
            MaximumExp = 100;
            AP = 10;
            DP = 1;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("       ****     ");
            sb.AppendLine("       *  *     ");
            sb.AppendLine("       ****     ");
            sb.AppendLine("      * ** *    ");
            sb.AppendLine("     *  **  *   ");
            sb.AppendLine("    *   **   *  ");
            sb.AppendLine("       ****     ");
            sb.AppendLine("       *  *     ");
            sb.AppendLine("       *  *     ");
            image = sb.ToString();
        }

        public int HP { get; private set; }
        public int MaxHP { get; private set;}
        public int MP { get; private set; }
        public int MaxMP { get; private set; }
        public int AP { get; private set; }
        public int DP { get; private set; }
        public int Level { get; private set; }
        public int CurExp { get; private set; }
        public int MaximumExp { get; private set; }

        public void Move(Moving mov)
        {
            Position moveSave = pos;

            switch (mov)
            {
                case Moving.Up:
                    pos.y--;
                    break;
                case Moving.Down:
                    pos.y++;
                    break;
                case Moving.Left:
                    pos.x--;
                    break;
                case Moving.Right:
                    pos.x++;
                    break;
            }

            if (!Data.map[pos.y, pos.x])
            {
                pos = moveSave;
            }
        }
        public void Attack()
        {
            
        }
        public void TakeDamage()
        {

        }
        public void UseItem()
        {

        }
    }
}
