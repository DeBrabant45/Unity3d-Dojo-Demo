using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.StateMachine.AI
{
    public class BlockAction : AIAction
    {
        public override void Act(AIStateController controller)
        {
            //if (!controller.Animations.AnimatorService.GetAnimationBool("IsInteracting"))
            //{
            //    Block(controller);
            //}
        }

        private void Block(AIStateController controller)
        {
            controller.Animations.AnimatorService.SetBoolForAnimation(controller.Combat.Weapon.BlockStanceAnimation, true);
        }
    }
}
