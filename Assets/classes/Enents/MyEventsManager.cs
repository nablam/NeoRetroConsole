using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEventsManager : MonoBehaviour
{
    public static MyEventsManager Instance = null;
    private void Awake()
    {
        // Debug.Log("GAME eventMANAGER Awake");

        //  FindObjectOfType<cursorkiller>().ShouldIkillCursor();
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    #region Events
  
    public delegate void BallCollidedEVENT(Collision2D argcoll);
    public static event BallCollidedEVENT OnBallCollided;
    public static void Call_BallCollided(Collision2D argcoll)
    {
        if (OnBallCollided != null) OnBallCollided(argcoll);
    }

    #endregion
}
