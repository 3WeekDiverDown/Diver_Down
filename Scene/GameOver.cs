using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Diver_Down.Def;
using Diver_Down.Device;

namespace Diver_Down.Scene
{
    class GameOver : IScene
    {
        bool isEndFlag;
        Sound sound;

        public GameOver()
        {
            isEndFlag = false;
            var gameDevice = GameDevice.Instance();
            sound = gameDevice.GetSound();
        }

        public void Draw(Renderer renderer)
        {
            renderer.Begin();
            renderer.DrawTexture("load", new Vector2(200, 200   ));
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
            return Scene.Title;
        }

        public void Shutdown()
        {

        }

        public void Update(GameTime gameTime)
        {
            sound.PlayBGM("testBGM1");
            if (Input.GetKeyTrigger(Keys.Space))
            {
                isEndFlag = true;
                //sound.PlaySE("");
            }
        }
    }
}
