namespace net.fiveotwo.controllableCharacter
{
    using UnityEngine;

    [RequireComponent(typeof(ControllableCharacter))]
    public abstract class ControllerInputModule : MonoBehaviour
    {
        public AnalogAxis2D leftStick, rightStick;
        public DigitalAxis2D dpad;
        public Button action1, action2, action3, action4, action5;
        public AnalogAxis leftTrigger, rightTrigger;
        public Button leftBumper, rightBumper;

        private void Awake()
        {
            GetComponent<ControllableCharacter>().SetInputModule(this);
        }
    }
}