using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine.Player
{
    [CreateAssetMenu(menuName = "StateMachine/Player/Actions/Attack")]
    public class AttackAction : PlayerAction
    {
        private float _attackRateBuffer;

        public override void Act(PlayerStateController controller)
        {
            _attackRateBuffer += Time.deltaTime;
            if(controller.InputFromPlayer.IsPrimaryActionPressed() && !controller.Animations.IsAnimatorBusy())
            {
                if (_attackRateBuffer > .5f)
                {
                    Attack(controller);
                }

            }
        }

        private void Attack(PlayerStateController controller)
        {
            if (controller.BaseStats.Stamina.Amount >= controller.Weapon.AttackStaminaCost)
            {
                SetItemDamage(controller);
                SetAttackSounds(controller);
                _attackRateBuffer = 0;
                controller.Animations.SetTriggerForAnimation(controller.Weapon.AttackTriggerAnimation);
                controller.BaseStats.Stamina.ReduceStamina(controller.Weapon.AttackStaminaCost);
            }
        }

        private void SetAttackSounds(PlayerStateController controller)
        {
            controller.AudioFX.PlayOneShotAtRandomIndex(controller.CharacterVoice.AttackVoices);
            controller.AudioFX.PlayOneShotAtRandomIndex(controller.Weapon.WeaponSounds.SwingSounds);
        }

        private void SetItemDamage(PlayerStateController controller)
        {
            controller.ItemSlot.DamageCollider.SetDamage(controller.Weapon);
            controller.ItemSlot.DamageCollider.SetTagToNotHit(controller);
        }
    }
}