﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Diver_Down.Device;

namespace Diver_Down.Actor.Blocks
{
    class Block : GameObject
    {
        public Block(Vector2 pos, GameDevice gameDevice)
            : base("blockkabe", pos, 32, 32, gameDevice)
        { }
        public Block(Block other)
            : this(other.position, other.gameDevice)
        { }
        public override object Clone()
        {
            return new Block(this);
        }

        public override void Hit(GameObject gameObject)
        {

        }

        public override void Updata(GameTime gameTime)
        {

        }
    }
}