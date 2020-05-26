using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;
using WMPLib;
using System.IO;

namespace SnakeBasharov
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.SetWindowSize(80, 25);

			Walls walls = new Walls(80, 25);
			walls.Draw();

			// Отрисовка точек			
			Point p = new Point(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(80, 25, '$');
			Point food = foodCreator.CreateFood();
			food.Draw();
			Params settings = new Params();
			Sounds sound = new Sounds(settings.GetResourceFolder());
			sound.Play();

			Sounds sound1 = new Sounds(settings.GetResourceFolder());

			Sounds sound2 = new Sounds(settings.GetResourceFolder());

			//Score score = new Score(settings.GetResorceFolder());

			//Stopwatch stopwatch = new Stopwatch();
			//stopwatch.Start();

			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
				if (snake.Eat(food))
				{
					food = foodCreator.CreateFood();
					food.Draw();
					sound1.PlayEat();
				}
				else
				{
					snake.Move();
				}

				Thread.Sleep(100);
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
			sound.Stop();
			WriteGameOver();
			Console.ReadLine();
		}


		static void WriteGameOver()
		{
			Params settings = new Params();
			Sounds sound2 = new Sounds(settings.GetResourceFolder());
			Sounds sound = new Sounds(settings.GetResourceFolder());
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
			yOffset++;
			WriteText("Автор: Карим Башаров", xOffset + 2, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			sound2.PlayNo();
		}

		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}

	}
}