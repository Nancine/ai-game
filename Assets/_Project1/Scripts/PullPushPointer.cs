using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PullPushPointer : MonoBehaviour
{
    public float affectRadius;
    public float force;

    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var rigidbodies = Physics2D.OverlapCircleAll(mousePos, affectRadius)
            .Select(c => c.GetComponent<Rigidbody2D>())
            .Where(r => r !=null)
            .ToList();

        if (Input.GetMouseButton(0))
        {
            // Push
            foreach (Rigidbody2D rigidbody in rigidbodies)
            {
                var forceDirection = rigidbody.transform.position - mousePos;
                forceDirection.Normalize();
                rigidbody.AddForce(forceDirection * force);
            }
        }
        else if (Input.GetMouseButton(1))
        {
            // Pull
            foreach (Rigidbody2D rigidbody in rigidbodies)
            {
                var forceDirection = rigidbody.transform.position - mousePos;
                forceDirection.Normalize();
                rigidbody.AddForce(forceDirection * -force);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, affectRadius);
        Gizmos.color = Color.white;
    }
}
