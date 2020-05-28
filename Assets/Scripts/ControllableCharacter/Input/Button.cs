namespace net.fiveotwo.controllableCharacter
{
    public class Button
    {
        public delegate bool ButtonEvent();
        public ButtonEvent onButtonDown;
        public ButtonEvent onButtonPress;
        public ButtonEvent onButtonUp;

        public bool WasPressed()
        {
            return onButtonDown()? onButtonDown.Invoke() : false;
        }

        public bool WasReleased()
        {
            return onButtonUp() ? onButtonUp.Invoke() : false;
        }

        public bool IsPressed()
        {
            return onButtonPress() ? onButtonPress.Invoke() : false;
        }
    }
}