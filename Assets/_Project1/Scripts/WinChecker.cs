using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinChecker : MonoBehaviour
{
    [SerializeField] private GameplaySettings gameplaySettings;
    public UnityEvent<string> OnWin;

    public void OnGoalScored(Goals goals)
    {
        var result = CheckForWin(goals.Left, goals.Right);
        
        if (result == Result.None)
            return;

        switch (result)
        {
            case Result.LeftWins:
                OnWin?.Invoke("Left wins!");
                break;
            case Result.RightWins:
                OnWin?.Invoke("Right wins!");
                break;
        }
    }

    private Result CheckForWin(int leftGoals, int rightGoals) 
    {
        if(leftGoals >= gameplaySettings.ScoreRequirement)
        {
            if (leftGoals >= rightGoals + 2)
                return Result.LeftWins;


        }

        if(rightGoals >= gameplaySettings.ScoreRequirement)
        {
            if (rightGoals >= leftGoals + 2)
                return Result.RightWins;
        }

        return Result.None;
    }

    public enum Result
    {
        None,
        LeftWins,
        RightWins,
    }
}
