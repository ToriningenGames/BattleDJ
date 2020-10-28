using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorpCamp
{
    class Gameplay
    {
        private Character player;
        private Character enemy;
        public Gameplay(
            Character player,
            Character enemy   
        ) {
            this.player = player;
            this.enemy = enemy;
        }

        private void PlayerTurn()
        {
            
        }

        private void EnemyTurn()
        {

        }

        public string GetPlayerStatus()
        {
            return this.player.Health + "/" + this.player.MaxHealth;
        }

        public string GetEnemyStatus()
        {
            return this.enemy.Health + "/" + this.enemy.MaxHealth;
        }

        private bool IsWinner(int health)
        {
            return true;
        }
    }
}
