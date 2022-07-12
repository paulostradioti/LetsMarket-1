using LetsMarket.Controllers;
using LetsMarket.Models;
using LetsMarket.Views.ViewInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Views
{
    public class MenuView : IMenuView
    {
        public ConsoleKey ShowMenu(Menu menu)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            var key = new ConsoleKeyInfo();

            while (true)
            {
                Console.Clear();
                Console.ResetColor();

                var menuTitle = $"{menu.UNSELECTED}{menu.title.ToUpperInvariant().PadRight(menu.LINE_WIDTH)}|";
                var lineSeparator = $"|{new string('-', menuTitle.Length - 2)}|";

                Console.WriteLine(lineSeparator);
                Console.WriteLine(menuTitle);
                Console.WriteLine(lineSeparator);

                for (int i = 0; i < menu.items.Count; i++)
                {
                    var isSelected = i == menu.selectedIndex;
                    var margin = isSelected ? menu.SELECTED : menu.UNSELECTED;

                    if (isSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine($"{margin}{menu.items[i].ToString().PadRight(menu.LINE_WIDTH)}|");
                    Console.ResetColor();
                }
                Console.WriteLine(lineSeparator);

                key = Console.ReadKey(true);
                if (MenuController.acceptedKeys.Contains(key.Key))
                {
                    Console.Clear();
                    return key.Key;
                }
            }
        }
    }
}

