using UnityEngine;

public class MidBarrierWidthSetter : MonoBehaviour
{
    [SerializeField] private GameplaySettings gameplaySettings;

    private void OnValidate() => SetMidBarrierWidth();
    private void Awake() => SetMidBarrierWidth();

    private void SetMidBarrierWidth()
    {
        transform.localScale = new Vector3(
            gameplaySettings.MidBarrierWidth,
            transform.localScale.y,
            transform.localScale.z);
    }
    
}
