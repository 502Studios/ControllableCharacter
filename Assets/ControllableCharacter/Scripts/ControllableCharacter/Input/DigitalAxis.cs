namespace net.fiveotwo.controllableCharacter
{
    public class DigitalAxis
    {
        private readonly Button negative, positive;

        public DigitalAxis(Button negative, Button positive)
        {
            this.negative = negative;
            this.positive = positive;
        }

        public int Value()
        {
            if (negative != null && negative.IsPressed())
            {
                return -1;
            } else if (positive != null && positive.IsPressed())
            {
                return 1;
            }

            return 0;
        }

        public Button Negative()
        {
            return negative;
        }

        public Button Positive()
        {
            return positive;
        }
    }
}