namespace net.fiveotwo.controllableCharacter
{
    using UnityEngine;

    public class AnalogAxis2D
    {
        private readonly AnalogAxis axisX, axisY;

        public AnalogAxis2D(AnalogAxis axisX, AnalogAxis axisY)
        {
            this.axisX = axisX;
            this.axisY = axisY;
        }

        public Vector2 Value()
        {
            return new Vector2(axisX != null ? axisX.Value() : 0, axisY != null ? axisY.Value() : 0);
        }
    }
}