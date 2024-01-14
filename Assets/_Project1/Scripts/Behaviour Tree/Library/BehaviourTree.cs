
using UnityEngine;

public abstract class BehaviourTree : MonoBehaviour
{
    protected INode _root = null;
    private void Start() => _root = SetupTree();

    protected abstract INode SetupTree();
}
