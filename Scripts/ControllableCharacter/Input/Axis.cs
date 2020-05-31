namespace net.fiveotwo.controllableCharacter
{
    public class Axis
    {
        public delegate float AxisDelegate();
        public AxisDelegate onAxisChange;

        public float Value()
        {
            return onAxisChange != null ? onAxisChange() : 0f;
        }
    }
}