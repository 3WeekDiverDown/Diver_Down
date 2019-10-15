using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diver_Down.Utility;
using Diver_Down.Def;
using Diver_Down.Device;

namespace Diver_Down.Actor
{
    class Player : GameObject
    {
        private Vector2 velocity;
        private float yVectol;
        private float xVectol;
        private float ySpeedMax;
        private float xSpeedMax;
        private IGameObjectMediator mediator;
        private Vector2 slideModify;
        private bool gool;
        private Motion motion;
        private float hp;
        public Player(Vector2 position, GameDevice gameDevice, IGameObjectMediator mediator)
               : base("Player1", position, 32, 32, gameDevice)
        {
            velocity = Vector2.Zero;
            this.mediator = mediator;
            slideModify = Vector2.Zero;
            yVectol=0.1f;
            xVectol=2f;
            ySpeedMax=8;
            xSpeedMax=8;
            gool = false;
            //motion = new Motion();
            //for (int i = 0; i < 2; i++)
            //{
            //    motion.Add(i, new Rectangle(32, 32 * (i / 2), 32, 32));
            //}
            //motion.Initialize(new Range(0, 1), new CountDownTimer(1.0f));
        }
        public Player(Player other)
            : this(other.position, other.gameDevice, other.mediator)
        { }
        public override object Clone()
        {
            return new Player(this);
        }
        public override void Hit(GameObject gameObject)
        {

        }
        public override void Updata(GameTime gameTime)
        {
            if (!Input.GetKeyState(Keys.Space))
                velocity.Y -= yVectol;
            else
            {
                velocity.Y += yVectol;
                velocity.X += 0.1f;
                hp -= 10;
            }
            if (Input.IsKeyUp(Keys.Space))
                velocity.X += xVectol;
            velocity.Y = (ySpeedMax < velocity.Y) ? ySpeedMax : velocity.Y;
            velocity.X = (xSpeedMax < velocity.X) ? xSpeedMax : velocity.X;
            position = position + velocity;
            if (velocity.X >= 0)
                velocity.X -= 0.1f;
            setDisplayModify();
            hp -= 1;
            //UpdateMotion();
        }
        private void hitBlock(GameObject gameObject)
        {
            Direction dir = CheckDirection(gameObject);
            if (dir == Direction.Top)
            {
                position.Y = gameObject.getRectangle().Top - height;
            }
            else if (dir == Direction.Right)
            {
                position.X = gameObject.getRectangle().Right;
            }
            else if (dir == Direction.Left)
            {
                position.X = gameObject.getRectangle().Left - width;
            }
            else if (dir == Direction.Bottom)
            {
                position.Y = gameObject.getRectangle().Bottom;
            }
            setDisplayModify();
        }
        private void setDisplayModify()
        {
            gameDevice.SetDisplayMobilify(new Vector2(-position.X + (Screen.Width / 2 - width / 2), 0.0f));
            if (position.X < Screen.Width / 2 - width / 2)
            {
                gameDevice.SetDisplayMobilify(Vector2.Zero);
            }
            if (position.X > mediator.MapX() * width - Screen.Width / 2 - width / 2)
            {
                gameDevice.SetDisplayMobilify(new Vector2(-mediator.MapX() * width + Screen.Width, 0));
            }
        }
        public override void Draw(Renderer renderer)
        {
            renderer.DrawTexture(name, position/*,motion.DrawingRange()*/);
        }
        private void UpdateMotion()
        {
            Vector2 velocity = Input.Velocity();
            if (velocity.Length() <= 0.0f)
            { return; }
            else if (velocity.X > 0.0f)
            {
                motion.Initialize(new Range(0, 0), new CountDownTimer());
            }
            else if (velocity.X < 0.0f)
            {
                motion.Initialize(new Range(1, 1), new CountDownTimer());
            }
        }
    }
}