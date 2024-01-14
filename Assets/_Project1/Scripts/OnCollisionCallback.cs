using UnityEngine;
using UnityEngine.Events;

public class OnCollisionCallback : MonoBehaviour
{
    public UnityEvent<Collision2D> CollisionEnter2D;
    
    private void OnCollisionEnter2D(Collision2D other) => CollisionEnter2D?.Invoke(other);
}