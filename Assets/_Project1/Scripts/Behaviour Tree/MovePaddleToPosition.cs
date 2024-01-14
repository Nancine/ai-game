

using System;
using System.Net.Http.Headers;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovePaddleToPosition : Node
{
    public MovePaddleToPosition(Paddle paddle, Func<Vector2> position, float threshold, float moveSpeed)
    {
        Paddle = paddle;
        Position = position;
        Threshold = threshold;
        MoveSpeed = moveSpeed;
    }
    public Paddle Paddle { get; }
    public Func<Vector2> Position { get; }
    public float Threshold { get; }
    public float MoveSpeed { get; }

    public override NodeState Evaluate()
    {
        var paddlePosition = Paddle.Rigidbody.position;
        var direction = Position() - paddlePosition;

        if (direction.sqrMagnitude > 1f)
            direction.Normalize();

        var newPosition = paddlePosition + direction * MoveSpeed * Time.fixedDeltaTime;

        Paddle.Rigidbody.MovePosition(newPosition);

        if (Paddle.Rigidbody.position.IsWithin(newPosition, Threshold))
            return NodeState.Success;
        
        return NodeState.Running;
    }
}
public static class Vector2Extensions
{
    /// <summary>
    /// Checks if this Vector2 is within a given distance from a given Vector2.
    /// </summary>
    /// <param name="vector">This Vector2.</param>
    /// <param name="radius">Distance.</param>
    /// <param name="origin">Origin.</param>
    /// <returns>True if is within. False if not within.</returns>
    public static bool IsWithin(this Vector2 vector, Vector2 origin, float radius) =>
        (vector - origin).sqrMagnitude < radius * radius;
}