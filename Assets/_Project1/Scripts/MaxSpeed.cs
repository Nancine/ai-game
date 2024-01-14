using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MaxSpeed : MonoBehaviour
{
    [SerializeField] private float maxSpeed;    
    
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, maxSpeed);
    }
}