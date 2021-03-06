﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;
using WMPLib;
using System.IO;
using System.Reflection;
using SnakeBasharov;

namespace SnakeBasharov
{
	class Program
	{
		static void Main(string[] args)
		{

			Random rand = new Random();
			Console.SetCursorPosition(2, 2);
			ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
			int i = rand.Next(0, colors.Length - 1);
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

			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					sound.Stop();
					sound2.PlayNo();
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
			SnakeBasharov.GameOver over = new SnakeBasharov.GameOver();
			over.WriteGameOver(snake.score);
			Console.ReadLine();
		}

				
			
		
	}
}