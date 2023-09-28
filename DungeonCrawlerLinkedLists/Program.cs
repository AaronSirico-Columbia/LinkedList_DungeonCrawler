using DungeonCrawlerLinkedLists;
using IO_CharacterCreation;

Player player = new Player();

Random rand = new Random();

string input = "";
int RandNum = rand.Next(0, 2);


string filePath = @"C:\Users\aarro\source\repos\DungeonCrawlerLinkedLists\DungeonCrawlerLinkedLists\Stats.txt";
LinkedList<Monster> monsters = new LinkedList<Monster>();
List<string> lines = new List<string>();


StreamReader sr = new StreamReader(filePath);


lines = File.ReadAllLines(filePath).ToList();
int i = 0;

foreach (string line in lines)
{

    if (i < 1)
    {
        i++;
    }
    else
    {
        string[] items = line.Split(' ');
        Monster monster = new Monster(items[0], Int32.Parse(items[1]), Int32.Parse(items[2]), Int32.Parse(items[3]), Int32.Parse(items[4]));
        monsters.AddFirst(monster);
    }
}

Console.WriteLine("Type Q at anytime to end application.");

while (input.ToUpper() != "Q")
{
    
    foreach (Monster monster in monsters)
    {
        Console.WriteLine("Enter Room 1,2, or 3?");
        if (monsters.First.Value.HP == 0 && monsters.First.Next.Value.HP == 0 && monsters.Last.Value.HP == 0)
        {
            Console.Clear();
            Console.WriteLine("You have beat the dungeon. Press Q to end application.");
        }
        if (player.HP <= 0)
        {
            Console.Clear();
            Console.WriteLine("You have lost the dungeon. Press Q to end application.");
        }
        
        input = Console.ReadLine();
        if (input == "1")
        {
            Console.WriteLine($"You have entered room 1.");
            if (monsters.First.Value.Type == "Dwarf")
            {
                while (monsters.First.Value.HP > 0)
                {
                    Console.WriteLine($"A {monsters.First.Value.Type} is standing across the room from you.");
                    int DwarfHP = monsters.First.Value.HP;
                    int DwarfDEF = monsters.First.Value.DEF;
                    int DwarfATK = monsters.First.Value.AP;
                    int DwarfMAG = monsters.First.Value.MP;

                    if (DwarfHP >= 0)
                    {
                        
                        switch (RandNum)
                        {
                            case 0:
                                if (player.HP <= 0)
                                {
                                    player.HP = 0;
                                }
                                else
                                {
                                    player.HP = player.HP - DwarfATK;
                                    Console.WriteLine($"Dwarf has attacked you.");
                                }
                                break;
                            case 1:
                                if (player.HP <= 0)
                                {
                                    player.HP = 0;
                                }
                                else
                                {
                                    player.HP = player.HP - DwarfMAG;
                                    Console.WriteLine($"Dwarf has cast spell on you.");
                                }
                                break;
                            case 2:
                                if (player.HP <= 0)
                                {
                                    player.HP = 0;
                                }
                                else
                                {
                                    DwarfHP = DwarfHP + DwarfDEF;
                                    Console.WriteLine($"Dwarf has used heal on themself.");
                                }
                                break;
                            default:
                                Console.WriteLine("Dwarf Attack Error.");
                                break;
                        }
                        player.FightChoices();
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                             
                                    Console.WriteLine("Player used Melee.");
                                    player.Attack(ref player.Melee, ref DwarfHP, monsters.First.Value.Type);
                                    monsters.First.Value.HP = DwarfHP;
                                
                                break;
                            case "2":
                               
                                    Console.WriteLine("Player casted a Spell.");
                                    player.CastSpell(ref player.MagicATK, ref DwarfHP, ref player.MagicPool, monsters.First.Value.Type);
                                    monsters.First.Value.HP = DwarfHP;
                                
                                break;
                            case "3":
                               
                                    Console.WriteLine("Player casted Heal Spell.");
                                    player.UseHeal(ref player.MagicPool, ref player.HP);
                                
                                break;
                            default:
                                Console.WriteLine("Player Attack Error.");
                                break;
                        }
                    }


                }
                if (monsters.First.Value.HP <= 0)
                {
                  
                    Console.WriteLine("This room is empty.");
                    
                }
            }
        }


        if (input == "2")
        {
            Console.WriteLine($"You have entered room 2.");
            if (monsters.First.Next.Value.Type == "Mage")
            {
                while (monsters.First.Next.Value.HP > 0)
                {
                    Console.WriteLine($"A {monsters.First.Next.Value.Type} is standing across the room from you.");
                    int MageHP = monsters.First.Next.Value.HP;
                    int MageDEF = monsters.First.Next.Value.DEF;
                    int MageATK = monsters.First.Next.Value.AP;
                    int MageMAG = monsters.First.Next.Value.MP;

                    if (MageHP >= 0)
                    {

                        switch (RandNum)
                        {
                            case 0:
                                if (player.HP <= 0)
                                {
                                    player.HP = 0;
                                   
                                }
                                else
                                {
                                    player.HP = player.HP - MageATK;
                                    Console.WriteLine($"Mage has attacked you.");
                                }
                                break;
                            case 1:
                                if (player.HP <= 0)
                                {
                                    player.HP = 0;
                                    
                                }
                                else
                                {
                                    player.HP = player.HP - MageMAG;
                                    Console.WriteLine($"Mage has cast spell on you.");
                                }
                                break;
                            case 2:
                                if (player.HP <= 0)
                                {
                                    player.HP = 0;
                                   
                                }
                                else
                                {
                                    MageHP = MageHP + MageDEF;
                                    Console.WriteLine($"Mage has used heal on themself.");
                                }
                                break;
                            default:
                                Console.WriteLine("Mage Attack Error.");
                                break;
                        }
                        player.FightChoices();
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                         
                                    Console.WriteLine("Player used Melee.");
                                    player.Attack(ref player.Melee, ref MageHP, monsters.First.Next.Value.Type);
                                    monsters.First.Next.Value.HP = MageHP;
                                
                                break;
                            case "2":
                              
                                    Console.WriteLine("Player casted a Spell.");
                                    player.CastSpell(ref player.MagicATK, ref MageHP, ref player.MagicPool, monsters.First.Next.Value.Type);
                                    monsters.First.Next.Value.HP = MageHP;
                                
                                break;
                            case "3":
                                
                                    Console.WriteLine("Player casted Heal Spell.");
                                    player.UseHeal(ref player.MagicPool, ref player.HP);
                                
                                break;
                            default:
                                Console.WriteLine("Player Attack Error.");
                                break;
                        }
                    }


                }
                if (monsters.First.Next.Value.HP <= 0)
                {
                    
                    Console.WriteLine("This room is empty.");
                }
            }
        }
        if (input == "3")
        {
            Console.WriteLine($"You have entered room 3.");
            if (monsters.Last.Value.Type == "Knight")
            {
                while (monsters.Last.Value.HP > 0)
                {
                    Console.WriteLine($"A {monsters.Last.Value.Type} is standing across the room from you.");
                    int KnightHP = monsters.Last.Value.HP;
                    int KnightDEF = monsters.Last.Value.DEF;
                    int KnightATK = monsters.Last.Value.AP;
                    int KnightMAG = monsters.Last.Value.MP;

                    if (KnightHP >= 0)
                    {

                        switch (RandNum)
                        {
                            case 0:
                                if (player.HP <= 0)
                                {
                                    player.HP = 0;
                                   
                                }
                                else
                                {
                                    player.HP = player.HP - KnightATK;
                                    Console.WriteLine($"Knight has attacked you.");
                                }
                                break;
                            case 1:
                                if (player.HP <= 0)
                                {
                                    player.HP = 0;
                                
                                }
                                else
                                {
                                    player.HP = player.HP - KnightMAG;
                                    Console.WriteLine($"Knight has cast spell on you.");
                                }
                                break;
                            case 2:
                                if (player.HP <= 0)
                                {
                                    player.HP = 0;
                                
                                }
                                else
                                {
                                    KnightHP = KnightHP + KnightDEF;
                                    Console.WriteLine($"Knight has used heal on themself.");
                                }
                                break;
                            default:
                                Console.WriteLine("Knight Attack Error.");
                                break;
                        }
                        player.FightChoices();
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                    Console.WriteLine("Player used Melee.");
                                player.Attack(ref player.Melee, ref KnightHP, monsters.Last.Value.Type);
                                monsters.Last.Value.HP = KnightHP;
                                break;
                            case "2":
                                Console.WriteLine("Player casted a Spell.");
                                player.CastSpell(ref player.MagicATK, ref KnightHP, ref player.MagicPool, monsters.Last.Value.Type);
                                monsters.Last.Value.HP = KnightHP;
                                break;
                            case "3":
                                Console.WriteLine("Player casted Heal Spell.");
                                player.UseHeal(ref player.MagicPool, ref player.HP);
                                break;
                            default:
                                Console.WriteLine("Player Attack Error.");
                                break;
                        }
                    }


                }
                if (monsters.Last.Value.HP <= 0)
                {
                    
                    Console.WriteLine("This room is empty.");
                }
            }

        }
       

    }

}