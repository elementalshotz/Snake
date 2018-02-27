using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class PlayerEffects
    {
        Timer t;

        public PlayerEffects(ref Player player)
        {
            t = new Timer();
            t.Interval = Settings.EffectLength;

            player.timerList.Add(t);
        }
    }
}
