using JetBrains.Annotations;
using System.Collections.Generic;

public interface INode
{
    NodeState Evaluate();
}

public abstract class Node : INode
{
    public  NodeState State { get; set; }
    public INode Parent { get; set; }
    public List<INode> Children { get; set; }
    public abstract NodeState Evaluate();
}
