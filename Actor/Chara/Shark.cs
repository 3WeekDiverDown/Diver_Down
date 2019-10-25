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
        private IGameObjectMediator mediator;
        private GameObject player;
        private int p = 320;

        public Shark(Vector2 position, GameDevice gameDevice, IGameObjectMediator mediator)
               : base("P2", position, 64, 64, gameDevice)
        {
            this.mediator = mediator;
        }

        public Shark(Shark other) : this(other.position, other.gameDevice, other.mediator)
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
            player = mediator.GetPlayer();
            Vector2 otherPosition = player.GetPosition();

            if(otherPosition.X - position.X <= p && otherPosition.X - position.X >= -p)
            {
                if (otherPosition.Y - position.Y <= p && otherPosition.X - position.X >= -p)
                {
                    velocity = otherPosition - position;
                    velocity.Normalize();
                }
                else
                {
                    velocity = Vector2.Zero;
                }
            }
            else
            {
                velocity = Vector2.Zero;
            }

            position += velocity * 3;
        }
    }
}