using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProtoKom {
    public class ScoreboardRace : MonoBehaviour {
        public Text RankOne;
        public Text RankTwo;
        public Text RankThree;
        public Text RankFour;

        public List<Chien> Leaderboard = new List<Chien>();

        public void Update() {
            if (Leaderboard.Count == 4) {
                RankOne.text = Leaderboard[3].Nom;
                RankTwo.text = Leaderboard[2].Nom;
                RankThree.text = Leaderboard[1].Nom;
                RankFour.text = Leaderboard[0].Nom;
            }
        }
    }
}