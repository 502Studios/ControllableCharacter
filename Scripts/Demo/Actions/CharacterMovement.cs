using UnityEngine;

namespace net.fiveotwo.controllableCharacter
{
    public class CharacterMovement : CharacterAction
    {
        [SerializeField]
        protected float groundDamping;
        [SerializeField]
        protected float inAirDamping;
        [SerializeField]
        protected float moveSpeed;
        protected Vector2 velocity;
        protected Vector2 normalizedSpeed;
        protected float smoothedMovementFactor;
        protected Axis2D input;

        public override void Initialization()
        {
            input = controllableCharacter.GetInputModule().Get2DAxis("leftStick");
        }

        public override void UpdateAction()
        {
            if (!active)
            {
                return;
            }

            normalizedSpeed.x = input.Value().x;

            normalizedSpeed = Vector2.ClampMagnitude(normalizedSpeed, 1);
            smoothedMovementFactor = controllableCharacter.IsGrounded() ? groundDamping : inAirDamping;
            velocity = controllableCharacter.GetVelocity();
            float deltaTime = controllableCharacter.DeltaTime();
            velocity.x = Mathf.Lerp(velocity.x, normalizedSpeed.x * moveSpeed, deltaTime * smoothedMovementFactor);

            velocity.x = controllableCharacter.GetCollisionState().Left && velocity.x < 0 ? 0 : velocity.x;
            velocity.x = controllableCharacter.GetCollisionState().Right && velocity.x > 0 ? 0 : velocity.x;
            controllableCharacter.SetVelocity(velocity);
        }
    }
}