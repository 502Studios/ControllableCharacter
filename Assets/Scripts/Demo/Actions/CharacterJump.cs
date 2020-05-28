namespace net.fiveotwo.controllableCharacter
{
    using UnityEngine;

    public class CharacterJump : CharacterAction
    {
        [SerializeField]
        protected int gravity;
        [SerializeField]
        protected int coyoteTime;
        [SerializeField]
        protected int maxJumps;
        [SerializeField]
        protected float jumpHeight;
        protected int jumpsLeft = 0;
        protected bool canJump;
        protected int lastFrame;
        protected Vector2 velocity;
        protected ControllerInputModule input;

        private void Start()
        {
            input = controllableCharacter.InputModule();
        }

        public override void LateUpdateAction()
        {
            if (!active)
            {
                return;
            }

            if (controllableCharacter.IsGrounded())
            {
                jumpsLeft = 0;
                lastFrame = Time.frameCount;
                canJump = true;
                controllableCharacter.CharacterStateMachine().SetState((int)CharacterState.grounded);
            } else if (!controllableCharacter.IsGrounded())
            {
                if (Time.frameCount - lastFrame > coyoteTime)
                {
                    canJump = false;
                }
            }
            if (input.action2.WasPressed())
            {
                PerformJump();
            }
        }

        void PerformJump()
        {
            if (CanJump())
            {
                jumpsLeft++;
                canJump = false;
                velocity = controllableCharacter.GetVelocity();
                velocity.y = 0;
                controllableCharacter.SetVelocity(velocity);
                velocity.y = Mathf.Sqrt(2f * (jumpHeight) * gravity);
                controllableCharacter.SetVelocity(velocity);
                controllableCharacter.CharacterStateMachine().SetState((int)CharacterState.jumping);
            }
        }

        public bool CanJump()
        {
            return canJump || jumpsLeft < maxJumps;
        }
    }
}