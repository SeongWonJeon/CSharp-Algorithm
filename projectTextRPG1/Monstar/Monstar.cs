using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectTextRPG1
{
    public abstract class Monstar
    {
        public string name;
        public Position pos;
        public char icon;

        public int HP;
        public int MaxHP;
        public int MP;
        public int MaxMP;
        public int AP;
        public int DP;

        public abstract void MoveAction();

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
        public void TakeDamage()
        {

        }
        public void Attack()
        {

        }
    }
}
