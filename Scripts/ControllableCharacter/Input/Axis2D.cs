using UnityEngine;

namespace net.fiveotwo.controllableCharacter
{
    public class Axis2D
    {
        private readonly Axis axisX, axisY;

        public Axis2D(Axis axisX, Axis axisY)
        {
            this.axisX = axisX;
            this.axisY = axisY;
        }

        public Vector2 Value()
        {
            return new Vector2(axisX != null ? axisX.Value() : 0f, axisY != null ? axisY.Value() : 0f);
        }
    }
}