public class CharacterStateMachine
{
    private int currentState;
    private int previousState;

    public CharacterStateMachine()
    {
        currentState = previousState = 0;
    }

    public void SetState(int state)
    {
        previousState = currentState;
        currentState = state;
    }

    public int GetCurrentState()
    {
        return currentState;
    }

    public int GetPreviousState()
    {
        return previousState;
    }

    public void RestorePreviousState()
    {
        currentState = previousState;
    }
}
