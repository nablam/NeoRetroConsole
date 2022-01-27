using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBallSimple : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        MyEventsManager.Call_BallCollided(coll);
    }
}
