using UnityEngine;

public class Walls : MonoBehaviour
{
    [field: SerializeField] public float SideWalls { get; private set; }
    [field: SerializeField] public float TopBotWalls { get; private set; }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(SideWalls, TopBotWalls, 0));
        Gizmos.color = Color.white;
    }
}