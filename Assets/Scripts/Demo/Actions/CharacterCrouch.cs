using net.fiveotwo.characterController;
using UnityEngine;

namespace net.fiveotwo.controllableCharacter
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class CharacterCrouch : CharacterAction
    {
        [SerializeField]
        protected Vector2 crouchedSize;
        [SerializeField]
        protected Vector2 crouchedOffset;
        private Vector2 defaultOffset;
        private Vector2 defaultSize;
        private BoxCollider2D boxCollider2D;
        private Controller2D characterController2D;
        protected ControllerInputModule input;

        private void Start()
        {
            input = controllableCharacter.InputModule();
            boxCollider2D = GetComponent<BoxCollider2D>();
            characterController2D = GetComponent<Controller2D>();
            defaultSize = boxCollider2D.size;
            defaultOffset = boxCollider2D.offset;
        }

        public override void UpdateAction()
        {
            if (!active)
            {
                return;
            }

            if (input.leftStick.Value().y < 0 && controllableCharacter.CharacterStateMachine().Equals((int)CharacterState.grounded))
            {
                boxCollider2D.size = crouchedSize;
                boxCollider2D.offset = crouchedOffset;
                characterController2D.UpdateCollisionBoundaries();
                controllableCharacter.CharacterStateMachine().SetState((int)CharacterState.crouching);
            }
        }
    }
}