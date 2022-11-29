namespace ProjectCore.StateManager
{
    public interface IState
    {
        void StateInit();
        void StateStart(IStateArgs stateArgs = null);
        void StateEnd();
    }
}
