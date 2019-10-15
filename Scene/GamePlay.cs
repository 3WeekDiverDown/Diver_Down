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
        Player player;
        string backScreen;
        Timer timer;
        public GamePlay()
        {
            isEndFlag = false;
            gameObjectManager = new GameObjectManager();
        }

        public void Draw(Renderer renderer)
        {
            renderer.Begin();
            renderer.DrawTexture("HK2", Vector2.Zero);
            map.Draw(renderer);
            gameObjectManager.Draw(renderer);
            renderer.End();
        }

        public void Initialize()
        {
            isEndFlag = false;
            gameObjectManager.Initialize();
            map = new Map(GameDevice.Instance());
            player = new Player(new Vector2(32 * 2, 32 * 10), GameDevice.Instance(),gameObjectManager);
            gameObjectManager.Add(player);
            map.Load("map.csv", "./csv/");
            gameObjectManager.Add(map);
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
            if (player.IsDead())
                isEndFlag = true;
            gameObjectManager.Update(gameTime);
        }
    }
}
