using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonestDark
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int initialHealth = 100;
            int currentHealth = initialHealth;
            int coins = 0;
            string rooms = Console.ReadLine();
            string[] room = rooms.Split('|');

            for (int i = 0; i < room.Length; i++)
            {
                string[] roomP = room[i].Split(' ');
                string roomT = roomP[0];

                if (roomT == "potion")
                {
                    int healing = int.Parse(roomP[1]);
                    if (currentHealth + healing <= initialHealth)
                    {
                        currentHealth += healing;
                        Console.WriteLine($"You healed for {healing} hp.");
                    }
                    else
                    {
                        healing = initialHealth - currentHealth;
                        currentHealth = initialHealth;
                        Console.WriteLine($"You healed for {healing} hp.");
                    }
                    Console.WriteLine($"Current health: {currentHealth} hp.");
                }
                else if  (roomT == "chest")
                {
                    int coins2 = int.Parse(roomP[1]);
                    coins += coins2;
                    Console.WriteLine($"You found {coins2} coins.");
                }
                else
                {
                    int monster= int.Parse(roomP[1]);
                    currentHealth -= monster;
                    if (currentHealth > 0)
                    {
                        string monstern = roomT;
                        Console.WriteLine($"You slayed {monstern}.");
                    }
                    else
                    {
                        string monsterName = roomT;
                        Console.WriteLine($"You died! Killed by {monsterName}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }

                }
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Health: {currentHealth}");
        }
    }
    
}
