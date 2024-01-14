

using System;
using UnityEngine;
using System.Collections.Generic;

public class PaddleBehaviourTree : BehaviourTree
{
    [SerializeField] private Paddle paddle;
    [SerializeField] private Transform puckPosition;
    [SerializeField] private Rigidbody2D puckRigidbody;
    [SerializeField] private Transform leftGoalPosition;
    [SerializeField] private Transform rightGoalPosition;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float threshold;

    protected override INode SetupTree()
    {
        var blackboard = new Blackboard();
        
        return new Sequence()
        {
            Children = new List<INode>()
            {
                new PredictPuckPosition(() => puckPosition.position, () => puckRigidbody.velocity, 1f, blackboard),
                new FindTargetPosition(() => (Vector2)blackboard["PuckPrediction"], leftGoalPosition, rightGoalPosition, 1.5f, paddle.Team, blackboard),
                new MovePaddleToPosition(paddle, () => (Vector2)blackboard["TargetPosition"], Mathf.Abs(threshold), moveSpeed),
                new Wait(2),
            }
        };

    }

    private void FixedUpdate()
    {
        _root.Evaluate();
    }
}

public class Blackboard : Dictionary<string, object> {}

public class PredictPuckPosition : Node
{
    public PredictPuckPosition(Func<Vector2> puckPosition, Func<Vector2> puckVelocity, float seconds, Blackboard blackboard)
    {
        PuckPosition = puckPosition;
        PuckVelocity = puckVelocity;
        Seconds = seconds;
        Blackboard = blackboard;
    }

    public Func<Vector2> PuckPosition { get; private set; }
    public Func<Vector2> PuckVelocity { get; private set; }
    public float Seconds { get; private set; }
    public Blackboard Blackboard { get; private set;}

    public override NodeState Evaluate()
    {
        Vector2 prediction = PuckPosition() + PuckVelocity() * Seconds;
        Blackboard["PuckPrediction"] = prediction;
        return NodeState.Success;
    }
}

public class FindTargetPosition : Node
{
    public FindTargetPosition(Func<Vector2> puckPrediction, Transform leftGoal, Transform rightGoal, float offsetDistance, Paddle.TeamSide team, Blackboard blackboard)
    {
        PuckPrediction = puckPrediction;
        LeftGoal = leftGoal;
        RightGoal = rightGoal;
        OffsetDistance = offsetDistance;
        Team = team;
        Blackboard = blackboard;
    }

    public Func<Vector2> PuckPrediction { get; }
    public Transform LeftGoal { get; }
    public Transform RightGoal { get; }
    public float OffsetDistance { get; }
    public Paddle.TeamSide Team { get; }
    public Blackboard Blackboard { get; }

    public override NodeState Evaluate()
    {
        Vector2 directionToGoal = Team switch
        {
            Paddle.TeamSide.Left => (Vector2)LeftGoal.position - PuckPrediction(),
            Paddle.TeamSide.Right => (Vector2)RightGoal.position - PuckPrediction(),
            _ => throw new ArgumentOutOfRangeException()
        };

        var offsetDirection = -directionToGoal.normalized;
        var offset = offsetDirection * OffsetDistance;
        var targetPosition = PuckPrediction() + offset;
        Blackboard["TargetPosition"] = targetPosition;
        return NodeState.Success;
    }
}