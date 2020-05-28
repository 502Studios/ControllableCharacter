
using UnityEngine;

namespace net.fiveotwo.controllableCharacter
{
    public class CharacterInput : ControllerInputModule
    {
        private void Start()
        {
            AnalogAxis horizontal = new AnalogAxis(() => Input.GetAxis("Horizontal"));
            AnalogAxis vertical = new AnalogAxis(() => Input.GetAxis("Vertical"));
            leftStick = new AnalogAxis2D(horizontal, vertical);

            action1 = new Button(() => Input.GetKeyDown(KeyCode.J), () => Input.GetKey(KeyCode.J), () => Input.GetKeyUp(KeyCode.J));
            action2 = new Button(() => Input.GetKeyDown(KeyCode.K), () => Input.GetKey(KeyCode.K), () => Input.GetKeyUp(KeyCode.K));
        }
    }
}