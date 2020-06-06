using net.fiveotwo.controllableCharacter;
using UnityEngine;

namespace net.fiveotwo.demo.controllableCharacter
{
    public class CharacterInput : ControllerInputModule
    {
        public Axis2D movementAxis;
        public override void ConfigureInputs()
        {
            Axis horizontal = new Axis();
            horizontal.onAxisChange += HorizontalAxis;
            Axis vertical = new Axis();
            vertical.onAxisChange += VerticalAxis;
            Axis2D leftStick = new Axis2D(horizontal, vertical);
            AddInput("leftStick", leftStick);

            Button attack = new Button();
            attack.onButtonDown += OnButtonDown;
            attack.onButtonUp += OnButtonUp;
            attack.onButtonPress += OnButtonPressed;
            AddInput("attack", attack);

            Button jump = new Button();
            jump.onButtonDown += () => Input.GetKeyDown(KeyCode.K);
            jump.onButtonUp += () => Input.GetKeyUp(KeyCode.K);
            jump.onButtonPress += () => Input.GetKey(KeyCode.K);
            AddInput("jump", jump);
        }

        private bool OnButtonDown() {
            return Input.GetKeyDown(KeyCode.J);
        }

        private bool OnButtonUp()
        {
            return Input.GetKeyUp(KeyCode.J);
        }

        private bool OnButtonPressed()
        {
            return Input.GetKey(KeyCode.J);
        }

        private float HorizontalAxis()
        {
            return Input.GetAxis("Horizontal");
        }

        private float VerticalAxis()
        {
            return Input.GetAxis("Vertical");
        }
    }
}