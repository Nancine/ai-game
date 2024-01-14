public class Selector : Node
{
    public override NodeState Evaluate()
    {
        foreach (INode child in Children)
        {
            switch (child.Evaluate())
            {
                case NodeState.Success:
                    State = NodeState.Success;
                    return State;
                
                case NodeState.Running:
                    State = NodeState.Running;
                    return State;
                
                default:
                    continue;
            }
        }

        State = NodeState.Failure;
        return State;
    }
}
