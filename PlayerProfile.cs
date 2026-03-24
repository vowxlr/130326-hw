using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _120326_hw
{
    internal class PlayerProfile
    {
        private string PlayerName;
        private int MaxLevel;
        private int Score;
        public string Playername { get { return PlayerName; } }
        public int Maxlevel { get { return MaxLevel; } }
        public int SCore { get { return Score; } }
        public PlayerProfile(string PlayerName, int MaxLevel, int Score)
        {
            this.PlayerName = PlayerName;
            this.MaxLevel = MaxLevel;
            this.Score = Score;
        }
        public void ChangeMaxLevel(int newlvl)
        {
            if (newlvl == MaxLevel && (newlvl != 5))
            {
                MaxLevel++;
            }
        }
        public void AddScore(int exp)
        {
            Score += exp;
        }
    }
}
