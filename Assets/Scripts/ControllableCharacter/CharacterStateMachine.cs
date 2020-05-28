public class CharacterStateMachine
{
    private int currentState;
    private int previousState;

    public CharacterStateMachine(int state)
    {
        currentState = previousState = state;
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
