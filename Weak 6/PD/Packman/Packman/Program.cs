using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Packman.BL;
using System.Threading;
using EZInput;
using Packman.DL;
namespace Packman
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid maze = new Grid(24, 71, "maze.txt");
            PacMan PLayer = new PacMan(32, 9, maze);
            GhostCRUD.addEnemyinList(new Ghost(39, 15, 'H', "smart", 0.1F, ' ', maze));
            GhostCRUD.addEnemyinList(new Ghost(57, 20, 'V', "up", 0.2F, ' ', maze));
            GhostCRUD.addEnemyinList(new Ghost(26, 19, 'H', "left", 1F, ' ', maze));
            maze.Draw();
            PLayer.Draw();
            bool gameRunning = true;
            while (gameRunning)
            {
                /*     Console.Clear();*/
                Thread.Sleep(90);

                foreach (Ghost g in GhostCRUD.enemies)
                {
                    if (g.Move())
                        gameRunning = false;
                    g.Draw();
                }
                PLayer.Draw();
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    if (PLayer.MoveUp(maze.getUpCell(maze.FindPacMan())))
                        gameRunning = false;
                }
                else if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    if (PLayer.MoveDown(maze.getDownCell(maze.FindPacMan())))
                        gameRunning = false;
                }
                else if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    if (PLayer.MoveLeft(maze.getLeftCell(maze.FindPacMan())))
                        gameRunning = false;
                }
                else if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    if (PLayer.MoveRight(maze.getRightCell(maze.FindPacMan())))
                        gameRunning = false;
                }
                PLayer.Draw();

            }
        }
    }
}
