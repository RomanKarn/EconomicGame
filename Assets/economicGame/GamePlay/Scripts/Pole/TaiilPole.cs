using NUnit.Framework;
using System;
using UnityEngine;

class HelloWorld
{
	static void Main()
	{
		Game game = new Game();
		game.OneTike();
		Console.WriteLine(game._resurs[TipeResurs.FOOD]);
	}
}
