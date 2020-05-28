namespace net.fiveotwo.controllableCharacter
{
    using System;

    public class Button
    {
        private readonly Func<bool> buttonPressed;
        private readonly Func<bool> buttonDown;
        private readonly Func<bool> buttonUp;

        public Button(Func<bool> buttonDown, Func<bool> buttonPressed, Func<bool> buttonUp)
        {
            this.buttonDown = buttonDown;
            this.buttonPressed = buttonPressed;
            this.buttonUp = buttonUp;
        }

        public bool WasPressed()
        {
            return buttonDown != null ? buttonDown() : false;
        }

        public bool WasReleased()
        {
            return buttonUp != null ? buttonUp() : false;
        }

        public bool IsPressed()
        {
            return buttonPressed != null ? buttonPressed() : false;
        }
    }
}