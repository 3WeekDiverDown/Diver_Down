using Diver_Down.Device;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diver_Down.Actor.Blocks
{
    class GoalBlock : GameObject
    {
        private bool isGoalFlag = false;

        public GoalBlock(Vector2 pos, GameDevice gameDevice)
            : base("", pos, 64, 64, gameDevice)
        { }
        public GoalBlock(GoalBlock other)
            : this(other.position, other.gameDevice)
        { }
        public override object Clone()
        {
            return new GoalBlock(this);
        }

        public override void Hit(GameObject gameObject)
        {
            if(gameObject is Player)
            {
                isGoalFlag = true;
            }
        }

        public override void Updata(GameTime gameTime)
        {

        }

        public bool IsGoal()
        {
            return isGoalFlag;
        }
    }
}