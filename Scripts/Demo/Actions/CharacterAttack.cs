using UnityEngine;

namespace net.fiveotwo.controllableCharacter
{
    public class CharacterAttack : CharacterAction
    {
        private ControllerInputModule input;
        private CharacterAim characterAim;
        private Button attackInput;

        public override void Awake()
        {
            base.Awake();
            characterAim = GetComponent<CharacterAim>();
        }

        public override void Initialization()
        {
            attackInput = controllableCharacter.GetInputModule().GetButton("attack");
        }

        public override void LateUpdateAction(float deltaTime)
        {
            if (!active)
            {
                return;
            }
            Vector2 velocity = controllableCharacter.GetVelocity();
            Vector2 direction = characterAim.AimingDirection();

            if (attackInput.IsPressed())
            {

            }

            if (attackInput.WasPressed())
            {

            }

            if (attackInput.WasReleased())
            {

            }
        }
    }
}
