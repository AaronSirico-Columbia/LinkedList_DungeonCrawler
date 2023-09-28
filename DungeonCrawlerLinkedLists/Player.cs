using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonCrawlerLinkedLists
{
    public class Player
    {
        public int HP = 300;
        public int MagicPool = 300;
        public int MagicATK = 100;
        public int Melee = 40;

        public int UseHeal(ref int _magicPool, ref int _hp)
        {
            _hp = _hp + 150;
            _magicPool = _magicPool - 150;
            Console.WriteLine($"Health is now {_hp}");
            return _magicPool & _hp;
        }

        public int Attack(ref int _atk, ref int _hp, string name)
        {
            _hp = _hp - _atk;
            if (_hp > 0)
            {
                Console.WriteLine($"{name} health is {_hp} now.");
                return _hp;
            }
            else
            {
                _hp = 0;
                Console.WriteLine($"{name} is dead");
                return _hp;
            }
            
        }

        public int CastSpell( ref int _atk, ref int _hp, ref int _magicPool, string name)
        {
            _hp = _hp - _atk;
            if (_hp > 0)
            {
                _magicPool = _magicPool - 50;
                Console.WriteLine($"{name} health is {_hp} now.");
                return _magicPool & _hp;
            }
            else 
            {
                _hp = 0;
                Console.WriteLine($"{name} is dead");
                return _hp;

            }
            
        }

        public void FightChoices()
        {
            if (MagicPool <= 0)
            {
                Console.WriteLine($"Health: {HP} | Magic: {MagicPool}");
                Console.WriteLine($"1. Melee Attack");
            }
            else
            {
                Console.WriteLine($"Health: {HP} | Magic: {MagicPool}");
                Console.WriteLine($"1. Melee Attack");
                Console.WriteLine($"2. Cast spell (Uses Magic)");
                Console.WriteLine($"3. Cast heal (Uses Magic)");
            }
        }
    }
}
