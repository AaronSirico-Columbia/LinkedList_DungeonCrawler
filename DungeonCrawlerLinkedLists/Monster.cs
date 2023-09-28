using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_CharacterCreation
{

    public class Monster
    {
        public Monster(string type, int hP, int mP, int aP, int dEF)
        {
            Type = type;
            HP = hP;
            MP = mP;
            AP = aP;
            DEF = dEF;
        }

        public string Type { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }

        public int AP { get; set; }

        public int DEF { get; set; }
    }




}