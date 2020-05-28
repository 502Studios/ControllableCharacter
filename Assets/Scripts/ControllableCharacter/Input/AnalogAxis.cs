namespace net.fiveotwo.controllableCharacter
{
    using System;

    public class AnalogAxis
    {
        private readonly Func<float> axis;

        public AnalogAxis(Func<float> axis)
        {
            this.axis = axis;
        }

        public float Value()
        {
            return axis != null ? axis() : 0;
        }
    }
}