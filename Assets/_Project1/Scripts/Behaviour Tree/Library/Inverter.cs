public class Inverter : Node
{
    public override NodeState Evaluate()
    {
        switch (Children[0]?.Evaluate())
        {
            case NodeState.Success:
                State = NodeState.Failure;
                return State;
            
            case NodeState.Failure:
                State = NodeState.Success;
                return State;
            
            default:
                State = NodeState.Running;
                return State;
        }
    }
}