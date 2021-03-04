using System;
using System.Collections.Generic;

namespace Blackjack
{
	class Program
	{
		static void Main(string[] args)
		{
			TitleScreen();
			bool playing = true;
			
			while (playing)
			{
				Game game = new Game();
				game.GameLoop();
				ContinuePrompt();
				playing = ContinueInput();
			}
		}

		static void TitleScreen()
		{
			int waitTime = 250;
			ConsoleColor redColor = ConsoleColor.Red;
			ConsoleColor blkColor = ConsoleColor.DarkGray;
			ConsoleColor defaultColor = Console.ForegroundColor;

			Console.Write('\n');

			Console.ForegroundColor = blkColor; // line 1
			RepChar(' ', 5);
			RepChar('\u2660', 3);
			Console.ForegroundColor = redColor;
			RepChar(' ', 7);
			RepChar('\u2666', 3);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = blkColor; // line 2
			RepChar(' ', 4);
			RepChar('\u2663', 5);
			Console.ForegroundColor = redColor;
			RepChar(' ', 5);
			RepChar('\u2665', 4);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = blkColor; // line 3
			RepChar(' ', 3);
			RepChar('\u2660', 2);
			RepChar(' ', 2);
			RepChar('\u2660', 3);
			Console.ForegroundColor = redColor;
			RepChar(' ', 5);
			RepChar('\u2666', 3);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = blkColor; // line 4
			RepChar(' ', 6);
			RepChar('\u2663', 3);
			Console.ForegroundColor = redColor;
			RepChar(' ', 6);
			RepChar('\u2665', 3);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = blkColor; // line 5
			RepChar(' ', 5);
			RepChar('\u2660', 3);
			Console.ForegroundColor = redColor;
			RepChar(' ', 7);
			RepChar('\u2666', 3);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = blkColor; // line 6
			RepChar(' ', 4);
			RepChar('\u2663', 3);
			Console.ForegroundColor = redColor;
			RepChar(' ', 8);
			RepChar('\u2665', 3);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = blkColor; // line 7
			RepChar(' ', 3);
			RepChar('\u2660', 3);
			Console.ForegroundColor = redColor;
			RepChar(' ', 9);
			RepChar('\u2666', 3);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = blkColor; // line 8
			RepChar(' ', 2);
			RepChar('\u2663', 8);
			Console.ForegroundColor = redColor;
			RepChar(' ', 4);
			RepChar('\u2665', 5);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = blkColor; // line 9
			RepChar(' ', 2);
			RepChar('\u2660', 8);
			Console.ForegroundColor = redColor;
			RepChar(' ', 4);
			RepChar('\u2666', 5);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = defaultColor;
			System.Threading.Thread.Sleep(1000);

			Console.WriteLine("\nPress the any key to play.");
			Console.ReadKey(true);
		}

		static void TitleScreen2()
		{
			int waitTime = 250;
			ConsoleColor redColor = ConsoleColor.Red;
			ConsoleColor blkColor = ConsoleColor.DarkGray;
			ConsoleColor defaultColor = Console.ForegroundColor;

			Console.Write('\n');

			Console.ForegroundColor = blkColor; // line 1
			RepChar(' ', 5);
			RepChar('\u2660', 3);
			RepChar(' ', 7);
			RepChar('\u2663', 3);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = redColor; // line 2
			RepChar(' ', 4);
			RepChar('\u2666', 5);
			RepChar(' ', 5);
			RepChar('\u2665', 4);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = blkColor; // line 3
			RepChar(' ', 3);
			RepChar('\u2660', 2);
			RepChar(' ', 2);
			RepChar('\u2660', 3);
			RepChar(' ', 5);
			RepChar('\u2663', 3);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = redColor; // line 4
			RepChar(' ', 6);
			RepChar('\u2666', 3);
			RepChar(' ', 6);
			RepChar('\u2665', 3);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = blkColor; // line 5
			RepChar(' ', 5);
			RepChar('\u2660', 3);
			RepChar(' ', 7);
			RepChar('\u2663', 3);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = redColor; // line 6
			RepChar(' ', 4);
			RepChar('\u2666', 3);
			RepChar(' ', 8);
			RepChar('\u2665', 3);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = blkColor; // line 7
			RepChar(' ', 3);
			RepChar('\u2660', 3);
			RepChar(' ', 9);
			RepChar('\u2663', 3);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = redColor; // line 8
			RepChar(' ', 2);
			RepChar('\u2666', 8);
			RepChar(' ', 4);
			RepChar('\u2665', 5);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = blkColor; // line 9
			RepChar(' ', 2);
			RepChar('\u2660', 8);
			RepChar(' ', 4);
			RepChar('\u2663', 5);
			Console.Write('\n');
			System.Threading.Thread.Sleep(waitTime);

			Console.ForegroundColor = defaultColor;
			System.Threading.Thread.Sleep(1000);

			Console.WriteLine("\nPress the any key to play.");
			Console.ReadKey(true);
		}

		static void RepChar(char cha, int times)
		{
			for (int i = 0; i < times; i++)
			{
				Console.Write(cha);
			}
		}

		static void ContinuePrompt()
		{
			ConsoleColor defaultColor = Console.ForegroundColor;
			ConsoleColor emphasisColor = ConsoleColor.DarkYellow;

			Console.Write("\n\nPlay again? [");
			Console.ForegroundColor = emphasisColor;
			Console.Write("Y");
			Console.ForegroundColor = defaultColor;
			Console.Write("/");
			Console.ForegroundColor = emphasisColor;
			Console.Write("N");
			Console.ForegroundColor = defaultColor;
			Console.Write("]");
		}
	
		static bool ContinueInput()
		{
			bool needInput = true;
			char key = 'n';

			while (needInput)
			{
				key = Console.ReadKey(true).KeyChar;
				if (key == 'y' || key == 'n')
					needInput = false;
			}

			return (key == 'y') ? true : false;
		}
	}
}
