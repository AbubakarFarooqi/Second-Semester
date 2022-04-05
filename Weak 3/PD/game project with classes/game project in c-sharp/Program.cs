using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using EZInput;
using game_project_in_c_sharp.GL;

namespace game_project_in_c_sharp
{
    class Program
    {
        /*public struct enemy
        {
            public int x1;
            public int y1;
            public int x2;
            public int y2;
            public bool flag;
        };*/
        /* public struct enemyFire
         {
             public int x;
             public int y;
             public bool flag;
         };*/

        //.........................Functions Implementations...........................
        static void ResetFlagsAndControls(ref int EnemyMovementFlag, ref int ShipFireFlag, ref int ShipNextFireFlag, ref bool EnemyFireMovementFlag, ref int Life, ref bool isFinalEnemy, ref int Score, ref int FinalEnemyLives, ref int FireCount)
        {
            EnemyMovementFlag = 0;
            ShipFireFlag = 0;
            ShipNextFireFlag = 1;
            EnemyFireMovementFlag = true;
            isFinalEnemy = false;
            Life = 3;
            FireCount = 0;
            Score = 0;
            FinalEnemyLives = 15;
        }
        static void Header()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("///////////////////////////////////////////////"); ;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                Space Invaders                ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("//////////////////////////////////////////////");
        }
        static void GameStartingStory(int Fx, int Fy)
        {
            DisplayFinalEnemy(Fx, Fy);
            Console.WriteLine();
            StreamReader file = new StreamReader("story.txt");
            string temp;
            int line = 1;
            int character = 1;
            while ((temp = file.ReadLine()) != null)
            {

                for (int i = 0; i < temp.Length; i++)
                {
                    if (line == 1 && character >= 4 && character <= 9)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else if (line == 3 && character >= 30 && character <= 34)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (line == 5)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(temp[i]);
                    Thread.Sleep(50);
                    character++;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                line++;
                character = 1;
            }
            Console.Read();
        }
        static char Menu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("...............................................");
            Console.WriteLine("......................MENU.....................");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Play Game");
            Console.WriteLine("2. High Scores");
            Console.WriteLine("3. Load Game");
            Console.WriteLine("4. Exit");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Your Option...");
            char option;
            Char.TryParse(Console.ReadLine(), out option);
            return option;
        }
        static string Extraction_of_Specific_Field(string Source, int field)
        {
            string output = "";
            int comma = 1;
            for (int i = 0; i < Source.Length; i++)
            {

                if (comma == field)
                {
                    if (Source[i] != ',')
                        output = output + Source[i];
                }
                if (Source[i] == ',')
                    comma++;
            }

            return output;


        } // End of Extraction of SPecific Field
        static void PutDataInUserList(string name, int score, List<User> Users)
        {
            User temp = new User(name, score);
            Users.Add(temp);
        }
        static void ExtractingUserFile(List<User> UserList)
        {
            StreamReader file = new StreamReader("G:\\BSCS\\2nd Semester\\OOP\\Weak 2\\PD\\game project with classes\\game project in c-sharp\\bin\\Debug\\users.txt");
            string source;
            while ((source = file.ReadLine()) != null)
            {
                string tempName;
                int tempScore;
                tempName = Extraction_of_Specific_Field(source, 1);
                tempScore = int.Parse(Extraction_of_Specific_Field(source, 2));
                PutDataInUserList(tempName, tempScore, UserList);


            }
            file.Close();
        }
        static void PutListInUserFile(List<User> UserList)
        {
            StreamWriter file = new StreamWriter("G:\\BSCS\\2nd Semester\\OOP\\Weak 2\\PD\\game project with classes\\game project in c-sharp\\bin\\Debug\\users.txt");
            for (int i = 0; i < UserList.Count; i++)
            {
                file.WriteLine(UserList[i].Name + "," + UserList[i].Score);
            }
            file.Close();
        }

        static void ResetShipPosition(ref int S1_x, ref int S1_y, ref int S2_x, ref int S2_y, ref int S3_x, ref int S3_y)
        {
            S1_x = 11;
            S1_y = 32;
            S2_x = 12;
            S2_y = 31;
            S3_x = 13;
            S3_y = 32;

        }
        static int SearchUserNameInList(List<User> userList, string name, ref bool isfound)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].isValid(name))
                {
                    isfound = true;
                    return i;
                }
            }
            isfound = false;
            return -1;
        }
        static void ResetAllValues(enemy[] Enemies, ref int EnemyMovementFlag, ref int ShipFireFlag, ref int ShipNextFireFlag, ref bool EnemyFireMovementFlag, ref int S1_x, ref int S1_y, ref int S2_x, ref int S2_y, ref int S3_x, ref int S3_y, enemyFire[] EnemyFire)
        {
            EnemyMovementFlag = 0;
            ShipFireFlag = 0;
            ShipNextFireFlag = 1;
            EnemyFireMovementFlag = true;
            initializingEnemiesCoordinate(Enemies);
            for (int i = 0; i < 4; i++)
            {
                EnemyFire[i].ChangeFlag(false);
            }
            S1_x = 11;
            S1_y = 32;
            S2_x = 12;
            S2_y = 31;
            S3_x = 13;
            S3_y = 32;
        }
        static void LoadBorderFromFile(char[,] Border)
        {
            StreamReader file = new StreamReader("Borders.txt");
            for (int i = 0; i < 36; i++)
            {
                string temp;
                temp = file.ReadLine();
                for (int j = 0; j < 35; j++)
                {
                    Border[i, j] = temp[j];
                }
            }
        }


        static void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        static void GameOpeningScreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t\t\t\t\tPlay");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t\t   S");
            Thread.Sleep(150);
            Console.Write("p");
            Thread.Sleep(150);
            Console.Write("a");
            Thread.Sleep(150);
            Console.Write("c");
            Thread.Sleep(150);
            Console.Write("e");
            Console.Write("  ");
            Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("I");
            Thread.Sleep(150);
            Console.Write("n");
            Thread.Sleep(150);
            Console.Write("v");
            Thread.Sleep(150);
            Console.Write("a");
            Thread.Sleep(150);
            Console.Write("d");
            Thread.Sleep(150);
            Console.Write("e");
            Thread.Sleep(150);
            Console.Write("r");
            Thread.Sleep(150);
            Console.Write("s");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t\t\t\t< Score Advance Table >");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t\t\t\t\t++ = ");
            Console.WriteLine("\t\t\t\t\t\t\t\t-- = ");
            Console.WriteLine("\t\t\t\t\t\t\t\t** = ");
            Console.WriteLine("\t\t\t\t\t\t\t\t() = "); ;
            gotoxy(70, 6);
            Console.Write("1");
            Thread.Sleep(250);
            Console.Write("0");
            gotoxy(70, 7);
            Console.Write("2");
            Thread.Sleep(250);
            Console.Write("0");
            gotoxy(70, 8);
            Console.Write("3");
            Thread.Sleep(250);
            Console.Write("0");
            gotoxy(70, 9);
            Console.Write("4");
            Thread.Sleep(250);
            Console.Write("0");
            Thread.Sleep(300);
        }
        static void DisplayShip(ref int S1_x, ref int S1_y, ref int S2_x, ref int S2_y, ref int S3_x, ref int S3_y)
        {
            Console.ForegroundColor = ConsoleColor.White;
            gotoxy(S1_x, S1_y);
            Console.Write("<");
            gotoxy(S2_x, S2_y);
            Console.Write("^");
            gotoxy(S3_x, S3_y);
            Console.Write(">");
        }

        static void DisplayBorders(char[,] Border)
        {
            for (int i = 0; i < 36; i++)
            {
                for (int j = 0; j < 35; j++)
                {
                    Console.Write(Border[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void DisplayFinalEnemy(int Fx, int Fy)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            gotoxy(Fx, Fy);
            Console.Write("/");
            gotoxy(Fx + 1, Fy - 1);
            Console.Write("-");
            gotoxy(Fx + 2, Fy - 3);
            Console.Write("-^^^-");
            gotoxy(Fx + 2, Fy - 2);
            Console.Write("|O O|");
            gotoxy(Fx + 2, Fy - 1);
            Console.Write("| > |-");
            gotoxy(Fx + 2, Fy);
            Console.Write("| - | \\");
            gotoxy(Fx + 2, Fy + 1);
            Console.Write("-----");
        }

        static void FinalEnemyRandomMovement(ref int Fx, ref int Fy)
        {
            gotoxy(Fx, Fy);
            Console.Write(" ");
            gotoxy(Fx + 1, Fy - 1);
            Console.Write(" ");
            gotoxy(Fx + 2, Fy - 3);
            Console.Write("     ");
            gotoxy(Fx + 2, Fy - 2);
            Console.Write("     ");
            gotoxy(Fx + 2, Fy - 1);
            Console.Write("      ");
            gotoxy(Fx + 2, Fy);
            Console.Write("       ");
            gotoxy(Fx + 2, Fy + 1);
            Console.Write("     ");
            Random rnd = new Random();

            Fx = 1 + rnd.Next(25);
            Fy = 4 + rnd.Next(23);
        }


        static void ChkFinalEnemyFire(ref bool FinalEnemyFireFlag, ref int FEF_x_1, ref int FEF_y_1, ref int FEF_x_2, ref int FEF_y_2, ref int FEF_x_3, ref int FEF_y_3, ref int FEF_x_4, ref int FEF_y_4, ref bool FinalEnemyFireMovementFlag, int Fx, int Fy)
        {
            if (FinalEnemyFireFlag)
            {
                FEF_x_1 = Fx;
                FEF_y_1 = Fy + 1;
                FEF_x_2 = Fx + 2;
                FEF_y_2 = Fy + 2;
                FEF_x_3 = Fx + 6;
                FEF_y_3 = Fy + 2;
                FEF_x_4 = Fx + 8;
                FEF_y_4 = Fy + 1;
                FinalEnemyFireMovementFlag = true;
                FinalEnemyFireFlag = false;
            }
        }

        static void FinalEnemyFireMovement(ref bool FinalEnemyFireFlag, ref int FEF_x_1, ref int FEF_y_1, ref int FEF_x_2, ref int FEF_y_2, ref int FEF_x_3, ref int FEF_y_3, ref int FEF_x_4, ref int FEF_y_4, ref bool FinalEnemyFireMovementFlag, int Fx, int Fy, ref int FireCount, ref int S1_x, ref int S1_y, ref int S2_x, ref int S2_y, ref int S3_x, ref int S3_y)
        {
            if (FinalEnemyFireMovementFlag)
            {
                gotoxy(FEF_x_1, FEF_y_1);
                Console.Write(" ");
                gotoxy(FEF_x_2, FEF_y_2);
                Console.Write(" ");
                gotoxy(FEF_x_3, FEF_y_3);
                Console.Write(" ");
                gotoxy(FEF_x_4, FEF_y_4);
                Console.Write(" ");
                FEF_y_1++;
                FEF_y_2++;
                FEF_y_3++;
                FEF_y_4++;
                if (FEF_y_1 != 33)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    gotoxy(FEF_x_1, FEF_y_1);
                    Console.Write("*");
                    gotoxy(FEF_x_2, FEF_y_2);
                    Console.Write("*");
                    gotoxy(FEF_x_3, FEF_y_3);
                    Console.Write("*");
                    gotoxy(FEF_x_4, FEF_y_4);
                    Console.Write("*");
                    if ((FEF_x_1 == S1_x && FEF_y_1 == S1_y) || (FEF_x_1 == S2_x && FEF_y_1 == S2_y) || (FEF_x_1 == S3_x && FEF_y_1 == S3_y) || (FEF_x_2 == S1_x && FEF_y_2 == S1_y) || (FEF_x_2 == S2_x && FEF_y_2 == S2_y) || (FEF_x_2 == S3_x && FEF_y_2 == S3_y) || (FEF_x_3 == S1_x && FEF_y_3 == S1_y) || (FEF_x_3 == S2_x && FEF_y_3 == S2_y) || (FEF_x_3 == S3_x && FEF_y_3 == S3_y) || (FEF_x_4 == S1_x && FEF_y_4 == S1_y) || (FEF_x_4 == S2_x && FEF_y_4 == S2_y) || (FEF_x_4 == S3_x && FEF_y_4 == S3_y))
                    {
                        FireCount++;
                        gotoxy(S1_x, S1_y);
                        Console.Write(" ");
                        gotoxy(S2_x, S2_y);
                        Console.Write(" ");
                        gotoxy(S3_x, S3_y);
                        Console.Write(" ");
                        ResetShipPosition(ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y);
                    }
                }
                else
                {
                    FinalEnemyFireMovementFlag = false;
                    FinalEnemyFireFlag = true;
                }
            }
        }

        static void MovementInEnemies(enemy[] Enemies, ref int EnemyMovementFlag)
        {
            if (Enemies[5].x2 + 1 == 34)
                EnemyMovementFlag = 1;
            if (Enemies[0].x1 - 1 == 1)
                EnemyMovementFlag = 0;
            if (EnemyMovementFlag == 0)
            {
                ClearingEnemiesPreviousPositions(Enemies);
                for (int i = 0; i < 24; i++)
                {
                    Enemies[i].x1++;
                    Enemies[i].x2++;
                }
            }
            if (EnemyMovementFlag == 1)
            {
                ClearingEnemiesPreviousPositions(Enemies);
                for (int i = 0; i < 24; i++)
                {
                    Enemies[i].x1--;
                    Enemies[i].x2--;
                }
            }
        }

        static void MovementInShip(ref int S1_x, ref int S1_y, ref int S2_x, ref int S2_y, ref int S3_x, ref int S3_y)
        {
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                if (S3_x + 1 != 34)
                {
                    gotoxy(S1_x, S1_y);
                    Console.Write(" ");
                    gotoxy(S2_x, S2_y);
                    Console.Write(" ");
                    gotoxy(S3_x, S3_y);
                    Console.Write(" ");
                    S1_x++;
                    S2_x++;
                    S3_x++;
                }
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                if (S1_x - 1 != 0)
                {
                    gotoxy(S1_x, S1_y);
                    Console.Write(" ");
                    gotoxy(S2_x, S2_y);
                    Console.Write(" ");
                    gotoxy(S3_x, S3_y);
                    Console.Write(" ");
                    S1_x--;
                    S2_x--;
                    S3_x--;
                }
            }
        }


        static void ChkShipFire(ref int ShipNextFireFlag, ref int ShipFireFlag, ref int S_Fire_x, ref int S_Fire_y, ref int S2_x, ref int S2_y)
        {
            if (ShipNextFireFlag == 1)
            {
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    ShipFireFlag = 1;
                    S_Fire_x = S2_x;
                    S_Fire_y = S2_y - 1;
                    ShipNextFireFlag = 0;
                }
            }
        }


        static int ShipFireMovement(ref bool isFinalEnemy, ref int FinalEnemyLives, ref int Fx, ref int Fy, ref int Score, ref int ShipNextFireFlag, ref int ShipFireFlag, ref int S_Fire_x, ref int S_Fire_y, enemy[] Enemies)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (ShipFireFlag == 1)
            {
                for (int i = 0; i < 24; i++)
                {
                    if (((S_Fire_x == Enemies[i].x1 && S_Fire_y == Enemies[i].y1) || (S_Fire_x == Enemies[i].x2 && S_Fire_y == Enemies[i].y2)) && Enemies[i].flag)
                    {
                        ShipFireFlag = 0;
                        ShipNextFireFlag = 1;
                        gotoxy(S_Fire_x, S_Fire_y);
                        Console.Write(" ");
                        gotoxy(S_Fire_x + 1, S_Fire_y);
                        Console.Write(" ");
                        gotoxy(S_Fire_x - 1, S_Fire_y);
                        Console.Write(" ");
                        Enemies[i].flag = false;
                        if (i >= 0 && i < 6)
                            Score = Score + 40;
                        if (i >= 6 && i < 12)
                            Score = Score + 30;
                        if (i >= 12 && i < 18)
                            Score = Score + 20;
                        if (i >= 18 && i < 24)
                            Score = Score + 10;
                        return 0;
                    }
                }
                if (((S_Fire_x == Fx && S_Fire_y == Fy) || (S_Fire_x == Fx + 1 && S_Fire_y == Fy - 1) || ((S_Fire_x >= Fx + 2 && S_Fire_x <= Fx + 6) && S_Fire_y == Fy + 1) || (S_Fire_x == Fx + 7 && S_Fire_y == Fy - 1) || (S_Fire_x == Fx + 8 && S_Fire_y == Fy)) && isFinalEnemy)
                {
                    ShipFireFlag = 0;
                    ShipNextFireFlag = 1;
                    gotoxy(S_Fire_x, S_Fire_y);
                    Console.Write(" ");
                    Score = Score + 50;
                    FinalEnemyLives--;
                }
                else if (S_Fire_y != 1)
                {
                    gotoxy(S_Fire_x, S_Fire_y);
                    Console.Write(" ");
                    S_Fire_y--;
                    gotoxy(S_Fire_x, S_Fire_y);
                    Console.Write("^");
                }
                else
                {
                    ShipFireFlag = 0;
                    ShipNextFireFlag = 1;
                    gotoxy(S_Fire_x, S_Fire_y);
                    Console.Write(" ");
                }
            }
            return 1;
        }

        static void WhichEnemyFire(int temp, enemyFire[] EnemyFire, enemy[] Enemies)
        {
            for (int i = 1; i <= 24; i++)
            {

                if (i == temp)
                {
                    if (i >= 1 && i <= 6)
                        if (!EnemyFire[0].flag)
                        {

                            EnemyFire[0].x = Enemies[i - 1].x1;
                            EnemyFire[0].y = Enemies[i - 1].y1;

                            break;
                        }
                    if (i >= 7 && i <= 12)

                        if (!EnemyFire[1].flag)
                        {
                            EnemyFire[1].x = Enemies[i - 1].x1;
                            EnemyFire[1].y = Enemies[i - 1].y1;

                            break;
                        }

                    if (i >= 13 && i <= 18)

                        if (!EnemyFire[2].flag)
                        {
                            EnemyFire[2].x = Enemies[i - 1].x1;
                            EnemyFire[2].y = Enemies[i - 1].y1;
                            break;
                        }
                    if (i >= 19 && i <= 24)
                        if (!EnemyFire[3].flag)
                        {
                            EnemyFire[3].x = Enemies[i - 1].x1;
                            EnemyFire[3].y = Enemies[i - 1].y1;
                            break;
                        }
                }
            }
        }


        static void ChkEnemyFire(enemyFire[] EnemyFire, enemy[] Enemies, ref bool EnemyFireMovementFlag)
        {
            Random rnd = new Random();
            int temp = 1 + rnd.Next(24);
            WhichEnemyFire(temp, EnemyFire, Enemies);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    if (EnemyFireMovementFlag)
                    {

                        if ((EnemyFire[i].x == Enemies[j].x1 && EnemyFire[i].y == Enemies[j].y1 && Enemies[j].flag))
                        {
                            EnemyFire[i].y++;
                            EnemyFire[i].flag = true;
                            EnemyFireMovementFlag = false;
                            i = 5;
                            break;
                        }
                    }
                }
            }
        }


        static void EnemyFireMovement(ref bool EnemyFireMovementFlag, ref int FireCount, enemyFire[] EnemyFire, ref int S1_x, ref int S1_y, ref int S2_x, ref int S2_y, ref int S3_x, ref int S3_y)
        {
            for (int i = 0; i < 4; i++)
            {

                if (EnemyFire[i].flag)
                {
                    gotoxy(EnemyFire[i].x, EnemyFire[i].y);
                    Console.Write(" ");
                    EnemyFire[i].y++;
                    if (EnemyFire[i].y != 33)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        gotoxy(EnemyFire[i].x, EnemyFire[i].y);
                        Console.Write("*");
                        if ((EnemyFire[i].x == S1_x && EnemyFire[i].y == S1_y) || (EnemyFire[i].x == S2_x && EnemyFire[i].y == S2_y) || (EnemyFire[i].x == S3_x && EnemyFire[i].y == S3_y))
                        {
                            FireCount++;
                            gotoxy(S1_x, S1_y);
                            Console.Write(" ");
                            gotoxy(S2_x, S2_y);
                            Console.Write(" ");
                            gotoxy(S3_x, S3_y);
                            Console.Write(" ");
                            ResetShipPosition(ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y);
                        }
                    }
                    else
                    {
                        EnemyFireMovementFlag = true;
                        EnemyFire[i].flag = false;
                    }
                }
            }
        }


        static void DecrementInEnemyY_Axis(ref int Score, ref int FireCount, enemy[] Enemies, char[,] Border, ref int EnemyMovementFlag, ref int ShipFireFlag, ref int ShipNextFireFlag, ref bool EnemyFireMovementFlag, ref int S1_x, ref int S1_y, ref int S2_x, ref int S2_y, ref int S3_x, ref int S3_y, enemyFire[] EnemyFire)
        {
            if (Enemies[23].y1 < 28)
            {
                for (int i = 0; i < 24; i++)
                {
                    gotoxy(Enemies[i].x1, Enemies[i].y1);
                    Console.Write(" ");
                    gotoxy(Enemies[i].x2, Enemies[i].y2);
                    Console.Write(" ");
                    Enemies[i].y1++;
                    Enemies[i].y2++;
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                DisplayBorders(Border);
                ResetAllValues(Enemies, ref EnemyMovementFlag, ref ShipFireFlag, ref ShipNextFireFlag, ref EnemyFireMovementFlag, ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y, EnemyFire);
                Score = 1200;
                FireCount = 5;
            }
        }


        static void GameLose(int Fx, int Fy)
        {
            Console.Clear();
            StreamReader file = new StreamReader("GameLose.txt");
            string temp;
            int line = 1;
            int character = 1;
            DisplayFinalEnemy(Fx, Fy);
            Console.WriteLine();
            while ((temp = file.ReadLine()) != null)
            {


                for (int i = 0; i < temp.Length; i++)
                {
                    if (line == 1 && character >= 9 && character <= 13)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (line == 3 && character >= 26 && character < 30)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(temp[i]);
                    Thread.Sleep(50);
                    character++;
                }
                line++;
                character = 0;
                Console.WriteLine();
            }
            Console.Read();
        }


        static void DisplayStatus(int FinalEnemyLives, int Score, int Life, int FireCount, bool isFinalEnemy)
        {
            gotoxy(40, 16);
            Console.Write("Score = ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Score);
            gotoxy(40, 18);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Lives = ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Life);
            gotoxy(40, 20);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Health = ");
            for (int i = 10; i >= 0; i--) // for clearing prev screen
                Console.Write(" ");
            gotoxy(49, 20);
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 5; i > FireCount; i--)
                Console.Write("|");
            if (isFinalEnemy)
            {
                gotoxy(40, 22);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ATTIC = ");
                for (int i = 1; i <= 15; i++)
                {
                    Console.Write(" ");
                }
                gotoxy(48, 22);
                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int i = 1; i <= FinalEnemyLives; i++)
                {
                    Console.Write("|");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        static void Lvl_1_OpeningScreen()
        {

            for (int i = 1; i <= 15; i++)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                if (i == 15)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                            |            ___________  \\            /  ___________   |               /|");
                Console.WriteLine("                            |           |              \\          /  |              |              / |");
                Console.WriteLine("                            |           |               \\        /   |              |             /  |");
                Console.WriteLine("                            |           |----------      \\      /    |-----------   |                |");
                Console.WriteLine("                            |           |                 \\    /     |              |                |");
                Console.WriteLine("                            |           |                  \\  /      |              |                |");
                Console.WriteLine("                            |_________  |__________         \\/       |___________   |__________   ________");
                Thread.Sleep(80);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }


        static void Lvl_2_OpeningScreen()
        {

            for (int i = 1; i <= 15; i++)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                if (i == 15)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("                            |            ___________  \\            /  ___________   |             ________");
                Console.WriteLine("                            |           |              \\          /  |              |            |        |");
                Console.WriteLine("                            |           |               \\        /   |              |                     |");
                Console.WriteLine("                            |           |----------      \\      /    |-----------   |              _______|");
                Console.WriteLine("                            |           |                 \\    /     |              |             |");
                Console.WriteLine("                            |           |                  \\  /      |              |             |");
                Console.WriteLine("                            |_________  |__________         \\/       |___________   |__________   |_______|");
                Thread.Sleep(80);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }


        static void Lvl_3_OpeningScreen()
        {

            for (int i = 1; i <= 15; i++)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                if (i == 15)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("                            |            ___________  \\            /  ___________   |             ________");
                Console.WriteLine("                            |           |              \\          /  |              |            |        |");
                Console.WriteLine("                            |           |               \\        /   |              |                     |");
                Console.WriteLine("                            |           |----------      \\      /    |-----------   |              _______|");
                Console.WriteLine("                            |           |                 \\    /     |              |                     |");
                Console.WriteLine("                            |           |                  \\  /      |              |                     |");
                Console.WriteLine("                            |_________  |__________         \\/       |___________   |__________   |_______|");
                Thread.Sleep(80);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Lvl_4_OpeningScreen()
        {

            for (int i = 1; i <= 15; i++)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                if (i == 15)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("                            |            ___________  \\            /  ___________   |                     ");
                Console.WriteLine("                            |           |              \\          /  |              |            |        |");
                Console.WriteLine("                            |           |               \\        /   |              |            |        |");
                Console.WriteLine("                            |           |----------      \\      /    |-----------   |            |________|");
                Console.WriteLine("                            |           |                 \\    /     |              |                     |");
                Console.WriteLine("                            |           |                  \\  /      |              |                     |");
                Console.WriteLine("                            |_________  |__________         \\/       |___________   |__________           |");
                Thread.Sleep(80);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Level_1(User temp, char[,] Border, ref int S1_x, ref int S1_y, ref int S2_x, ref int S2_y, ref int S3_x, ref int S3_y, enemyFire[] EnemyFire, enemy[] Enemies, ref bool EnemyFireMovementFlag, ref int FireCount, ref int ShipNextFireFlag, ref int ShipFireFlag, ref int S_Fire_x, ref int S_Fire_y, ref int Score, ref int Fx, ref int Fy, ref bool isFinalEnemy, ref int FinalEnemyLives, ref int Life)
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            DisplayBorders(Border);
            int EnemyFireControl = 10;
            int fireMove = 8;

            while (true)
            {
                // star
                gotoxy(0, 0);
                DisplayEnemies(Enemies);
                MovementInShip(ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y);

                ChkEnemyFire(EnemyFire, Enemies, ref EnemyFireMovementFlag);
                if (fireMove % 14 == 0)
                    EnemyFireMovement(ref EnemyFireMovementFlag, ref FireCount, EnemyFire, ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y);
                DisplayShip(ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y);
                ChkShipFire(ref ShipNextFireFlag, ref ShipFireFlag, ref S_Fire_x, ref S_Fire_y, ref S2_x, ref S2_y);

                fireMove++;
                ShipFireMovement(ref isFinalEnemy, ref FinalEnemyLives, ref Fx, ref Fy, ref Score, ref ShipNextFireFlag, ref ShipFireFlag, ref S_Fire_x, ref S_Fire_y, Enemies);
                DisplayStatus(FinalEnemyLives, Score, Life, FireCount, isFinalEnemy);
                if (FireCount == 5)
                {
                    Life--;
                    FireCount = 0;
                }
                if (Life == 0)
                    break;
                // Score = 600;
                if (Score == 600)
                {
                    temp.Score = 600;
                    break;
                }
            }
        }


        static void Level_2(User temp, char[,] Border, ref int S1_x, ref int S1_y, ref int S2_x, ref int S2_y, ref int S3_x, ref int S3_y, enemyFire[] EnemyFire, enemy[] Enemies, ref bool EnemyFireMovementFlag, ref int FireCount, ref int ShipNextFireFlag, ref int ShipFireFlag, ref int S_Fire_x, ref int S_Fire_y, ref int Score, ref int Fx, ref int Fy, ref bool isFinalEnemy, ref int FinalEnemyLives, ref int Life, ref int EnemyMovementFlag)
        {
            ResetAllValues(Enemies, ref EnemyMovementFlag, ref ShipFireFlag, ref ShipNextFireFlag, ref EnemyFireMovementFlag, ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y, EnemyFire);
            Console.Clear();
            int SpeedControler = 1;
            int Speed = 10;
            int fireMove = 8;


            Console.ForegroundColor = ConsoleColor.Blue;
            DisplayBorders(Border);
            while (true)
            {
                gotoxy(0, 0);
                if (SpeedControler % Speed == 0)
                    MovementInEnemies(Enemies, ref EnemyMovementFlag);
                DisplayEnemies(Enemies);
                MovementInShip(ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y);
                ChkEnemyFire(EnemyFire, Enemies, ref EnemyFireMovementFlag);
                DisplayShip(ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y);
                ChkShipFire(ref ShipNextFireFlag, ref ShipFireFlag, ref S_Fire_x, ref S_Fire_y, ref S2_x, ref S2_y);
                if (fireMove % 14 == 0)
                    EnemyFireMovement(ref EnemyFireMovementFlag, ref FireCount, EnemyFire, ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y);
                ShipFireMovement(ref isFinalEnemy, ref FinalEnemyLives, ref Fx, ref Fy, ref Score, ref ShipNextFireFlag, ref ShipFireFlag, ref S_Fire_x, ref S_Fire_y, Enemies);
                SpeedControler++;
                fireMove++;
                DisplayStatus(FinalEnemyLives, Score, Life, FireCount, isFinalEnemy);

                if (SpeedControler % 60 == 0)
                    if (Speed > 5)
                        Speed--;
                if (FireCount == 5)
                {
                    Life--;
                    FireCount = 0;
                }
                if (Life == 0)
                    break;
                // Score = 1200;
                if (Score == 1200)
                {
                    temp.Score = 1200;
                    break;
                }
            }
        }


        static void Level_3(User temp, char[,] Border, ref int S1_x, ref int S1_y, ref int S2_x, ref int S2_y, ref int S3_x, ref int S3_y, enemyFire[] EnemyFire, enemy[] Enemies, ref bool EnemyFireMovementFlag, ref int FireCount, ref int ShipNextFireFlag, ref int ShipFireFlag, ref int S_Fire_x, ref int S_Fire_y, ref int Score, ref int Fx, ref int Fy, ref bool isFinalEnemy, ref int FinalEnemyLives, ref int Life, ref int EnemyMovementFlag)
        {
            int tempScore = Score;
            int SpeedControler = 1;
            int Speed = 10;
            int EnemiesVerticalDistance = 1;
            int fireMove = 0;
            ResetAllValues(Enemies, ref EnemyMovementFlag, ref ShipFireFlag, ref ShipNextFireFlag, ref EnemyFireMovementFlag, ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y, EnemyFire);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            DisplayBorders(Border);
            while (true)
            {
                gotoxy(0, 0);
                if (EnemiesVerticalDistance % 100 == 0)
                    DecrementInEnemyY_Axis(ref Score, ref FireCount, Enemies, Border, ref EnemyMovementFlag, ref ShipFireFlag, ref ShipNextFireFlag, ref EnemyFireMovementFlag, ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y, EnemyFire);
                if (SpeedControler % Speed == 0)
                    MovementInEnemies(Enemies, ref EnemyMovementFlag);
                DisplayEnemies(Enemies);
                MovementInShip(ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y);
                ChkEnemyFire(EnemyFire, Enemies, ref EnemyFireMovementFlag);
                if (fireMove % 14 == 0)
                    EnemyFireMovement(ref EnemyFireMovementFlag, ref FireCount, EnemyFire, ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y);
                DisplayShip(ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y);
                ChkShipFire(ref ShipNextFireFlag, ref ShipFireFlag, ref S_Fire_x, ref S_Fire_y, ref S2_x, ref S2_y);
                ShipFireMovement(ref isFinalEnemy, ref FinalEnemyLives, ref Fx, ref Fy, ref Score, ref ShipNextFireFlag, ref ShipFireFlag, ref S_Fire_x, ref S_Fire_y, Enemies);
                SpeedControler++;
                fireMove++;
                DisplayStatus(FinalEnemyLives, Score, Life, FireCount, isFinalEnemy);
                if (SpeedControler % 60 == 0)
                    if (Speed > 5)
                        Speed--;
                if (FireCount == 5)
                {
                    Life--;
                    FireCount = 0;
                }
                if (Life == 0)
                    break;
                // Score = 1800;
                if (Score == 1800)
                {
                    temp.Score = 1800;
                    break;
                }

                EnemiesVerticalDistance++;
            }
        }

        static void Level_4(User temp, char[,] Border, ref int S1_x, ref int S1_y, ref int S2_x, ref int S2_y, ref int S3_x, ref int S3_y, enemyFire[] EnemyFire, enemy[] Enemies, ref bool EnemyFireMovementFlag, ref int FireCount, ref int ShipNextFireFlag, ref int ShipFireFlag, ref int S_Fire_x, ref int S_Fire_y, ref int Score, ref int Fx, ref int Fy, ref bool isFinalEnemy, ref int FinalEnemyLives, ref int Life, ref int EnemyMovementFlag, ref int FEF_x_1, ref int FEF_y_1, ref int FEF_x_2, ref int FEF_y_2, ref int FEF_x_3, ref int FEF_y_3, ref int FEF_x_4, ref int FEF_y_4, ref bool FinalEnemyFireMovementFlag, ref bool FinalEnemyFireFlag)
        {
            ResetAllValues(Enemies, ref EnemyMovementFlag, ref ShipFireFlag, ref ShipNextFireFlag, ref EnemyFireMovementFlag, ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y, EnemyFire);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            DisplayBorders(Border);
            int fireControl = 1;
            int fireMovement = 1;

            isFinalEnemy = true;
            while (true)
            {
                gotoxy(0, 0);
                DisplayFinalEnemy(Fx, Fy);
                if (fireMovement % 10 == 0)
                    FinalEnemyFireMovement(ref FinalEnemyFireFlag, ref FEF_x_1, ref FEF_y_1, ref FEF_x_2, ref FEF_y_2, ref FEF_x_3, ref FEF_y_3, ref FEF_x_4, ref FEF_y_4, ref FinalEnemyFireMovementFlag, Fx, Fy, ref FireCount, ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y);
                if (fireControl % 100 == 0)
                {
                    FinalEnemyRandomMovement(ref Fx, ref Fy);
                }
                ChkFinalEnemyFire(ref FinalEnemyFireFlag, ref FEF_x_1, ref FEF_y_1, ref FEF_x_2, ref FEF_y_2, ref FEF_x_3, ref FEF_y_3, ref FEF_x_4, ref FEF_y_4, ref FinalEnemyFireMovementFlag, Fx, Fy);
                fireControl++;
                fireMovement++;
                MovementInShip(ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y);
                DisplayShip(ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y);

                ChkShipFire(ref ShipNextFireFlag, ref ShipFireFlag, ref S_Fire_x, ref S_Fire_y, ref S2_x, ref S2_y);

                ShipFireMovement(ref isFinalEnemy, ref FinalEnemyLives, ref Fx, ref Fy, ref Score, ref ShipNextFireFlag, ref ShipFireFlag, ref S_Fire_x, ref S_Fire_y, Enemies);

                DisplayStatus(FinalEnemyLives, Score, Life, FireCount, isFinalEnemy);

                if (FireCount == 5)
                {
                    Life--;
                    FireCount = 0;
                }
                if (Life == 0)
                    break;
                if (FinalEnemyLives == 0)
                {
                    temp.Score = Score;
                    break;
                }
            }
        }



        static void GameWinningScreen()
        {
            Console.Clear();
            StreamReader file = new StreamReader("winmsg.txt");
            Console.WriteLine();
            gotoxy(70, 10);
            Console.Write("^");
            gotoxy(69, 11);
            Console.Write("<");
            gotoxy(71, 11);
            Console.Write(">");
            gotoxy(70, 12);
            Console.Write("*");
            gotoxy(70, 13);
            Console.Write("*");
            gotoxy(70, 14);
            Console.Write("*");
            gotoxy(70, 15);
            Console.Write("*");
            gotoxy(0, 3);
            int line = 1;
            int character = 1;
            string temp;
            while ((temp = file.ReadLine()) != null)
            {

                for (int i = 0; i < temp.Length; i++)
                {
                    if (line == 1 && character >= 18 && character <= 25)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (line == 1 && character >= 45)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(temp[i]);
                    Thread.Sleep(50);
                    character++;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                line++;
                character = 1;
            }

            int y1 = 11;

            int y2 = 10;

            int y3 = 11;
            for (int i = 0; i < 9; i++)
            {
                gotoxy(69, y1);
                Console.Write(" ");
                gotoxy(70, y2);
                Console.Write(" ");
                gotoxy(71, y3);
                Console.Write(" ");
                gotoxy(70, y1);
                Console.Write("*");
                y1--;
                y2--;
                y3--;
                gotoxy(69, y1);
                Console.Write("<");
                gotoxy(70, y2);
                Console.Write("^");
                gotoxy(71, y3);
                Console.Write(">");
                Thread.Sleep(100);
            }
            Console.Read();
        }


        static void initializingEnemiesCoordinate(enemy[] Enemies)
        {
            for (int i = 0; i < 24; i++)
            {
                enemy temp = new enemy();
                temp.flag = true;
                if (i >= 0 && i < 6)
                {
                    temp.y1 = 5;
                    temp.y2 = 5;
                }
                if (i >= 6 && i < 12)
                {
                    temp.y1 = 7;
                    temp.y2 = 7;
                }
                if (i >= 12 && i < 18)
                {
                    temp.y1 = 9;
                    temp.y2 = 9;
                }
                if (i >= 18 && i < 24)
                {
                    temp.y1 = 11;
                    temp.y2 = 11;
                }
                Enemies[i] = temp;
            }

            for (int i = 0; i < 24; i += 6)
            {
                Enemies[i].x1 = 6;
                Enemies[i].x2 = 7;
                Enemies[i + 1].x1 = 9;
                Enemies[i + 1].x2 = 10;
                Enemies[i + 2].x1 = 12;
                Enemies[i + 2].x2 = 13;
                Enemies[i + 3].x1 = 15;
                Enemies[i + 3].x2 = 16;
                Enemies[i + 4].x1 = 18;
                Enemies[i + 4].x2 = 19;
                Enemies[i + 5].x1 = 21;
                Enemies[i + 5].x2 = 22;
            }
        }



        static void DisplayEnemies(enemy[] Enemies)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 24; i++)
            {
                if (i >= 0 && i < 6)
                {
                    if (Enemies[i].flag)
                    {
                        gotoxy(Enemies[i].x1, Enemies[i].y1);
                        Console.Write("(");
                        gotoxy(Enemies[i].x2, Enemies[i].y2);
                        Console.Write(")");
                    }
                }
                if (i >= 6 && i < 12)
                {
                    if (Enemies[i].flag)
                    {
                        gotoxy(Enemies[i].x1, Enemies[i].y1);
                        Console.Write("-");
                        gotoxy(Enemies[i].x2, Enemies[i].y2);
                        Console.Write("-");
                    }
                }
                if (i >= 12 && i < 18)
                {
                    if (Enemies[i].flag)
                    {
                        gotoxy(Enemies[i].x1, Enemies[i].y1);
                        Console.Write("*");
                        gotoxy(Enemies[i].x2, Enemies[i].y2);
                        Console.Write("*");
                    }
                }
                if (i >= 18 && i < 24)
                {
                    if (Enemies[i].flag)
                    {
                        gotoxy(Enemies[i].x1, Enemies[i].y1);
                        Console.Write("+");
                        gotoxy(Enemies[i].x2, Enemies[i].y2);
                        Console.Write("+");
                    }
                }
            }
        }



        static void ClearingEnemiesPreviousPositions(enemy[] Enemies)
        {
            for (int i = 0; i < 24; i++)
            {
                gotoxy(Enemies[i].x1, Enemies[i].y1);
                Console.Write(" ");
                gotoxy(Enemies[i].x2, Enemies[i].y2);
                Console.Write(" ");
            }
        }


        static void Main(string[] args)
        {
            //............................DATA STRUCTURES.................................

            char[,] Border = new char[36, 35];
            enemy[] Enemies = new enemy[24];
            enemyFire[] EnemyFire = new enemyFire[4];
            enemyFire T = new enemyFire();
            EnemyFire[0] = T;
            EnemyFire[1] = T;
            EnemyFire[2] = T;
            EnemyFire[3] = T;

            //.....................................Flags & Control Variables..............

            int EnemyMovementFlag = 0;
            int ShipFireFlag = 0;
            int ShipNextFireFlag = 1;
            bool EnemyFireMovementFlag = true;
            bool isFinalEnemy = false;
            int Life = 3;
            int FireCount = 0;
            int Score = 0;
            int FinalEnemyLives = 15;
            //............................Variables for Space Ship.......................

            int S1_x = 11;
            int S1_y = 32;
            int S2_x = 12;
            int S2_y = 31;
            int S3_x = 13;
            int S3_y = 32;
            int S_Fire_x = 0;
            int S_Fire_y = 0;
            //............................................................................

            //............................Variables for Final Enemy.......................

            int Fx = 10;
            int Fy = 11;
            int FEF_x_1 = 1;
            int FEF_x_2 = 1;
            int FEF_x_3 = 1;
            int FEF_x_4 = 1;
            int FEF_y_1 = 1;
            int FEF_y_2 = 1;
            int FEF_y_3 = 1;
            int FEF_y_4 = 1;
            bool FinalEnemyFireFlag = true;
            bool FinalEnemyFireMovementFlag = false;

            //............................................................................
            List<User> UserList = new List<User>();
            ExtractingUserFile(UserList);
            Console.Clear();
            LoadBorderFromFile(Border);
            initializingEnemiesCoordinate(Enemies);
            char option = ' ';
            while (option != '4')
            {
                Header();
                option = Menu();
                if (option == '1')
                {
                    Header();
                    User temp = new User();
                    Console.Write("ENter Name of Player : ");
                    temp.Name = Console.ReadLine();
                    UserList.Add(temp);
                    ResetFlagsAndControls(ref EnemyMovementFlag, ref ShipFireFlag, ref ShipNextFireFlag, ref EnemyFireMovementFlag, ref Life, ref isFinalEnemy, ref Score, ref FinalEnemyLives, ref FireCount);
                    initializingEnemiesCoordinate(Enemies);
                    Console.Clear();
                    GameOpeningScreen();
                    Console.Clear();
                    GameStartingStory(Fx, Fy);
                    Lvl_1_OpeningScreen();
                    Level_1(UserList[UserList.Count - 1], Border, ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y, EnemyFire, Enemies, ref EnemyFireMovementFlag, ref FireCount, ref ShipNextFireFlag, ref ShipFireFlag, ref S_Fire_x, ref S_Fire_y, ref Score, ref Fx, ref Fy, ref isFinalEnemy, ref FinalEnemyLives, ref Life);
                    // Stage 2

                    if (Score == 600)
                    {
                        Lvl_2_OpeningScreen();
                        Level_2(UserList[UserList.Count - 1], Border, ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y, EnemyFire, Enemies, ref EnemyFireMovementFlag, ref FireCount, ref ShipNextFireFlag, ref ShipFireFlag, ref S_Fire_x, ref S_Fire_y, ref Score, ref Fx, ref Fy, ref isFinalEnemy, ref FinalEnemyLives, ref Life, ref EnemyMovementFlag);

                        // stage 3
                        if (Score == 1200)
                        {

                            Lvl_3_OpeningScreen();
                            Level_3(UserList[UserList.Count - 1], Border, ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y, EnemyFire, Enemies, ref EnemyFireMovementFlag, ref FireCount, ref ShipNextFireFlag, ref ShipFireFlag, ref S_Fire_x, ref S_Fire_y, ref Score, ref Fx, ref Fy, ref isFinalEnemy, ref FinalEnemyLives, ref Life, ref EnemyMovementFlag);
                        }
                        if (Score == 1800)
                        {
                            Lvl_4_OpeningScreen();
                            Level_4(UserList[UserList.Count - 1], Border, ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y, EnemyFire, Enemies, ref EnemyFireMovementFlag, ref FireCount, ref ShipNextFireFlag, ref ShipFireFlag, ref S_Fire_x, ref S_Fire_y, ref Score, ref Fx, ref Fy, ref isFinalEnemy, ref FinalEnemyLives, ref Life, ref EnemyMovementFlag, ref FEF_x_1, ref FEF_y_1, ref FEF_x_2, ref FEF_y_2, ref FEF_x_3, ref FEF_y_3, ref FEF_x_4, ref FEF_y_4, ref FinalEnemyFireMovementFlag, ref FinalEnemyFireFlag);

                            if (FinalEnemyLives == 0)
                            {
                                GameWinningScreen();
                            }
                            else
                            {
                                GameLose(Fx, Fy);

                            }
                        }
                        else
                        {
                            GameLose(Fx, Fy);

                        }

                    }
                    PutListInUserFile(UserList);
                }// end of opion 1
                if (option == '2')
                {
                    Header();

                    UserList.Sort((x, y) => x.Score.CompareTo(y.Score));
                    Console.WriteLine("Name\tScore");
                    for (int i = 0; i < UserList.Count; i++)
                    {
                        ShowPlayers(UserList[i]);
                    }

                    Console.ReadLine();


                }
                if (option == '3')
                {

                    initializingEnemiesCoordinate(Enemies);
                    ResetFlagsAndControls(ref EnemyMovementFlag, ref ShipFireFlag, ref ShipNextFireFlag, ref EnemyFireMovementFlag, ref Life, ref isFinalEnemy, ref Score, ref FinalEnemyLives, ref FireCount);
                    Console.Write("Enter Your Name : ");
                    string name;
                    name = Console.ReadLine();
                    bool isfound = false;
                    int userNumber = SearchUserNameInList(UserList, name, ref isfound);
                    if (isfound)
                    {
                        bool iswin = false;
                        Score = UserList[userNumber].Score;
                        if (Score < 600)
                        {
                            Lvl_1_OpeningScreen();
                            Level_1(UserList[userNumber], Border, ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y, EnemyFire, Enemies, ref EnemyFireMovementFlag, ref FireCount, ref ShipNextFireFlag, ref ShipFireFlag, ref S_Fire_x, ref S_Fire_y, ref Score, ref Fx, ref Fy, ref isFinalEnemy, ref FinalEnemyLives, ref Life);
                            if (Score == 600)
                                iswin = true;
                            else
                                iswin = false;
                        }
                        if (Score >= 600 && Score < 1200)
                        {

                            Lvl_2_OpeningScreen();
                            Level_2(UserList[userNumber], Border, ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y, EnemyFire, Enemies, ref EnemyFireMovementFlag, ref FireCount, ref ShipNextFireFlag, ref ShipFireFlag, ref S_Fire_x, ref S_Fire_y, ref Score, ref Fx, ref Fy, ref isFinalEnemy, ref FinalEnemyLives, ref Life, ref EnemyMovementFlag);
                            if (Score == 1200)
                                iswin = true;
                            else
                                iswin = false;
                        }
                        // stage 3
                        if (Score >= 1200 && Score < 1800)
                        {

                            Lvl_3_OpeningScreen();
                            Level_3(UserList[userNumber], Border, ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y, EnemyFire, Enemies, ref EnemyFireMovementFlag, ref FireCount, ref ShipNextFireFlag, ref ShipFireFlag, ref S_Fire_x, ref S_Fire_y, ref Score, ref Fx, ref Fy, ref isFinalEnemy, ref FinalEnemyLives, ref Life, ref EnemyMovementFlag);
                            if (Score == 1800)
                                iswin = true;
                            else
                                iswin = false;
                        }
                        if (Score >= 1800)
                        {
                            Lvl_4_OpeningScreen();
                            Level_4(UserList[userNumber], Border, ref S1_x, ref S1_y, ref S2_x, ref S2_y, ref S3_x, ref S3_y, EnemyFire, Enemies, ref EnemyFireMovementFlag, ref FireCount, ref ShipNextFireFlag, ref ShipFireFlag, ref S_Fire_x, ref S_Fire_y, ref Score, ref Fx, ref Fy, ref isFinalEnemy, ref FinalEnemyLives, ref Life, ref EnemyMovementFlag, ref FEF_x_1, ref FEF_y_1, ref FEF_x_2, ref FEF_y_2, ref FEF_x_3, ref FEF_y_3, ref FEF_x_4, ref FEF_y_4, ref FinalEnemyFireMovementFlag, ref FinalEnemyFireFlag);
                            if (FinalEnemyLives == 0)
                            {
                                GameWinningScreen();
                            }
                            else
                            {
                                GameLose(Fx, Fy);
                                UserList[userNumber].Score = 0;
                            }
                        }
                        else
                        {
                            if (!iswin)
                            {
                                GameLose(Fx, Fy);
                                UserList[userNumber].Score = 0;
                            }
                        }

                        PutListInUserFile(UserList);
                    }
                    else
                    {
                        Console.WriteLine("Player Not Found...");
                        Console.ReadLine();
                    }
                }//


            }
        }
    }
}
