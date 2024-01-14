using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gameplay Settings", menuName = "Gameplay Settings")]
public class GameplaySettings : ScriptableObject
{
   [field: SerializeField] public float BallRadius { get; private set; }
   [field: SerializeField] public float MidBarrierWidth { get; private set; }
   [field: SerializeField] public int ScoreRequirement { get; private set; }
}
