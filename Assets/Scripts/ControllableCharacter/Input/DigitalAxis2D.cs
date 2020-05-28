namespace net.fiveotwo.controllableCharacter
{
    using UnityEngine;

    public class DigitalAxis2D
    {
        private readonly DigitalAxis axisX, axisY;

        public DigitalAxis2D(DigitalAxis axisX, DigitalAxis axisY)
        {
            this.axisX = axisX;
            this.axisY = axisY;
        }

        public Vector2Int Value()
        {
            return new Vector2Int(axisX != null ? axisX.Value() : 0, axisY != null ? axisY.Value() : 0);
        }

        public DigitalAxis AxisX()
        {
            return axisX;
        }

        public DigitalAxis AxisY()
        {
            return axisY;
        }
    }
}