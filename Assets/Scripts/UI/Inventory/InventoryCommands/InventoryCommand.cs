public interface InventoryCommand
{
    string CommandName { get; }
    void Execute();
    bool CanBeExecuted();
}
