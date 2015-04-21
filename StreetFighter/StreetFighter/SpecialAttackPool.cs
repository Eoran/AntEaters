using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetFighter
{
    class SpecialAttackPool
    {

        private static List<SpecialAttack> inactive = new List<SpecialAttack>();
        private static List<SpecialAttack> active = new List<SpecialAttack>();

        public static SpecialAttack Create(string direction, Player player, Vector2 position, int frames)
        {
            if (inactive.Count != 0)
            {
                SpecialAttack obj = inactive[0];
                active.Add(obj);
                inactive.RemoveAt(0);
                return obj;
            }
            else
            {
                SpecialAttack obj = new SpecialAttack(direction, player, position, frames);
                active.Add(obj);
                return obj;
            }
        }

        public static void ReleaseObjcet(SpecialAttack obj)
        {
            CleanUp(obj);
            lock(inactive)
            {
                inactive.Add(obj);
                active.Remove(obj);
            }
        }

        private static void CleanUp(SpecialAttack obj)
        {
            obj.TmpData = null;
        }
    }
}
