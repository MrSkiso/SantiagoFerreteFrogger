using System;
using System.Collections.Generic;
using System.Linq;

namespace M05_UF3_P3_Frogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TODO
            Console.CursorVisible = false;
            Console.WindowHeight = Utils.MAP_HEIGHT + 1;
            Console.WindowWidth = Utils.MAP_WIDTH;

            List<Lane> lanes = new List<Lane>();

            lanes.Add(new Lane(7, false, ConsoleColor.Black, true, false, 0.3f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(8, false, ConsoleColor.Black, true, false, 0.4f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(9, false, ConsoleColor.Black, true, false, 0.2f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(10, false, ConsoleColor.Black, true, false, 0.2f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(11, false, ConsoleColor.Black, true, false, 0.3f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(6, false, ConsoleColor.DarkGreen, false, false, 0.0f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(12, false, ConsoleColor.DarkGreen, false, false, 0.0f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(13, false, ConsoleColor.DarkGreen, false, false, 0.0f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));
            lanes.Add(new Lane(0, false, ConsoleColor.DarkGreen, false, false, 0.0f, Utils.charCars, new List<ConsoleColor>(Utils.colorsCars)));

            lanes.Add(new Lane(1, true, ConsoleColor.DarkBlue, false, true, 0.7f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lanes.Add(new Lane(2, true, ConsoleColor.DarkBlue, false, true, 0.8f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lanes.Add(new Lane(3, true, ConsoleColor.DarkBlue, false, true, 0.9f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lanes.Add(new Lane(4, true, ConsoleColor.DarkBlue, false, true, 0.3f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));
            lanes.Add(new Lane(5, true, ConsoleColor.DarkBlue, false, true, 0.6f, Utils.charLogs, new List<ConsoleColor>(Utils.colorsLogs)));

            Player player = new Player();

            Utils.GAME_STATE gameState = Utils.GAME_STATE.RUNNING;

            while (gameState == Utils.GAME_STATE.RUNNING)
            {
                Console.Clear();

                foreach (Lane lane in lanes)
                {
                    lane.Update();
                    lane.Draw();
                }

                Vector2Int input = Utils.Input();
                gameState = player.Update(input, lanes);
                player.Draw(lanes);

                TimeManager.NextFrame();
            }

            Console.Clear();
            Console.WriteLine(gameState == Utils.GAME_STATE.WIN ? "¡YOU WON!" : "YOU LOST");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}