using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diver_Down.Device;
using Diver_Down.Utility;
using Microsoft.Xna.Framework;

namespace Diver_Down.Scene
{
    class TimerUI
    {
        private Timer timer;
        public TimerUI(Timer timer)
        { this.timer = timer; }
        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture("timer", new Vector2(400, 10));
            renderer.DrawNumber("number", new Vector2(600, 13),timer.Now() );
        }
    }
}
