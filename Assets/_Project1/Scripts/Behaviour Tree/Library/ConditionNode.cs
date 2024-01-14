public class ConditionNode : Node
{
    public delegate bool Condition();

    private readonly Condition _condition;

    public ConditionNode(Condition condition) => _condition = condition;

    public override NodeState Evaluate() => _condition() ? NodeState.Success : NodeState.Failure;
}