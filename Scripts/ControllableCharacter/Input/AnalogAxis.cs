namespace net.fiveotwo.controllableCharacter
{
    public class AnalogAxis
    {
        public delegate float Axis();
        public Axis onAxisChange;

        public float Value()
        {
            return onAxisChange != null ? onAxisChange() : 0;
        }
    }
}