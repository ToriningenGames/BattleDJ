using System;
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
            if (actionCard.GetType() == typeof(DamageBuffCard))
            {
                player.damageBuff += actionCard.GetDamage();
            }
            else
            {
                int damage = actionCard.GetDamage();
                if (damage < 0)
                {
                    this.enemy.Health += damage + player.damageBuff;
                }
                else
                {
                    this.player.Health += damage;
                }
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
            return this.GetHand(this.player);
        }

        public List<Card> GetEnemyHand()
        {
            return this.GetHand(this.enemy);
        }

        private List<Card> GetHand(Character character)
        {
            if (character.Hand.Count == 0)
            {
                character.DealHand();
            }

            return character.Hand;
        }

        public string GetPlayerStatus()
        {
            return this.GetStatus(this.player);
        }

        public string GetEnemyStatus()
        {
            return this.GetStatus(this.enemy);
        }

        private string GetStatus(Character character)
        {
            return character.Health + "/" + character.MaxHealth;
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
