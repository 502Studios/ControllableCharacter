using UnityEngine;

namespace net.fiveotwo.controllableCharacter
{
    public class CharacterAttack : CharacterAction
    {
        protected ControllerInputModule input;
        protected CharacterAim characterAim;

        public override void Awake()
        {
            base.Awake();
            characterAim = GetComponent<CharacterAim>();
        }

        public override void Initialization()
        {
            input = controllableCharacter.InputModule();
        }

        public override void LateUpdateAction()
        {
            if (!active)
            {
                return;
            }
            Vector2 velocity = controllableCharacter.GetVelocity();
            Vector2 direction = characterAim.AimingDirection();

            if (input.action1.IsPressed())
            {

            }

            if (input.action1.WasPressed())
            {

            }

            if (input.action1.WasReleased())
            {

            }
        }
    }
}
