using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _120326_hw
{
    internal class LvlSystem
    {
        private int exp;
        private int curLvl;
        private int expMult;
        public LvlSystem(int exp, int curLvl, int expMult)
        {
            this.exp = exp;
            this.curLvl = curLvl;
            this.expMult = expMult;
        }
        public void AddExp(int addexp)
        {
            exp += addexp;
            LvlUp();
        }
        public void LvlUp()
        {
            int requiredExp = curLvl * curLvl * expMult;
            while(exp >= requiredExp)
            {
                curLvl++;
                exp -= requiredExp;
                requiredExp = curLvl * curLvl * expMult;
            }
        }
        public void LoadData(int loadLevel, int loadExperinece)
        {
            exp = loadExperinece;
            curLvl = loadLevel;
        }
    }
}
