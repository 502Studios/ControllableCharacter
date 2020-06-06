using net.fiveotwo.controllableCharacter;
using UnityEngine;

namespace net.fiveotwo.demo.controllableCharacter
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

        private void Update()
        {
            if (!active)
            {
                return;
            }

            normalizedSpeed.x = input.Value().x;
            velocity = controllableCharacter.GetVelocity();
            normalizedSpeed = Vector2.ClampMagnitude(normalizedSpeed, 1);
            smoothedMovementFactor = controllableCharacter.IsGrounded() ? groundDamping : inAirDamping;
            float deltaTime = controllableCharacter.DeltaTime();
            velocity.x = Mathf.Lerp(velocity.x, normalizedSpeed.x * moveSpeed, deltaTime * smoothedMovementFactor);

            if (controllableCharacter.GetCollisionState().Left || controllableCharacter.GetCollisionState().Right)
            {
                velocity.x = 0;
            }

            controllableCharacter.SetVelocity(velocity);
        }
    }
}