using UnityEngine;
using UnityEngine.Events;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private GoalCounter leftGoalCounter;
    [SerializeField] private GoalCounter rightGoalCounter;
    
    public UnityEvent<Goals> OnGoalScored;

    public void HandleGoalScored()
    {
        int leftGoals = leftGoalCounter.CurrentValue;
        int rightGoals = rightGoalCounter.CurrentValue;
        
        OnGoalScored?.Invoke(new Goals(leftGoals, rightGoals));
    }
}