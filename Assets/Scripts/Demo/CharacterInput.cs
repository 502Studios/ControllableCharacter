
using UnityEngine;

namespace net.fiveotwo.controllableCharacter
{
    public class CharacterInput : ControllerInputModule
    {
        private void Start()
        {
            AnalogAxis horizontal = new AnalogAxis();
            horizontal.onAxisChange += HorizontalAxis;
            AnalogAxis vertical = new AnalogAxis();
            vertical.onAxisChange += VerticalAxis;
            leftStick = new AnalogAxis2D(horizontal, vertical);

            action1 = new Button();
            action1.onButtonDown += OnButtonDown;
            action1.onButtonUp += OnButtonUp;
            action1.onButtonPress += OnButtonPressed;

            action2 = new Button();
            action2.onButtonDown += () => Input.GetKeyDown(KeyCode.K);
            action2.onButtonUp += () => Input.GetKeyUp(KeyCode.K);
            action2.onButtonPress += () => Input.GetKey(KeyCode.K);
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