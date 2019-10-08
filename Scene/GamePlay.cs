using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Diver_Down.Actor;
using Diver_Down.Device;
using Diver_Down.Utility;

namespace Diver_Down.Scene
{
    class GamePlay : IScene
    {
        bool isEndFlag;
        Map map;
        GameObjectManager gameObjectManager;
        string backScreen;
        public GamePlay()
        {
            isEndFlag = false;
            gameObjectManager = new GameObjectManager();
        }

        public void Draw(Renderer renderer)
        {
            renderer.Begin();
            //renderer.DrawTexture(backScreen, Vector2.Zero,null,new Vector2(0.75f,0.75f),true);
            //map.Draw(renderer);
            //gameObjectManager.Draw(renderer);
            renderer.DrawTexture("load", new Vector2(200, 20));
            renderer.End();
        }

        public void Initialize()
        {
            isEndFlag = false;
            gameObjectManager.Initialize();
            map = new Map(GameDevice.Instance());
            //player = new Player(new Vector2(32 * 2, 32 * 10), GameDevice.Instance());
            //gameObjectManager.Add(player);
            //if (stage == Stage.Base)
            //{
            //    map.Load("map.csv", "./csv/");
            //    backScreen = "Home";
            //}
        }

        public bool IsEnd()
        {
            return isEndFlag;
        }
        public Scene Next()
        {
            return Scene.GameOver;
        }
        public void Shutdown()
        {

        }
        public void Update(GameTime gameTime)
        {
            map.Update(gameTime);
            if (Input.GetKeyTrigger(Keys.Space))
                isEndFlag = true;
            gameObjectManager.Update(gameTime);
        }
    }
}
