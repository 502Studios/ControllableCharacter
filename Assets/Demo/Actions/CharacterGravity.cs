using UnityEngine;

namespace net.fiveotwo.controllableCharacter
{
    public class CharacterGravity : CharacterAction
    {
        [SerializeField]
        protected float gravity;
        protected Vector2 velocity;

        public override void EarlyUpdateAction(float deltaTime)
        {
            velocity = controllableCharacter.GetVelocity();
            if (controllableCharacter.IsGrounded())
            {
                velocity.y = 0;
            }
            controllableCharacter.SetVelocity(velocity);
        }

        public override void UpdateAction(float deltaTime)
        {
            velocity = controllableCharacter.GetVelocity();
            velocity.y -= gravity * deltaTime;
            controllableCharacter.SetVelocity(velocity);
        }
    }
}