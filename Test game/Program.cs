using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDRPG
{
    class Program
    {
        public static string GameVer = "0.0.2-WiP";
        public static string GameName = "Rolling dice RPG";
        public static int itemID;
        public static int WasInShop;
        public static int WasInShopName;
        public static int ShopItemCount;
        public static List<int> ShopItemsID = new List<int>();
        static Person Peep = new Person();
        static Enemy BadGuy = new Enemy();
        static Random rnd = new Random();
        public struct Person
        {
            public int HitPoints, maxHitPoints;
            public int defPoints, intPoints, attackPoints;
            public int accPoints;
            public int upgPoints;
            public int goldAmount;
            public double xpAmount;
            public int Level;
            public double maxXpAmount;
            public int Class;
            public int firstDice;
            public int secondDice;
            public int EqualDices;
            public int tilesTraveled;
            public string className;
            public string Name;
            public int MimicFight;
            public int AddHitpoints;
            public int InventorySpace;
            public int SelectedItem;
            public int SelectedWear;
            public int SelectedShop;
            public int MaxInventorySpace;
            public int[] ItemN;
            public string[] ItemName;
            public int[] ItemType;
            public string[] Wearable;
            public int[] WearI;
            public string[] WearName;
            public int[] ItemsIShop;
            public string[] ShopItemName;
            public int[] ShopItemType;
            public int[] ItemPrice;
        }
        public struct Enemy
        {
            public double EnemyHP;
            public double EnemyMaxHP;
            public double EnemyATT;
            public double EnemyDEF;
            public double EnemyValue;
            public string EnemyName;
        }
        public static void SetUpGame()
        {
            Console.Title =  GameName + " " + GameVer;
            Console.WriteLine("Welcome to the " + GameName);
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            Peep.MaxInventorySpace = 10;
            Peep.ItemN = new int[Peep.MaxInventorySpace];
            Peep.ItemName = new string[20];
            Peep.ItemType = new int[20];
            Peep.ShopItemName = new string[20];
            Peep.ShopItemType = new int[20];
            Peep.Wearable = new string[10];
            Peep.ItemPrice = new int[20];
            Peep.WearI = new int[10];
            Peep.WearName = new string[10];
            Peep.ItemsIShop = new int[10];
            Peep.Wearable[0] = "Helmet";
            Peep.Wearable[1] = "Body";
            Peep.Wearable[2] = "Legs";
            Peep.Wearable[3] = "Shield";
            Peep.Wearable[4] = "Weapon";
            for(int i = 0; i < 5; i++)
            {
                Peep.WearI[i] = 0;
            }
        }
        public static double GetRandomNumber(double minimum, double maximum)
        {
            return rnd.NextDouble() * (maximum - minimum) + minimum;
        }
        public static void Menu()
        {
            Console.Title = GameName + " " + GameVer;
            Console.Clear();
            Console.WriteLine(GameName + "\nPress 1 to read rules\nPress 2 to start playing\nPress 3 to exit the game");
            var k = Console.ReadKey(true);
            if (k.Key == ConsoleKey.NumPad1 || k.Key == ConsoleKey.D1)
            {
                Rules();
            }
            else if (k.Key == ConsoleKey.NumPad2 || k.Key == ConsoleKey.D2)
            {
                Console.Clear();
                NameSelection();
            }
            else if (k.Key == ConsoleKey.NumPad3 || k.Key == ConsoleKey.D3)
            {
                EndGame();
            }
            else Menu();
        }
        public static void Rules()
        {
            Console.Clear();
            Console.WriteLine("Rules:");
            Console.WriteLine("You Roll two dices and go forward;");
            Console.WriteLine("If you roll and your dices are equal you get special event;");
            Console.WriteLine("If you roll more then 6 you encounter various enemies");
            Console.WriteLine("Every 100 tiles you access shop where you can buy gear which helps you progress");
            Console.WriteLine("You have 3 classes to choose from;");
            Console.WriteLine("Every Class comes with different stats;");
            Console.WriteLine("Reach lvl 20 to fight final boss.");
            Console.WriteLine("----------------------");
            Console.WriteLine("Press 1 to return to menu\nPress 2 to start playing");
            var k = Console.ReadKey(true);
            if (k.Key == ConsoleKey.NumPad1 || k.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Menu();
            }
            else if (k.Key == ConsoleKey.NumPad2 || k.Key == ConsoleKey.D2)
            {
                Console.Clear();
                NameSelection();
            }
            else Rules();
        }
        public static void EndGame()
        {
            Environment.Exit(0);
        }
        public static void NameIsTooLong()
        {
            Console.WriteLine("Name is longer then than 10 characters, type your name again");
            System.Threading.Thread.Sleep(1500);
            Console.Clear();
            NameSelection();
        }
        public static void NameSelection()
        {
            Console.WriteLine("Insert your name(Max Length is 10 characters):\n(Leave blank if you want to go back to menu)");
            Console.Title = GameName + " " + GameVer;
            int maxLength = 10;
            Peep.Name = Console.ReadLine();
            if (Peep.Name.Length > maxLength)
            {
                NameIsTooLong();
            }
            else if (Peep.Name.Length == 0)
            {
                Console.Clear();
                Menu();
            }
            Console.Title = Console.Title + " : " + Peep.Name;
            ClassSelection();
        }
        public static void ClassSelection()
        {
            Console.Clear();
            Console.WriteLine("Choose your class(Press number shown near the name to choose it):");
            Console.WriteLine("1 - Warrior, 2 - Rogue, 3 - Monk");
            Console.WriteLine("Press Escape to go back to name selection.");
            var k = Console.ReadKey(true);
            if (k.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                NameSelection();
            }
            else while (true)
                {
                    if (k.Key == ConsoleKey.NumPad1 || k.Key == ConsoleKey.NumPad2 || k.Key == ConsoleKey.NumPad3 || k.Key == ConsoleKey.D1 || k.Key == ConsoleKey.D2 || k.Key == ConsoleKey.D3 || k.Key == ConsoleKey.NumPad9 || k.Key == ConsoleKey.D9)
                    {
                        if (k.Key == ConsoleKey.NumPad1 || k.Key == ConsoleKey.D1)
                        {
                            Console.Clear();
                            Console.WriteLine("You chose Warrior.");
                            Console.WriteLine("Warrior has high defence which provides more chances to reflect damage while using block attack.");
                            Console.WriteLine("Warrior's attack is avarage.");
                            Console.WriteLine("Warrior has almost no healing and high health.");
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("Press Enter to be Warrior and start a game. \nPress any other key to go back to class selection.");
                            k = Console.ReadKey(true);
                            if (k.Key == ConsoleKey.Enter)
                            {
                                for(int i = 0; i < 5; i++)
                                {
                                    Peep.WearI[i] = 0;
                                }
                                Peep.HitPoints = Peep.maxHitPoints = 50;
                                Peep.AddHitpoints = 16;
                                Peep.tilesTraveled = 0;
                                Peep.defPoints = 10;
                                Peep.intPoints = 2;
                                Peep.accPoints = 5;
                                Peep.attackPoints = 5;
                                Peep.Class = 1;
                                Peep.InventorySpace = 0;
                                Peep.upgPoints = 0;
                                Peep.className = "Warrior";
                                Peep.goldAmount = 0;
                                Peep.xpAmount = 0;
                                Peep.maxXpAmount = 35;
                                Peep.Level = 1;
                                WasInShop = 0;
                                Console.Clear();
                                Console.WriteLine("Good Luck!");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                                Game();
                            }
                            else
                            {
                                Console.Clear();
                                ClassSelection();
                            }
                        }
                        if (k.Key == ConsoleKey.NumPad2 || k.Key == ConsoleKey.D2)
                        {
                            Console.Clear();
                            Console.WriteLine("You chose Rogue.");
                            Console.WriteLine("Rogue is all around Class");
                            Console.WriteLine("Rogue's attack, defence and intelligent points are avarage.");
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("Press Enter to be Rogue and start a game. \nPress any other key to go back to class selection.");
                            k = Console.ReadKey(true);
                            if (k.Key == ConsoleKey.Enter)
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    Peep.WearI[i] = 0;
                                }
                                Peep.HitPoints = Peep.maxHitPoints = 40;
                                Peep.AddHitpoints = 16;
                                Peep.tilesTraveled = 0;
                                Peep.defPoints = 5;
                                Peep.intPoints = 4;
                                Peep.accPoints = 10;
                                Peep.attackPoints = 7;
                                Peep.InventorySpace = 0;
                                Peep.Class = 2;
                                Peep.upgPoints = 0;
                                Peep.className = "Rogue";
                                Peep.goldAmount = 0;
                                Peep.xpAmount = 0;
                                Peep.maxXpAmount = 35;
                                Peep.Level = 1;
                                WasInShop = 0;
                                Console.Clear();
                                Console.WriteLine("Good Luck!");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                                Game();
                            }
                            else
                            {
                                Console.Clear();
                                ClassSelection();
                            }
                        }
                        if (k.Key == ConsoleKey.NumPad3 || k.Key == ConsoleKey.D3)
                        {
                            Console.Clear();
                            Console.WriteLine("You chose Monk.");
                            Console.WriteLine("Monk has high intelligent which provides more healing per few tiles.");
                            Console.WriteLine("Monk's attack is avarage.");
                            Console.WriteLine("Monk almost have no defence stats and low health.");
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("Press Enter to be Monk and start a game. \nPress any other key to go back to class selection.");
                            k = Console.ReadKey(true);
                            if (k.Key == ConsoleKey.Enter)
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    Peep.WearI[i] = 0;
                                }
                                Peep.HitPoints = Peep.maxHitPoints = 35;
                                Peep.AddHitpoints = 16;
                                Peep.tilesTraveled = 0;
                                Peep.defPoints = 2;
                                Peep.intPoints = 8;
                                Peep.accPoints = 10;
                                Peep.attackPoints = 5;
                                Peep.InventorySpace = 0;
                                Peep.Class = 3;
                                Peep.upgPoints = 0;
                                Peep.className = "Monk";
                                Peep.goldAmount = 0;
                                Peep.xpAmount = 0;
                                Peep.maxXpAmount = 35;
                                Peep.Level = 1;
                                WasInShop = 0;
                                Console.Clear();
                                Console.WriteLine("Good Luck!");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                                Game();
                            }
                            else
                            {
                                Console.Clear();
                                ClassSelection();
                            }
                        }
                        if (k.Key == ConsoleKey.NumPad9 || k.Key == ConsoleKey.D9)
                        {
                            Console.Clear();
                            Console.WriteLine("You chose to Cheat.");
                            Console.WriteLine("Fooking hacker. Press Enter to hack it.");
                            k = Console.ReadKey(true);
                            if (k.Key == ConsoleKey.Enter)
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    Peep.WearI[i] = 0;
                                }
                                Peep.HitPoints = Peep.maxHitPoints = 40;
                                Peep.AddHitpoints = 16;
                                Peep.tilesTraveled = 100;
                                Peep.defPoints = 5;
                                Peep.intPoints = 4;
                                Peep.accPoints = 10;
                                Peep.attackPoints = 7;
                                Peep.InventorySpace = 0;
                                Peep.Class = 9;
                                Peep.upgPoints = 0;
                                Peep.className = "Cheat";
                                Peep.goldAmount = 50;
                                Peep.xpAmount = 0;
                                Peep.maxXpAmount = 35;
                                Peep.Level = 1;
                                WasInShop = 0;
                                for (int i = 0; i < 20; i++)
                                {
                                    LevelUp();
                                }
                                Console.Clear();
                                Console.WriteLine("Happy Hacking!");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                                Game();
                            }
                            else
                            {
                                Console.Clear();
                                ClassSelection();
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        ClassSelection();
                    }
                }
        }
        public static void LevelUp()
        {
            double total = 0;
            Peep.upgPoints = Peep.upgPoints + 4;
            Peep.Level = Peep.Level + 1;
            for (int x = 1; x < Peep.Level; x++)
            {
                total += Math.Floor(x + 300 * Math.Pow(2, x / 7));
            }
            Peep.maxXpAmount = Math.Floor(total / 4);
            if(Convert.ToBoolean(Peep.Level % 4 == 0))
            {
                Peep.AddHitpoints = Peep.AddHitpoints + 4;
            }
            Peep.HitPoints = Peep.HitPoints + Peep.AddHitpoints;
            Peep.maxHitPoints = Peep.HitPoints;
            Peep.xpAmount = 0;
        }
        public static void BadGuyInAttack()
        {
            if (Peep.HitPoints > 0)
            {
                Console.Clear();
                Console.WriteLine($"{BadGuy.EnemyName}'s HP: {BadGuy.EnemyHP}/{BadGuy.EnemyMaxHP} Your HP: {Peep.HitPoints}/{Peep.maxHitPoints}");
                Console.WriteLine("----------------------------");
                Console.WriteLine($"Press 1 For strong attack.");
                Console.WriteLine($"Press 2 For normal attack.");
                Console.WriteLine($"Press 3 to try to block attack.");
                Console.WriteLine("----------------------------");
            }
            else LoseEncounter();

        }
        public static void EnemyProperties(double HP, double MaxHP, double ATT, double DEF, double VAL, string NAME)
        {
                double randomFactor = GetRandomNumber(0.75, 1);
                BadGuy.EnemyMaxHP = BadGuy.EnemyHP = Math.Round(HP * randomFactor * Math.Pow(Peep.Level, 0.7));
                BadGuy.EnemyATT = ATT * Math.Pow(Peep.Level, 0.41);
                BadGuy.EnemyDEF = DEF * Math.Pow(Peep.Level, 0.41);
                BadGuy.EnemyValue = VAL * Math.Pow(Peep.Level, 1.25);
                BadGuy.EnemyName = NAME;
        }
        public static void AttackPhase()
        {
            while (BadGuy.EnemyHP > 0)
            {
                BadGuyInAttack();
                var k = Console.ReadKey(true);
                if (Peep.HitPoints > 0)
                {

                    if (k.Key == ConsoleKey.NumPad1 || k.Key == ConsoleKey.NumPad2 || k.Key == ConsoleKey.NumPad3 || k.Key == ConsoleKey.D1 || k.Key == ConsoleKey.D2 || k.Key == ConsoleKey.D3)
                    {
                        if (k.Key == ConsoleKey.NumPad1 || k.Key == ConsoleKey.D1)
                        {
                            StrongAttack();
                        }
                        if (k.Key == ConsoleKey.NumPad2 || k.Key == ConsoleKey.D2)
                        {
                            NormalAttack();
                        }
                        if (k.Key == ConsoleKey.NumPad3 || k.Key == ConsoleKey.D3)
                        {
                            Block();
                        }
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
                else LoseEncounter();
            }
            if (Peep.HitPoints > 0)
            {
                WinEncounter();
            }
            else LoseEncounter();
        }
        public static void Encounter()
        {
            Console.WriteLine("You encountered an enemy!");
            System.Threading.Thread.Sleep(500);
            Console.Clear();
            double randomEncounter = rnd.NextDouble();
            while(true)
            {
                if (Peep.Level < 10)
                {
                    if (randomEncounter < 0.34)
                    {
                        EnemyProperties(20, 20, 5, 2, 2, "Goblin");
                        AttackPhase();
                    }
                    if (randomEncounter > 0.33 && randomEncounter < 0.67)
                    {
                        EnemyProperties(10, 10, 7, 3, 3, "Imp");
                        AttackPhase();
                    }
                    if (randomEncounter > 0.66)
                    {
                        EnemyProperties(15, 15, 3, 6, 2, "Bear");
                        AttackPhase();
                    }
                }
                else
                {
                    if (randomEncounter < 0.34)
                    {
                        EnemyProperties(35, 35, 8, 4, 5, "Lizardman");
                        AttackPhase();
                    }
                    if (randomEncounter > 0.33 && randomEncounter < 0.67)
                    {
                        EnemyProperties(20, 20, 12, 2, 6, "Teahawk");
                        AttackPhase();
                    }
                    if (randomEncounter > 0.66)
                    {
                        EnemyProperties(45, 45, 6, 10, 7, "Tortoid");
                        AttackPhase();
                    }
                }
            }
        }
        public static void StrongAttack()
        {
            double Chance = rnd.NextDouble();
            if(Chance > 0.69)
            {
            double StrongHit = Math.Truncate(Peep.attackPoints * GetRandomNumber(1.3, 1.5));
            int RandomStrongHit = rnd.Next(Convert.ToInt32(StrongHit) - 3, Convert.ToInt32(StrongHit));
            int RandomEHit = rnd.Next(0, Convert.ToInt32(BadGuy.EnemyATT));
                if(RandomEHit < BadGuy.EnemyATT  * 0.2)
                {
                    Console.WriteLine($"{BadGuy.EnemyName} missed;");
                }
                else Console.WriteLine($"{BadGuy.EnemyName} deal {RandomEHit} damage;");
            Console.WriteLine($"You deal {RandomStrongHit} damage to {BadGuy.EnemyName}.");
            Console.WriteLine($"----------------------------");
            BadGuy.EnemyHP = BadGuy.EnemyHP - RandomStrongHit;
            Peep.HitPoints = Peep.HitPoints - RandomEHit;
            System.Threading.Thread.Sleep(1000);
            }
            else
            {
                int RandomEHit = rnd.Next(0, Convert.ToInt32(BadGuy.EnemyATT));
                if (RandomEHit == 0)
                {
                    Console.WriteLine($"{BadGuy.EnemyName} missed;");
                }
                else Console.WriteLine($"{BadGuy.EnemyName} deal {RandomEHit} damage;");
                Console.WriteLine($"You missed.");
                Console.WriteLine($"----------------------------");
                Peep.HitPoints = Peep.HitPoints - RandomEHit;
                System.Threading.Thread.Sleep(1000);
            }
        }
        public static void NormalAttack()
        {
            double Chance = rnd.NextDouble();
            if (Chance > 0.15)
            {
                int RandomHit = Convert.ToInt32(Peep.attackPoints * GetRandomNumber(0.95, 1.05));
                int RandomEHit = rnd.Next(0, Convert.ToInt32(BadGuy.EnemyATT));
                if (RandomEHit < BadGuy.EnemyATT * 0.2)
                {
                    Console.WriteLine($"{BadGuy.EnemyName} missed;");
                }
                else Console.WriteLine($"{BadGuy.EnemyName} deal {RandomEHit} damage;");
                Console.WriteLine($"You deal {RandomHit} damage to {BadGuy.EnemyName}.");
                Console.WriteLine($"----------------------------");
                BadGuy.EnemyHP = BadGuy.EnemyHP - RandomHit;
                Peep.HitPoints = Peep.HitPoints - RandomEHit;
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                int RandomEHit = rnd.Next(0, Convert.ToInt32(BadGuy.EnemyATT));
                if (RandomEHit < BadGuy.EnemyATT * 0.2)
                {
                    Console.WriteLine($"{BadGuy.EnemyName} missed;");
                }
                else Console.WriteLine($"{BadGuy.EnemyName} deal {RandomEHit} damage;");
                Console.WriteLine($"You missed.");
                Console.WriteLine($"----------------------------");
                Peep.HitPoints = Peep.HitPoints - RandomEHit;
                System.Threading.Thread.Sleep(1000);
            }
        }
        public static void Block()
        {
            int RandomEHit = rnd.Next(1, Convert.ToInt32(BadGuy.EnemyATT) + 1);
            double ChanceToBlock = rnd.NextDouble();
            if (Peep.defPoints > RandomEHit)
            {
                if (ChanceToBlock > 0.2)
                {
                    int HitAfterBlock = Peep.defPoints - RandomEHit;
                    Console.WriteLine("You succesfully blocked an attack.");
                    double ChanceToHitAfterBlock = rnd.NextDouble();
                    if (ChanceToHitAfterBlock > 0.8)
                    {
                        if (HitAfterBlock > 0)
                        {
                            BadGuy.EnemyHP = BadGuy.EnemyHP - HitAfterBlock;
                            Console.WriteLine($"And you hit back {BadGuy.EnemyName} for {HitAfterBlock} damage.");
                        }
                    }
                    Console.WriteLine($"----------------------------");
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    if (RandomEHit < BadGuy.EnemyATT * 0.2)
                    {

                        Console.WriteLine($"You failed to block but {BadGuy.EnemyName} missed;");
                        Console.WriteLine($"----------------------------");
                        System.Threading.Thread.Sleep(1000);
                    }
                    else
                    {
                        Peep.HitPoints = Peep.HitPoints - RandomEHit;
                        Console.WriteLine($"You failed to block and {BadGuy.EnemyName} deal {RandomEHit} damage;");
                        Console.WriteLine($"----------------------------");
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            else
            {
                if (RandomEHit == 0)
                {
                    Console.WriteLine($"You failed to block but {BadGuy.EnemyName} missed;");
                    Console.WriteLine($"----------------------------");
                    System.Threading.Thread.Sleep(660);
                }
                else
                {
                    Peep.HitPoints = Peep.HitPoints - RandomEHit;
                    Console.WriteLine($"You failed to block and {BadGuy.EnemyName} deal {RandomEHit} damage;");
                    Console.WriteLine($"----------------------------");
                    System.Threading.Thread.Sleep(660);
                }
            }
        }
        public static void LoseEncounter()
        {
            Console.Clear();
            Console.WriteLine("You died.");
            Console.WriteLine($"You travelled {Peep.tilesTraveled} tiles in total.");
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey(true);
            Console.Clear();
            Menu();
        }
        public static void GoldToGain()
        {
            int GainedGold = rnd.Next(Convert.ToInt32(BadGuy.EnemyValue), Convert.ToInt32(BadGuy.EnemyValue + 3));
            Peep.goldAmount = Peep.goldAmount + GainedGold;
            Console.WriteLine($"You got {GainedGold} gold pieces.");
        }
        public static void MimicEncounter()
        {
            Console.Clear();
            Peep.MimicFight = 1;
            Console.WriteLine($"----------------------------");
            Console.WriteLine($"After defeating your foe you see a small passage and you find chest at the end of it.");
            Console.WriteLine($"From further inspection you realise that this chest can be 50% mimic");
            Console.WriteLine("You decide to do:");
            Console.WriteLine($"Press 1 to try to open it \nPress 2 to skip continue on path");
            Console.WriteLine($"----------------------------");
            var k = Console.ReadKey(true);
            while (true)
            {
                if (k.Key == ConsoleKey.NumPad1 || k.Key == ConsoleKey.D1 || k.Key == ConsoleKey.NumPad2 || k.Key == ConsoleKey.D2)
                {
                    if (k.Key == ConsoleKey.NumPad1 || k.Key == ConsoleKey.D1)
                    {
                        double RandomChance = rnd.NextDouble();
                        if (RandomChance > 0.494)
                        {
                            Console.WriteLine("When you try open chest it appears that it is a mimic.");
                            System.Threading.Thread.Sleep(1000);
                            EnemyProperties(50, 50, 10, 10, 50, "Mimic");
                            AttackPhase();

                        }
                        else
                        {
                            double GoldPieces = Math.Round(rnd.Next(50, 100) * Peep.Level * 1.2);
                            Peep.goldAmount = Peep.goldAmount + Convert.ToInt32(GoldPieces);
                            Console.WriteLine($"You were lucky and got {GoldPieces} for reward.");
                            Console.WriteLine($"Press any key to continue.");
                            Console.ReadKey(true);
                            Console.Clear();
                            Game();
                        }
                    }
                    else if (k.Key == ConsoleKey.NumPad2 || k.Key == ConsoleKey.D2)
                    {
                        int GainedGold = rnd.Next(Convert.ToInt32(BadGuy.EnemyValue), Convert.ToInt32(BadGuy.EnemyValue + 3)) + rnd.Next(Convert.ToInt32(BadGuy.EnemyValue) + 10, Convert.ToInt32(BadGuy.EnemyValue + 3) + 10);
                        Console.WriteLine("You decide to not take a chance and come back the way you went.");
                        Console.WriteLine("While picking up gold pieces from fight you found out you got more then you expected!");
                        Console.WriteLine($"You find {GainedGold} gold pieces in total.");
                        Peep.goldAmount = Peep.goldAmount + GainedGold;
                        Console.WriteLine($"Press any key to continue.");
                        Console.ReadKey(true);
                        Console.Clear();
                        Game();
                        break;

                    }
                }
                else MimicEncounter();
            }
        }
        public static void WinEncounter()
        {

            double GainedExp = Math.Round(0.6 * Math.Pow(Peep.Level, GetRandomNumber(1.8, 1.9)));
            if (GainedExp == 0)
            {
                GainedExp = 2;
            }
            if (GainedExp == 1)
            {
                GainedExp = 3;
            }
            Console.WriteLine($"You won and you gained {GainedExp} Exp.");
            Peep.xpAmount = Peep.xpAmount + GainedExp;
            while (Peep.xpAmount >= Peep.maxXpAmount)
            {
                LevelUp();
            }
            double GoldChance = GetRandomNumber(0, rnd.NextDouble() * Math.Pow(Peep.Level, 0.005));
            if (Peep.MimicFight == 0)
            {
                if (GoldChance < 0.95)
                {
                    GoldToGain();
                }
                else
                {
                    MimicEncounter();
                }
            }
            else GoldToGain();
            Peep.MimicFight = 0;
            Console.WriteLine($"Press any key to continue.");
            Console.ReadKey(true);
            Console.Clear();
            Game();
        }
        public static void HealTime()
        {
            if (Peep.EqualDices == 1)
            {
                if (Peep.HitPoints < Peep.maxHitPoints)
                {
                    Peep.HitPoints = Peep.HitPoints + Convert.ToInt32(Peep.intPoints);
                    Console.WriteLine($"You rolled equal dices and healed for {Peep.intPoints}");
                    System.Threading.Thread.Sleep(400);
                    Peep.EqualDices = 0;
                }
            }
            else
            {
                if (Peep.HitPoints < Peep.maxHitPoints)
                {
                    Peep.HitPoints = Peep.HitPoints + Convert.ToInt32(Peep.intPoints / 2);
                    Console.WriteLine($"You didn't encountered anything and healed for {Convert.ToInt32(Peep.intPoints / 2)}");
                    System.Threading.Thread.Sleep(400);
                }
            }
            if (Peep.HitPoints > Peep.maxHitPoints)
            {
                Peep.HitPoints = Peep.maxHitPoints;
            }
        }
        public static void FinalBoss()
        {
            Console.WriteLine("Welcome to the final boss fight");
            Console.ReadKey(true);
        }
        public static void BuyItem()
        {
            if (Peep.goldAmount >= Peep.ItemPrice[Peep.SelectedShop])
            {
                if (Peep.InventorySpace < Peep.MaxInventorySpace)
                {
                    itemID = Peep.ItemsIShop[Peep.SelectedShop];
                    Additem();
                    Peep.goldAmount = Peep.goldAmount - Peep.ItemPrice[Peep.SelectedShop];
                    for (int i = Peep.SelectedShop; i < ShopItemCount; i++)
                    {
                        Peep.ItemsIShop[i] = Peep.ItemsIShop[i + 1];
                    }
                    ShopItemCount--;
                    if (Peep.SelectedShop > ShopItemCount - 1)
                    {
                        Peep.SelectedShop = ShopItemCount - 1;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You can't buy this item because inventory is full.");
                    System.Threading.Thread.Sleep(400);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You don't have enough money");
                System.Threading.Thread.Sleep(400);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public static void Shop()
        {
            if (WasInShop == 0)
            {
                ShopItemsID.Clear();
                ShopItemCount = rnd.Next(2, 5);
                for (int i = 0; i < ShopItemCount; i++)
                {
                    int rndnmb = rnd.Next(1, 8);
                    if (ShopItemsID.Contains(rndnmb))
                    {
                        rndnmb = rnd.Next(1, 8);
                        ShopItemsID.Add(rndnmb);
                    }
                    else ShopItemsID.Add(rndnmb);
                    //Peep.ItemsIShop[i] = rnd.Next(1, 8);
                }
                ShopItemsID.CopyTo(Peep.ItemsIShop);
            }
            Peep.SelectedShop = 0;
            while (true)
            {
                WasInShop = 1;
                WasInShopName = 1;
                Console.Clear();
                Console.WriteLine("***SHOP***");
                if (Peep.goldAmount > 0)
                {
                    Console.Write($"You have ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{Peep.goldAmount}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(" gold pieces");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("What are you even doing in shop with no gold. LEAVE IMMEDIATELY!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                if (ShopItemCount > 0)
                    Console.WriteLine($"You selected [{Peep.SelectedShop + 1}] item");
                Console.WriteLine($"----------------------------");
                if (ShopItemCount == 0)
                {
                    Console.WriteLine($"Shop is closed due to lack of items.");
                }
                else ListOfItems(ShopItemCount, Peep.ItemsIShop, Peep.ShopItemName, Peep.ShopItemType, Peep.SelectedShop);

                Console.WriteLine($"----------------------------");
                if (ShopItemCount > 0)
                    Console.WriteLine("Press Enter to buy selected item");
                Console.WriteLine("Press Escape to exit.");
                var k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Game();
                }
                if (ShopItemCount > 0)
                {
                    if (k.Key == ConsoleKey.Enter)
                    {
                        BuyItem();
                    }
                }
                if (k.Key == ConsoleKey.UpArrow)
                {
                    if (Peep.SelectedShop > 0)
                    {
                        Peep.SelectedShop--;
                    }
                    else Peep.SelectedShop = ShopItemCount - 1;

                }
                if (k.Key == ConsoleKey.DownArrow)
                {
                    if (Peep.SelectedShop + 1 < ShopItemCount)
                    {
                        Peep.SelectedShop++;
                    }
                    else Peep.SelectedShop = 0;
                }
            }
        }
        public static void LvlUpMenu()
        {
            while(Peep.upgPoints > 0)
            {
                Console.Clear();
                Console.WriteLine("LEVEL UP MENU.");
                if(Peep.upgPoints > 1)
                Console.WriteLine($"You have {Peep.upgPoints} upgrade points to spend");
                else Console.WriteLine($"You have {Peep.upgPoints} upgrade point to spend");
                Console.WriteLine($"----------------------------");
                Console.WriteLine($"Press 1 to spend point on Intelligence. Your INT : {Peep.intPoints}");
                Console.WriteLine($"Press 2 to spend point on Attack. Your ATT : {Peep.attackPoints}");
                Console.WriteLine($"Press 3 to spend point on Defence.Your DEF : {Peep.defPoints}");
                Console.WriteLine($"----------------------------");
                Console.WriteLine("Press Escape to exit.");
                var k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Game();
                }
                if(k.Key == ConsoleKey.NumPad1 || k.Key == ConsoleKey.NumPad2 || k.Key == ConsoleKey.NumPad3 || k.Key == ConsoleKey.D1 || k.Key == ConsoleKey.D2 || k.Key == ConsoleKey.D3)
                {
                    if(k.Key == ConsoleKey.NumPad1 || k.Key == ConsoleKey.D1)
                    {
                        Peep.intPoints++;
                        Peep.upgPoints--;
                        LvlUpMenu();
                    }
                    if (k.Key == ConsoleKey.NumPad2 || k.Key == ConsoleKey.D2)
                    {
                        Peep.attackPoints++;
                        Peep.upgPoints--;
                        LvlUpMenu();
                    }
                    if (k.Key == ConsoleKey.NumPad3 || k.Key == ConsoleKey.D3)
                    {
                        Peep.defPoints++;
                        Peep.upgPoints--;
                        LvlUpMenu();
                    }
                }
            }
        }
        public static void Additem()
        {
            if (Peep.InventorySpace < Peep.MaxInventorySpace)
            {
                Peep.ItemN[Peep.InventorySpace] = itemID;
                Peep.InventorySpace++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Inventory is full");
                System.Threading.Thread.Sleep(400);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public static void RemoveItem()
        {
            for(int i = Peep.SelectedItem; i < Peep.InventorySpace - 1; i++)
            {
                Peep.ItemN[i] = Peep.ItemN[i + 1];
            }
            Peep.InventorySpace--;
            if (Peep.SelectedItem > Peep.InventorySpace - 1)
            {
                Peep.SelectedItem = Peep.InventorySpace - 1;
            }
            if (Peep.SelectedItem == -1)
            {
                Peep.SelectedItem = 0;
            }
        }
        public static void ListOfItems(int TheAmountOfItems, int[] ItemIDs, string[] ItemName, int[] ItemType, int Selected)
        {
            for (int i = 0; i < TheAmountOfItems; i++)
            {
                if (ItemIDs[i] == 0)
                {
                    Console.Write("");
                }
                else
                {
                    if(Selected == i)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write($"[{i + 1}] ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.Write($"[{i + 1}] ");
                    }
                    if (ItemIDs[i] == 1) //healing potion
                    {
                        ItemName[i] = "Healing potion";
                        ItemType[i] = 1;
                        if(WasInShop == 1)
                        {
                            Peep.ItemPrice[i] = 10;
                        }
                        Console.Write($"{ItemName[i]}");
                    }
                    if (ItemIDs[i] == 2) //intelligence book
                    {
                        ItemName[i] = "Book of INT";
                        ItemType[i] = 2;
                        if (WasInShop == 1)
                        {
                            Peep.ItemPrice[i] = 15;
                        }
                        Console.Write($"{ItemName[i]}");
                    }
                    if (ItemIDs[i] == 3) //Helm
                    {
                        ItemName[i] = "Wooden cap";
                        ItemType[i] = 3;
                        if (WasInShop == 1)
                        {
                            Peep.ItemPrice[i] = 20;
                        }
                        Console.Write($"{ItemName[i]}");
                    }
                    if (ItemIDs[i] == 4) //Body
                    {
                        ItemName[i] = "Wooden trunk";
                        ItemType[i] = 4;
                        if (WasInShop == 1)
                        {
                            Peep.ItemPrice[i] = 30;
                        }
                        Console.Write($"{ItemName[i]}");
                    }
                    if (ItemIDs[i] == 5) //Legs
                    {
                        ItemName[i] = "Wooden legs";
                        ItemType[i] = 5;
                        if (WasInShop == 1)
                        {
                            Peep.ItemPrice[i] = 25;
                        }
                        Console.Write($"{ItemName[i]}");
                    }
                    if (ItemIDs[i] == 6) //Shield
                    {
                        ItemName[i] = "Wooden shield";
                        ItemType[i] = 6;
                        if (WasInShop == 1)
                        {
                            Peep.ItemPrice[i] = 20;
                        }
                        Console.Write($"{ItemName[i]}");
                    }
                    if (ItemIDs[i] == 7) //Weapon
                    {
                        ItemName[i] = "Wooden sword";
                        ItemType[i] = 7;
                        if (WasInShop == 1)
                        {
                            Peep.ItemPrice[i] = 20;
                        }
                        Console.Write($"{ItemName[i]}");
                    }
                }
                if (WasInShopName == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($" [{Peep.ItemPrice[i]}]");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else Console.WriteLine("");
            }
        }
        public static void HealingPotion()
        {
            if (Peep.HitPoints < Peep.maxHitPoints)
            {
                Peep.HitPoints = Peep.HitPoints + 20;
                if (Peep.HitPoints > Peep.maxHitPoints)
                {
                    Peep.HitPoints = Peep.maxHitPoints;
                }
                RemoveItem();
                Inventory();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your HP is full.");
                System.Threading.Thread.Sleep(400);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public static void IntelligenceBook()
        {
            int IntGainz = rnd.Next(2, 6);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"You got {IntGainz} intelligence points.");
            System.Threading.Thread.Sleep(400);
            Console.ForegroundColor = ConsoleColor.Gray;
            Peep.intPoints = Peep.intPoints + IntGainz;
            RemoveItem();
            Inventory();
        }
        public static void EquipHelm()
        {
            if (Peep.WearI[0] == 0)
            {
                if(Peep.ItemName[Peep.SelectedItem] == "Wooden cap")
                {
                    Peep.WearName[0] = "Wooden cap";
                    Peep.defPoints = Peep.defPoints + 3;
                }
                Peep.WearI[0] = 1;
                RemoveItem();
                Inventory();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You already have shield equiped");
                System.Threading.Thread.Sleep(400);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public static void EquipBody()
        {
            if (Peep.WearI[1] == 0)
            {
                if (Peep.ItemName[Peep.SelectedItem] == "Wooden trunk")
                {
                    Peep.WearName[1] = "Wooden trunk";
                    Peep.defPoints = Peep.defPoints + 5;
                }
                Peep.WearI[1] = 1;
                RemoveItem();
                Inventory();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You already have body equiped");
                System.Threading.Thread.Sleep(400);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public static void EquipLegs()
        {
            if (Peep.WearI[2] == 0)
            {
                if (Peep.ItemName[Peep.SelectedItem] == "Wooden legs")
                {
                    Peep.WearName[2] = "Wooden legs";
                    Peep.defPoints = Peep.defPoints + 4;
                }
                Peep.WearI[2] = 1;
                RemoveItem();
                Inventory();
            }
            else
            {
                 Console.ForegroundColor = ConsoleColor.Red;
                 Console.WriteLine("You already have legs equiped");
                 System.Threading.Thread.Sleep(400);
                 Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public static void EquipShield()
        {
            if (Peep.WearI[3] == 0)
            {
                if (Peep.ItemName[Peep.SelectedItem] == "Wooden shield")
                {
                    Peep.WearName[3] = "Wooden shield";
                    Peep.defPoints = Peep.defPoints + 4;
                }
                Peep.WearI[3] = 1;
                RemoveItem();
                Inventory();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You already have shield equiped");
                System.Threading.Thread.Sleep(400);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public static void EquipWeapon()
        {
            if (Peep.WearI[4] == 0)
            {
                if (Peep.ItemName[Peep.SelectedItem] == "Wooden sword")
                {
                    Peep.WearName[4] = "Wooden sword";
                    Peep.attackPoints = Peep.attackPoints + 5;
                }
                Peep.WearI[4] = 1;
                RemoveItem();
                Inventory();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You already have weapon equiped");
                System.Threading.Thread.Sleep(400);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public static void ISelected()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"You selected {Peep.ItemName[Peep.SelectedItem]}");
                if(Peep.ItemN[Peep.SelectedItem] == 1)
                {
                    Console.WriteLine($"{Peep.ItemName[Peep.SelectedItem]} heals for 20 HP.");
                    Console.WriteLine("It's one time use item.");
                }
                else if(Peep.ItemN[Peep.SelectedItem] == 2)
                {
                    Console.WriteLine($"{Peep.ItemName[Peep.SelectedItem]} gives random amount of permanent Intelligence points");
                    Console.WriteLine("It's one time use item.");
                }
                else if (Peep.ItemN[Peep.SelectedItem] > 2 && Peep.ItemN[Peep.SelectedItem] < 7)
                {
                    Console.WriteLine($"{Peep.ItemName[Peep.SelectedItem]} is made out of wooden material and doesn't seem very sturdy");
                    Console.WriteLine($"It gives you some defence points if you wear it.");
                }
                else if (Peep.ItemN[Peep.SelectedItem] == 7)
                {
                    Console.WriteLine($"{Peep.ItemName[Peep.SelectedItem]} is made out of wooden material and doesn't seem very sturdy");
                    Console.WriteLine($"It gives you some attack points if you wear it.");
                }
                Console.WriteLine($"----------------------------");
                if (Peep.ItemType[Peep.SelectedItem] == 1 || Peep.ItemType[Peep.SelectedItem] == 2)
                {
                    Console.WriteLine($"Press Enter to use item");
                }
                else if (Peep.ItemType[Peep.SelectedItem] > 2 || Peep.ItemType[Peep.SelectedItem] < 8)
                {
                    Console.WriteLine($"Press Enter to equip item");
                }
                Console.WriteLine($"Press Escape to go back to inventory");
                var k = Console.ReadKey();
                if(k.Key == ConsoleKey.Escape)
                {
                    Inventory();
                }
                if (k.Key == ConsoleKey.Enter)
                {
                    if(Peep.ItemN[Peep.SelectedItem] == 1)
                    {
                        HealingPotion();
                    }
                    else if (Peep.ItemN[Peep.SelectedItem] == 2)
                    {
                        IntelligenceBook();
                    }
                    else if (Peep.ItemN[Peep.SelectedItem] == 3)
                    {
                        EquipHelm();
                    }
                    else if (Peep.ItemN[Peep.SelectedItem] == 4)
                    {
                        EquipBody();
                    }
                    else if (Peep.ItemN[Peep.SelectedItem] == 5)
                    {
                        EquipLegs();
                    }
                    else if (Peep.ItemN[Peep.SelectedItem] == 6)
                    {
                        EquipShield();
                    }
                    else if (Peep.ItemN[Peep.SelectedItem] == 7)
                    {
                        EquipWeapon();
                    }
                    else
                    {
                        RemoveItem();
                        Inventory();
                    }
                }
            }
        }
        public static void Unequip()
        {
            if (Peep.InventorySpace <= Peep.MaxInventorySpace)
            {
                if (Peep.WearI[Peep.SelectedWear] == 1)
                {
                    if (Peep.WearName[Peep.SelectedWear] == "Wooden cap")
                    {
                        Peep.defPoints = Peep.defPoints - 3;
                        Peep.WearI[0] = 0;
                        itemID = 3;
                        Additem();
                    }
                    else if (Peep.WearName[Peep.SelectedWear] == "Wooden trunk")
                    {
                        Peep.defPoints = Peep.defPoints - 5;
                        Peep.WearI[1] = 0;
                        itemID = 4;
                        Additem();
                    }
                    else if (Peep.WearName[Peep.SelectedWear] == "Wooden legs")
                    {
                        Peep.defPoints = Peep.defPoints - 4;
                        Peep.WearI[2] = 0;
                        itemID = 5;
                        Additem();
                    }
                    else if (Peep.WearName[Peep.SelectedWear] == "Wooden shield")
                    {
                        Peep.defPoints = Peep.defPoints - 1;
                        Peep.WearI[3] = 0;
                        itemID = 6;
                        Additem();
                    }
                    else if (Peep.WearName[Peep.SelectedWear] == "Wooden sword")
                    {
                        Peep.attackPoints = Peep.attackPoints - 5;
                        Peep.WearI[4] = 0;
                        itemID = 7;
                        Additem();
                    }
                }
            }
        }
        public static void SellItem()
        {
            while (true)
            {
                Console.Clear();
                Console.Write($"Do you really want to sell [{Peep.ItemName[Peep.SelectedItem]}] for");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" {Convert.ToInt32(Peep.ItemPrice[Peep.SelectedItem]*0.75)}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($" gold pieces");
                Console.WriteLine($"----------------------------");
                Console.WriteLine("Press Enter to sell");
                Console.WriteLine("Press Escape to return to inventory");
                var k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.Enter)
                {
                    Peep.goldAmount = Peep.goldAmount + Convert.ToInt32(Peep.ItemPrice[Peep.SelectedItem] * 0.75);
                    RemoveItem();
                    Inventory();
                }
                if (k.Key == ConsoleKey.Escape)
                {
                    Inventory();
                }
            }
        }
        public static void Gear()
        {
            Peep.SelectedWear = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{Peep.Name}'s gear");
                Console.WriteLine($"You selected [{Peep.Wearable[Peep.SelectedWear]}]");
                Console.WriteLine($"----------------------------");
                for(int i = 0; i < 5; i++)
                {
                    if(Peep.SelectedWear == i)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write($"{Peep.Wearable[i]}: ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else Console.Write($"{Peep.Wearable[i]}: ");
                    if(Peep.WearI[i] == 0)
                    {
                        Console.WriteLine("Nothing");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{Peep.WearName[i]}");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                Console.WriteLine($"----------------------------");
                Console.WriteLine("Press Enter to unequip gear");
                Console.WriteLine("Press Escape to go back to Inventory");
                var k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.Enter)
                {
                    if(Peep.WearI[Peep.SelectedWear] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("There is nothing to unequip");
                        System.Threading.Thread.Sleep(400);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if(Peep.InventorySpace < Peep.MaxInventorySpace)
                    {
                        Unequip();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your inventory is full");
                        System.Threading.Thread.Sleep(400);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                if (k.Key == ConsoleKey.UpArrow)
                {
                    if (Peep.SelectedWear > 0)
                    {
                        Peep.SelectedWear--;
                    }
                    else Peep.SelectedWear = 4;
                }
                if (k.Key == ConsoleKey.DownArrow)
                {
                    if (Peep.SelectedWear < 4)
                    {
                        Peep.SelectedWear++;
                    }
                    else Peep.SelectedWear = 0;
                }
                if (k.Key == ConsoleKey.Escape)
                {
                    Inventory();
                }
            }
        }
        public static void Inventory()
        {
            if (Peep.tilesTraveled % 100 < 5)
            {
                WasInShop = 1;
            }
            while (true)
            {
                WasInShopName = 0;
                Console.Clear();
                Console.WriteLine($"{Peep.Name}'s inventory");
                Console.WriteLine($"Inventory space {Peep.InventorySpace}/{Peep.MaxInventorySpace}");
                if(Peep.InventorySpace > 0)
                    Console.WriteLine($"You selected [{Peep.SelectedItem + 1}] item");
                Console.WriteLine($"-----------ITEMS------------");
                if(Peep.InventorySpace == 0)
                {
                    Console.WriteLine("Empty");
                }
                else
                {
                    ListOfItems(Peep.InventorySpace, Peep.ItemN, Peep.ItemName, Peep.ItemType, Peep.SelectedItem);
                }
                Console.WriteLine($"----------------------------");
                if (Peep.InventorySpace > 0)
                {
                    Console.WriteLine($"Press Up or Down to select item");
                    Console.WriteLine($"Press Enter to access selected item");
                    if (WasInShop == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Press S to sell selected item");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                Console.WriteLine("Press G to access gear menu");
                Console.WriteLine("Press Escape to exit.");
                var k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Game();
                }
                if (k.Key == ConsoleKey.G)
                {
                    Gear();
                }
                if (Peep.InventorySpace > 0)
                {
                    if (WasInShop == 1)
                    {
                        if (k.Key == ConsoleKey.S)
                        {
                            SellItem();
                        }
                    }
                }
                if (k.Key == ConsoleKey.UpArrow)
                {

                    if (Peep.SelectedItem > 0 && Peep.InventorySpace > 0)
                    {
                        Peep.SelectedItem--;
                    }
                    else Peep.SelectedItem = Peep.InventorySpace - 1;
                }
                if (k.Key == ConsoleKey.DownArrow)
                {
                    if (Peep.SelectedItem + 1 < Peep.InventorySpace)
                    {
                        Peep.SelectedItem++;
                    }
                    else Peep.SelectedItem = 0;
                }
                if (Peep.Class == 9)
                {
                    if (k.Key == ConsoleKey.Add)
                    {
                        itemID = rnd.Next(1, 8);
                        Additem();
                    }
                }
                if (k.Key == ConsoleKey.Enter)
                {
                    if (Peep.InventorySpace > 0)
                    {
                        ISelected();
                    }
                }
            } 
        }
        public static void Game()
        {
            Console.WriteLine($"----------------------------");
            Console.WriteLine($"Name: {Peep.Name}, Class: {Peep.className}");
            Console.WriteLine($"LVL: {Peep.Level} XP: {Peep.xpAmount}/{Peep.maxXpAmount}");
            Console.WriteLine($"----------------------------");
            Console.WriteLine($"HP: {Peep.HitPoints}/{Peep.maxHitPoints}");
            Console.WriteLine($"DEF: {Peep.defPoints} INT: {Peep.intPoints} ATT: {Peep.attackPoints}");
            Console.WriteLine($"Gold: {Peep.goldAmount}");
            Console.WriteLine($"Total tiles travelled: {Peep.tilesTraveled}");
            Console.WriteLine($"----------------------------");
            Console.WriteLine("Press R to roll the dice");
            Console.WriteLine("Press T to access inventory");
            Console.WriteLine("Press Escape to go to menu");
            if(Peep.Level >= 20)
            {
                Console.WriteLine("Press Q if you want to fight the Boss");
            }
            if (Peep.tilesTraveled % 100 < 5 && Peep.tilesTraveled > 5)
            {
                Console.WriteLine("Press W to access shop");
            }
            if (Peep.upgPoints > 0)
            {
                Console.WriteLine("Press E to access level up menu");
            }
            Console.WriteLine($"----------------------------");
            var k = Console.ReadKey(true);
            if(k.Key == ConsoleKey.T)
            {
                Peep.SelectedItem = 0;
                Inventory();
            }
            if (Peep.upgPoints > 0)
            {
                if(k.Key == ConsoleKey.E)
                {
                    LvlUpMenu();
                }
            }
            if (Peep.tilesTraveled % 100 < 5 && Peep.tilesTraveled > 5)
            {
                if (k.Key == ConsoleKey.W)
                {
                    Shop();
                }
            }
            if (Peep.Level >= 20)
            {
                if (k.Key == ConsoleKey.Q)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Do you really want to fight final boss?");
                        Console.WriteLine($"----------------------------");
                        Console.WriteLine($"Press 1 to fight");
                        Console.WriteLine($"Press Escape to leave");
                        k = Console.ReadKey(true);
                        if (k.Key == ConsoleKey.D1 || k.Key == ConsoleKey.Escape || k.Key == ConsoleKey.NumPad1)
                        {
                            if (k.Key == ConsoleKey.D1 || k.Key == ConsoleKey.NumPad1)
                            {
                                Console.Clear();
                                FinalBoss();
                                
                            }
                            else
                            {
                                Console.Clear();
                                Game();
                            }
                        }
                        else Console.Clear();
                    }
                }
            }
            if (k.Key == ConsoleKey.Escape)
                Menu();
            else if (k.Key == ConsoleKey.R)
            {
                Peep.firstDice = rnd.Next(1, 6);
                Peep.secondDice = rnd.Next(1, 6);
                Peep.tilesTraveled = Peep.tilesTraveled + Peep.firstDice + Peep.secondDice;
                Console.WriteLine($"You rolled rolled dice {Peep.firstDice} and {Peep.secondDice}");
                if (Peep.firstDice + Peep.secondDice > 6)
                {
                    WasInShop = 0;
                    Encounter();
                }
                else
                {
                    if(Peep.firstDice == Peep.secondDice)
                    {
                        Peep.EqualDices = 1;
                    }
                    HealTime();
                    System.Threading.Thread.Sleep(800);
                    Console.Clear();
                    Game();
                }
            }
            else
            {
                Console.Clear();
                Game();
            }
        }
        static void Main(string[] args)
        {
            SetUpGame();
            Menu();
        }
    }
}
