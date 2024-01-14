public class Wait : INode
{
    private readonly float _duration;
    private float _timer;

    public Wait(float duration)
    {
        _duration = duration;
    }

    public NodeState Evaluate()
    {
        _timer += UnityEngine.Time.deltaTime;
        return _timer >= _duration ? NodeState.Success : NodeState.Running;
    }
}