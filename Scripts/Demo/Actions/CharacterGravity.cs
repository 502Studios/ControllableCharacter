using UnityEngine;

namespace net.fiveotwo.controllableCharacter
{
    public class CharacterGravity : CharacterAction
    {
        [SerializeField]
        protected float gravity;
        protected Vector2 velocity;

        public override void EarlyUpdateAction()
        {
            velocity = controllableCharacter.GetVelocity();
            if (controllableCharacter.IsGrounded())
            {
                velocity.y = 0;
            }
            controllableCharacter.SetVelocity(velocity);
        }

        public override void UpdateAction()
        {
            velocity = controllableCharacter.GetVelocity();
            velocity.y -= gravity * controllableCharacter.DeltaTime();
            controllableCharacter.SetVelocity(velocity);
        }
    }
}