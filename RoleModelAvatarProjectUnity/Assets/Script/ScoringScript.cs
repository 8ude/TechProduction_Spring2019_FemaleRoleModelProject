using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringScript : MonoBehaviour
{

    public static ScoringScript Instance;

    public int MaleScore;
    public int FemaleScore;

    public float TotalScore;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
    
    public void AddToMaleScore()
    {
        MaleScore += 1;
        TotalScore += 1f;
    }

    public void AddToFemaleScore()
    {
        FemaleScore += 1;
        TotalScore += 1f;
    }

    public void ResetScore()
    {
        FemaleScore = 0;
        MaleScore = 0;
        TotalScore = 0f;
    }

}
