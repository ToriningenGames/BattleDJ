using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorpCamp
{
    public class Gameplay
    {
        public struct BattleReport {
            public WinState currentResult;
            //public CharacterAction playerAction;
            //public CharacterAction enemyAction;
            public string playerAction;
            public string enemyAction;
        }
        public enum WinState
        {
            WinnerNone,
            WinnerPlayer,
            WinnerEnemy
        }
        public enum CharacterAction
        {
            Damage,
            Heal,
            Buff
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

        public BattleReport PlayCard(int cardIndex)
        {
            BattleReport roundResult = new BattleReport();
            roundResult.playerAction = this.PlayerTurn(cardIndex);
            if (IsWinner() != WinState.WinnerNone)
            {
                roundResult.currentResult = IsWinner();
                return roundResult;
            }
            roundResult.enemyAction = this.EnemyTurn(0);  //Only one card; always play the only card
            roundResult.currentResult = IsWinner();
            return roundResult;
        }

        private string PlayerTurn(int cardIndex)
        {
            //string playerAction = "{PlayerName} {action} for {number} points!";
            string playerAction = player.Name + " ";
            Card actionCard = this.player.PlayCard(cardIndex);
            int damage = actionCard.GetDamage();
            if (actionCard.GetType() == typeof(DamageBuffCard))
            {
                player.damageBuff += damage;
                playerAction += "buffs for " + -damage + " extra damage!";
            }
            else if (damage < 0)
            {
                this.enemy.Health += damage + player.damageBuff;
                playerAction += "hits for " + -damage + " damage!";
            }
            else
            {
                this.player.Health += damage;
                playerAction += "heals for " + damage + " hitpoints!";
            }
            return playerAction;
        }

        private string EnemyTurn(int cardIndex)
        {
            string enemyAction = enemy.Name + " ";
            Card actionCard = this.enemy.PlayCard(cardIndex);
            int damage = actionCard.GetDamage();
            if (actionCard.GetType() == typeof(DamageBuffCard))
            {
                enemy.damageBuff += damage;
                enemyAction += "buffs for " + -damage + " extra damage!";
            }
            else if (damage < 0)
            {
                this.player.Health += damage;
                enemyAction += "hits for " + -damage + " damage!";
            }
            else
            {
                this.enemy.Health += damage;
                enemyAction += "heals for " + damage + " hitpoints!";
            }
            return enemyAction;
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
