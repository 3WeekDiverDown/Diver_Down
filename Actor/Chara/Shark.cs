using Diver_Down.Device;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diver_Down.Actor.Chara
{
    class Shark : GameObject
    {
        private Vector2 velocity;

        public Shark(Vector2 position, GameDevice gameDevice)
               : base("P2", position, 64, 64, gameDevice)
        {
            velocity = new Vector2(-5, 0);
        }

        public Shark(Shark other) : this(other.position, other.gameDevice)
        {

        }

        public override object Clone()
        {
            return new Shark(this);
        }

        public override void Hit(GameObject gameObject)
        {

        }

        public override void Updata(GameTime gameTime)
        {
            position += velocity;
        }
    }
}