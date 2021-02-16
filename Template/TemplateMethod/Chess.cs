﻿using System;

namespace Template.TemplateMethod
{
    public class Chess : Game
    {
        private int turn = 1;
        private int maxTurns = 10;

        public Chess()
            : base(2)
        {
        }

        protected override bool HaveWinner => turn == maxTurns;

        protected override int WinningPlayer => currentPlayer;

        protected override void Start()
        {
            Console.WriteLine($"Starting a game of chess with {numberOfPlayers}");
        }

        protected override void TakeTurn()
        {
            Console.WriteLine($"Turn {turn++} taken by player {currentPlayer}.");
            currentPlayer = (currentPlayer + 1) % numberOfPlayers;
        }
    }
}