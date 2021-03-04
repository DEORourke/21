using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
	class Deck
	{
		private List<Card> cardList;
		public Deck()
		{
			this.cardList = this.BuildDeck();
		}

		private List<Card> BuildDeck()
		{
			List<Card> deck = new List<Card>();
			char[] suites = { '\u2660', '\u2666', '\u2663', '\u2665' };
			string[] signs = {"2 ", "3 ", "4 ", "5 ", "6 ", "7 ", "8 ", "9 ", "10", "J ", "Q ", "K ", "A "};

			foreach(char suite in suites)
			{
				foreach(string sign in signs)
				{
					int val;
					if (int.TryParse(sign.Trim(), out int num)) 
						val = num;
					
					else if (sign != "A ")
						val = 10;
					
					else 
						val = 11;

					deck.Add(new Card(val, sign, suite));
				}
			}

			return deck;
		}

		public Card Draw()
		{
			Random rnd = new Random();
			int pick = rnd.Next(this.cardList.Count - 1);
			Card drawn = this.cardList[pick];
			this.cardList.RemoveAt(pick);
			return drawn;
		}


	}

	class Card
	{
		public int Value;
		public string Sign;
		public char Suit;

		public Card(int val, string sign, char suit)
		{
			this.Value = val;
			this.Sign = sign;
			this.Suit = suit;
		}
	}

	class Hand
	{
		private List<Card> cardList = new List<Card>();
		private int total = 0;

		public void DrawCard(Card card)
		{
			this.cardList.Add(card);
			this.total += card.Value;
		}

		public int GetTotal()
		{
			if (this.total < 21)
				return this.total;

			int numAces = 0;
			foreach (Card card in this.cardList)
			{
				if (card.Value == 11)
					numAces++;
			}
			return this.total - (10 * numAces);
		}

		public List<Card> GetCards()
		{
			return this.cardList;
		}
	}

	class Artist
	{
		private string cardTop = "\u2554\u2550\u2550\u2557";
		private string cardBot = "\u255A\u2550\u2550\u255D";
		private char sideChar = '\u2551';
		private char fillChar = '\u2591';
		
		private ConsoleColor defaultColor = Console.ForegroundColor;
		private ConsoleColor brightColor = ConsoleColor.White;
		private ConsoleColor redColor = ConsoleColor.Red;
		private ConsoleColor blkColor = ConsoleColor.DarkGray;
		private ConsoleColor backColor = ConsoleColor.DarkCyan;

		private void drawPlayer (Hand hand)
		{
			List<Card> cardList = hand.GetCards();
			int cardCount = cardList.Count;

			string[] signs = new string[cardCount];
			char[] suits = new char[cardCount];

			for (int i = 0; i < cardCount; i++)
			{
				Console.Write($"{cardTop} ");
				signs[i] = cardList[i].Sign;
				suits[i] = cardList[i].Suit;
			}
			Console.Write("\n");
			foreach (string sign in signs)
			{
				Console.Write(sideChar);
				Console.ForegroundColor = brightColor;
				Console.Write(sign);
				Console.ForegroundColor = defaultColor;
				Console.Write($"{sideChar} ");
			}
			Console.Write("\n");
			foreach (char suite in suits)
			{
				Console.Write($"{sideChar} ");
				if (suite == '\u2660' || suite == '\u2663')
					Console.ForegroundColor = blkColor;
				else
					Console.ForegroundColor = redColor;
				Console.Write(suite);
				Console.ForegroundColor = defaultColor;
				Console.Write($"{sideChar} ");
			}
			Console.Write("\n");
			for (int i = 0; i < cardCount; i++)
			{
				Console.Write($"{cardBot} ");
			}
		}

		private void drawDealer(Hand hand)
		{
			List<Card> cardList = hand.GetCards();
			int cardCount = cardList.Count;

			string[] signs = new string[cardCount];
			char[] suits = new char[cardCount];

			for (int i = 0; i < cardCount; i++)
			{
				Console.Write($"{cardTop} ");
				signs[i] = cardList[i].Sign;
				suits[i] = cardList[i].Suit;
			}
			Console.Write("\n");
			
			for (int i = 0; i < cardCount; i++)
			{
				Console.Write(sideChar);
				
				if (i == 1)
				{
					Console.ForegroundColor = backColor;
					Console.Write($"{fillChar}{fillChar}");
				}

				else
				{
					Console.ForegroundColor = brightColor;
					Console.Write(signs[i]);	
				}
				
				Console.ForegroundColor = defaultColor;
				Console.Write($"{sideChar} ");
			}
			Console.Write("\n");
			for (int i = 0; i < cardCount; i++)
			{
				Console.Write(sideChar);

				if (i == 1)
				{
					Console.ForegroundColor = backColor;
					Console.Write($"{fillChar}{fillChar}");
				}

				else
				{
					if (suits[i] == '\u2660' || suits[i] == '\u2663')
						Console.ForegroundColor = blkColor;
					else
						Console.ForegroundColor = redColor;
					Console.Write($" {suits[i]}");
				}

				Console.ForegroundColor = defaultColor;
				Console.Write($"{sideChar} ");
			}
			Console.Write("\n");
			for (int i = 0; i < cardCount; i++)
			{
				Console.Write($"{cardBot} ");
			}
		}

		public void DrawHidenTable(Hand dealer, Hand player)
		{
			Console.Clear();
			this.drawDealer(dealer);
			this.drawSpacer();
			this.drawPlayer(player);
			Console.WriteLine("\n");
		}

		public void DrawUnhiddenTable(Hand dealer, Hand player)
		{
			Console.Clear();
			this.drawPlayer(dealer);
			this.drawSpacer();
			this.drawPlayer(player);
			Console.WriteLine("\n");
		}

		private void drawSpacer()
		{
			Console.ForegroundColor = brightColor;
			Console.Write("\n\n ~ ");
			Console.ForegroundColor = blkColor;
			Console.Write("\u2660 ");
			Console.ForegroundColor = redColor;
			Console.Write("\u2666 ");
			Console.ForegroundColor = blkColor;
			Console.Write("\u2663 ");
			Console.ForegroundColor = redColor;
			Console.Write("\u2665 ");
			Console.ForegroundColor = brightColor;
			Console.Write(" ~ \n\n");
			Console.ForegroundColor = defaultColor;
		}
	}

}
