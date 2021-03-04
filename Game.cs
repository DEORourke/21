using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
	class Game
	{
		private Deck deck;
		private Hand player;
		private Hand dealer;
		private Artist artist;

		private int playerTotal;
		private int dealerTotal;

		public Game()
		{
			this.deck = new Deck();
			this.player = new Hand();
			this.dealer = new Hand();
			this.artist = new Artist();

			this.playerTotal = 0;
			this.dealerTotal = 0;

			this.Deal();
		}

		private void Deal()
		{
			this.player.DrawCard(this.deck.Draw());
			this.dealer.DrawCard(this.deck.Draw());
			this.player.DrawCard(this.deck.Draw());
			this.dealer.DrawCard(this.deck.Draw());
		}

		public void GameLoop()
		{
			bool playerTurn = true;
			bool dealerTurn = true;

			this.artist.DrawHidenTable(dealer, player);
			this.playerTotal = this.player.GetTotal();
			while (playerTurn)
			{
				this.HitStayPrompt(this.playerTotal);
				bool drawCard = this.GetPlayerInput();
				if (drawCard)
				{
					player.DrawCard(deck.Draw());
					playerTotal = player.GetTotal();
					if (playerTotal > 21)
						playerTurn = false;
				}
				else
					playerTurn = false;

				this.artist.DrawHidenTable(this.dealer, this.player);
			}

			if (playerTotal > 21)
			{
				this.artist.DrawHidenTable(this.dealer, this.player);
				this.BustMessage();
				return;
			}

			while (dealerTurn)
			{
				this.artist.DrawUnhiddenTable(this.dealer, this.player);
				System.Threading.Thread.Sleep(750);
				this.dealerTotal = dealer.GetTotal();

				if (this.dealerTotal < 17)
					dealer.DrawCard(deck.Draw());
				else
					dealerTurn = false;
			}

			if (dealerTotal > 21)
			{
				this.DealerBust();
				return;
			}

			GameOver(this.dealerTotal, this.playerTotal);
			return;
		}

		private void DealerBust()
		{
			Console.WriteLine("Dealer busts. You win by default.");
		}

		private void GameOver(int dealer, int player)
		{
			if (dealer >= player)
				Console.WriteLine($"Dealer wins {dealer} to {player}. Better luck next time.");
			else
				Console.WriteLine($"You win {player} to {dealer}.");
		}

		private void BustMessage()
		{
			Console.WriteLine("That's over 21, buddy. Ya busted.");
		}

		private void HitStayPrompt(int total)
		{
			ConsoleColor defaultColor = Console.ForegroundColor;
			ConsoleColor emphasisColor = ConsoleColor.DarkYellow;

			Console.Write($"{total}. Would you like to ");
			Console.ForegroundColor = emphasisColor;
			Console.Write("H");
			Console.ForegroundColor = defaultColor;
			Console.Write("it or ");
			Console.ForegroundColor = emphasisColor;
			Console.Write("S");
			Console.ForegroundColor = defaultColor;
			Console.Write("tay?");
		}

		private bool GetPlayerInput()
		{
			bool needInput = true;
			char key = 'n';

			while (needInput)
			{
				key = Console.ReadKey(true).KeyChar;
				if (key == 'h' || key == 's')
					needInput = false;
			}

			return (key == 'h') ? true : false;
		}
	}


}
                                                