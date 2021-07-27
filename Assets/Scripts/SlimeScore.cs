using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScore
{ 
    private int score = 0;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    private int distanceTraveled = 0;
    public int DistanceTraveled
    {
        get { return distanceTraveled; }
        set { distanceTraveled = value; }
    }


    private int distanceInHeight = 0;
    public int DistanceInHeight 
    { 
        get { return distanceInHeight; } 
        set { distanceInHeight = value; } 
    }

    public int obstaclesHit = 0;
    public int ObstacalesHit
    {
        get { return obstaclesHit; }
        set { obstaclesHit = value; }
    }

    public int moneyCollected = 0;
    public int MoneyCollected
    {
        get { return moneyCollected; }
        set { moneyCollected = value; }
    }

    public int slimeCollected = 0;
    public int SlimeCollected
    {
        get { return slimeCollected; }
        set { slimeCollected = value; }
    }

    public void ResetScores()
    {
        score = 0;
        distanceInHeight = 0;
        distanceTraveled = 0;
        moneyCollected = 0;
        slimeCollected = 0;
        obstaclesHit = 0;
    }
}
