using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRadiusSetter : MonoBehaviour
{
    [SerializeField] private GameplaySettings gameplaySettings;

    private void OnValidate() => SetBallRadius();
    private void Awake() => SetBallRadius();

    private void SetBallRadius()
    {
        transform.localScale = Vector3.one * gameplaySettings.BallRadius;
    }
}
