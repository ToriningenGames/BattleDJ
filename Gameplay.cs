﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorpCamp
{
    public class Gameplay
    {
        public enum WinState
        {
            WinnerNone,
            WinnerPlayer,
            WinnerEnemy
        }

        private Character player;
        private Character enemy;
        public Gameplay(
            Character player,
            Character enemy   
        ) {
            this.player = player;
            this.enemy = enemy;
            this.player.HandSize = 3;
            this.enemy.HandSize = 1;
        }

        public WinState PlayCard(int cardIndex)
        {
            this.PlayerTurn(cardIndex);
            if (IsWinner() != WinState.WinnerNone)
            {
                return IsWinner();
            }
            this.EnemyTurn(0);  //Only one card; always play the only card
            return IsWinner();
        }

        private void PlayerTurn(int cardIndex)
        {
            Card actionCard = this.player.PlayCard(cardIndex);
            int damage = actionCard.GetDamage();
            if (damage < 0)
            {
                this.enemy.Health += damage;
            } else
            {
                this.player.Health += damage;
            }
        }

        private void EnemyTurn(int cardIndex)
        {
            Card actionCard = this.enemy.PlayCard(cardIndex);
            int damage = actionCard.GetDamage();
            if (damage < 0)
            {
                this.player.Health += damage;
            }
            else
            {
                this.enemy.Health += damage;
            }
        }

        public List<Card> GetPlayerHand()
        {
            if (this.player.Hand.Count == 0)
            {
                this.player.DealHand();
            };
            return this.player.Hand;
        }

        public List<Card> GetEnemyHand()
        {
            if (this.enemy.Hand.Count == 0)
            {
                this.enemy.DealHand();
            };
            return this.enemy.Hand;
        }

        public string GetPlayerStatus()
        {
            return this.player.Health + "/" + this.player.MaxHealth;
        }

        public string GetEnemyStatus()
        {
            return this.enemy.Health + "/" + this.enemy.MaxHealth;
        }

        private WinState IsWinner()
        {
            if (this.enemy.Health <= 0)
            {
                return WinState.WinnerPlayer;
            }
            if (this.player.Health <= 0)
            {
                return WinState.WinnerEnemy;
            }
            //Everybody has health; no game winner yet
            return WinState.WinnerNone;
        }
    }
}
