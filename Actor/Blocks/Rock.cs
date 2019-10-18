using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Diver_Down.Device;

namespace Diver_Down.Actor.Rocks
{
    class Rock : GameObject
    {
        public Rock(Vector2 pos, GameDevice gameDevice)
            : base("brock", pos, 64, 64, gameDevice)
        { }
        public Rock(Rock other)
            : this(other.position, other.gameDevice)
        { }
        public override object Clone()
        {
            return new Rock(this);
        }

        public override void Hit(GameObject gameObject)
        {

        }

        public override void Updata(GameTime gameTime)
        {

        }
    }
}