public class Sequence : Node
{
    public override NodeState Evaluate()
    {
        bool anyChildIsRunning = false;

        foreach (INode child in Children)
        {
            switch (child.Evaluate())
            {
                case NodeState.Failure:
                    State = NodeState.Failure;
                    return State;

                case NodeState.Success:
                    continue;

                case NodeState.Running:
                    anyChildIsRunning = true;
                    continue;

                    default:
                        State = NodeState.Success;
                        return State;
            }
        }

        State = anyChildIsRunning ? NodeState.Running : NodeState.Success;
        return State;
    }
}
