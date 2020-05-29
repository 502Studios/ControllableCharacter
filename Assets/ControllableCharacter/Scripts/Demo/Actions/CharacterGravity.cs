namespace net.fiveotwo.controllableCharacter
{
    using UnityEngine;

    public class CharacterGravity : CharacterAction
    {
        [SerializeField]
        protected float gravity;
        protected Vector2 velocity;

        public override void EarlyUpdateAction()
        {
            if (!active)
            {
                return;
            }

            velocity = controllableCharacter.GetVelocity();
            if (controllableCharacter.IsGrounded())
            {
                velocity.y = 0;
                controllableCharacter.SetVelocity(velocity);
                return;
            }

            velocity.y -= gravity * Time.deltaTime;
            controllableCharacter.SetVelocity(velocity);
        }
    }
}