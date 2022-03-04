using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int currentScore;
   

    // Start is called before the first frame update
    void Start()
    {
        ResetCurrentScore();    
    }

    public int GetCurrentScore() => currentScore;

    public void ResetCurrentScore()
    {
        currentScore = 0;
    
    }

    public void ModifyCurrentScore(int delta) 
    {
        currentScore += delta;
        Mathf.Clamp(currentScore, 0, int.MaxValue);
    }

}
