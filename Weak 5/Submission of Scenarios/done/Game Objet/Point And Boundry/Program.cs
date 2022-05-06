using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point_And_Boundry.BL;
using System.Threading;
using Point_And_Boundry.DL;
using Point_And_Boundry.UI;
using EZInput;
namespace Point_And_Boundry
{
    class Program
    {
        static void Option_1()
        {

            MenuUI.Header();
            GameObjectCRUD.AddObjectInList(GameObjetUI.TakeInputOfGameObject());
            GameObjectCRUD.WriteToFile();
        }
        static void Option_2()
        {
            MenuUI.clrscr();
            for (int i = 0; i < GameObjectCRUD.ListOfGameObjects.Count; i++)
            {
                GameObjectCRUD.ListOfGameObjects[i].Draw();
            }
            MenuUI.InputString();
        }
        static void Option_3()
        {
            MenuUI.clrscr();
            bool flag = true;
            while (flag)
            {
                for (int i = 0; i < GameObjectCRUD.ListOfGameObjects.Count; i++)
                {
                    GameObjectCRUD.ListOfGameObjects[i].Draw();
                }
                Thread.Sleep(100);

                for (int i = 0; i < GameObjectCRUD.ListOfGameObjects.Count; i++)
                {
                    GameObjectCRUD.ListOfGameObjects[i].Erase();
                }
                for (int i = 0; i < GameObjectCRUD.ListOfGameObjects.Count; i++)
                {
                    GameObjectCRUD.ListOfGameObjects[i].Move();
                }

                if (EZInput.Keyboard.IsKeyPressed(Key.Escape))
                    flag = false;
            }
            for (int i = 0; i < GameObjectCRUD.ListOfGameObjects.Count; i++)
            {
                GameObjectCRUD.ListOfGameObjects[i].ResetStartingPoint();
            }
            MenuUI.InputString();
        }
        static void Option_4()
        {

            for (int i = 0; i < GameObjectCRUD.ListOfGameObjects.Count; i++)
            {
                GameObjectCRUD.ListOfGameObjects[i].Erase();
            }
        }
        static void Main(string[] args)
        {
            GameObjectCRUD.ReadFromFile();
            MenuUI.Header();
            char option;
            do
            {
                MenuUI.Header();
                option = MenuUI.Menu();
                if (option == '1')
                {
                    Option_1();
                }
                else if (option == '2')
                {
                    Option_2();
                }
                else if (option == '3')
                {
                    Option_3();
                }
                else if (option == '4')
                {
                    Option_4();
                }
                MenuUI.InputString();
            } while (option != '5');
        }
    }
}
