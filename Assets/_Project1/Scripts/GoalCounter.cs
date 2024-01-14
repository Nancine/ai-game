using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GoalCounter : MonoBehaviour
{
   [SerializeField, Min(0)] private int startingValue;
   [SerializeField, Min(0)] private int currentValue;
   [SerializeField] private TMP_Text text;

    public int CurrentValue => currentValue;
    private void OnValidate()
    {
        text.text = currentValue.ToString();
    }
   private void Start() => ResetCounter();

    public void Increment()
    {
        currentValue++;
        text.text = currentValue.ToString();
    }

    [ContextMenu(nameof(ResetCounter))]

    public void ResetCounter()
    {
        currentValue = startingValue;
        text.text = currentValue.ToString();
    }
}
