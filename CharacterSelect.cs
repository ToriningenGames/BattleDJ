using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorpCamp
{
    class CharacterSelect
    {
        public Character Player { get => Players[playerIndex]; }
        public Character Enemy { get => Enemies[enemyIndex]; }

        private int playerIndex = 0;
        private int enemyIndex = 0;

        private List<Character> Players;
        private List<Character> Enemies;

        public CharacterSelect()
        {
            this.Players = CreateCharacters();
            this.Enemies = CreateCharacters();
        }
        private List<Character> CreateCharacters()
        {
            List<Character> characters = new List<Character>();

            characters.Add(new Character(
                "Dr. Milk",
                "DrMilk.png",
                50,
                499,
                new List<Card>{
                    new RandomDamageCard("Milk Attack", "milk_atk.png", -11, -5),
                    new RandomDamageCard("Milk Heal", "milk_heal.png", 5, 11)
                }
            ));
            characters.Add(new Character(
                "The Rat Master",
                "standard.png",
                55,
                500,
                new List<Card> {
                    new StaticDamageCard("Heal", "heal_card_final.png", 7),
                    new RandomDamageCard("Sword", "SWORD_final.png", -8, -3),
                    new RandomDamageCard("Bow", "Bow.png", -8, -2)
                }
            ));
            characters.Add(new Character(
                "Criss With a Gun",
                "crisswithagun.png",
                1000,
                500,
                new List<Card>
                {
                    new StaticDamageCard("Gun", "gun_card.png", -99)
                }
            ));
            characters.Add(new Character(
                "Rat Wizard",
                "rat_wiz.png",
                40,
                250,
                new List<Card>
                {
                    new StaticDamageCard("Heal", "heal_card_final.png", 7),
                    new RandomDamageCard("Sword", "SWORD_final.png", -8, -3),
                    new RandomDamageCard("Bow", "Bow.png", -8, -2)
                }
            ));

            characters.Add(new Character(
                "Rat Gamer",
                "Rat_Gamer.png",
                35,
                300,
                new List<Card>
                {
                    new StaticDamageCard("Heal", "heal_card_final.png", 7),
                    new RandomDamageCard("Sword", "SWORD_final.png", -8, -3),
                    new RandomDamageCard("Bow", "Bow.png", -8, -2)
                }
            ));

            return characters;
        }

        public void PlayerNext()
        {
            playerIndex++;
            if (playerIndex >= Players.Count)
            {
                playerIndex = 0;
            }
        }

        public void PlayerPrev()
        {
            playerIndex--;
            if (playerIndex < 0)
            {
                playerIndex = Players.Count - 1;
            }
        }

        public void EnemyNext()
        {
            enemyIndex++;
            if (enemyIndex >= Enemies.Count)
            {
                enemyIndex = 0;
            }
        }

        public void EnemyPrev()
        {
            enemyIndex--;
            if (enemyIndex < 0)
            {
                enemyIndex = Enemies.Count - 1;
            }
        }
    }
}
