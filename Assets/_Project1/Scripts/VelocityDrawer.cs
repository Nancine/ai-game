using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityDrawer : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying)
            return;
            
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, _rb.velocity);
        Gizmos.color = Color.white;
    }
}
