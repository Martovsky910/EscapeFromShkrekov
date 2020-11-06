public abstract class EnemyState
{
    protected EnemySoilder owner;
    protected EnemyDebugger debugger;
    public EnemyState(EnemySoilder owner, EnemyDebugger debugger)
    {
        this.owner = owner;
        this.debugger = debugger;
    }
    public abstract void OnUpdate();
}
