namespace Notebook.Action
{
    public interface IAction
    {
        string Name { get; }
        void Run();
    }
}