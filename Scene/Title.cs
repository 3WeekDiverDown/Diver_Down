using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Diver_Down.Device;
using Diver_Down.Def;
using Diver_Down.Utility;

namespace Diver_Down.Scene
{
    class Title : IScene
    {
        private bool isEndFlag;
        private Sound sound;

        public Title()
        {
            isEndFlag = false;
            var gameDevice = GameDevice.Instance();
            sound = gameDevice.GetSound();
        }

        public void Draw(Renderer renderer)
        {
            renderer.Begin();
            renderer.DrawTexture("load", new Vector2(50, 50));
            renderer.End();
        }

        public void Initialize()
        {
            isEndFlag = false;
        }

        public bool IsEnd()
        {
            return isEndFlag;
        }

        public Scene Next()
        {
            sound.StopBGM();
            return Scene.GamePlay;
        }

        public void Shutdown()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            sound.PlayBGM("testBGM2");
            if(Input.GetKeyTrigger(Keys.Space))
            {
                isEndFlag = true;
                //sound.PlaySE("");
            }
        }
    }
}
