using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPongMinigame : BaseMinigame
{

    public GameObject TheBallIneed;
    public GameObject TheWallNeeded;
    float speed = 3.0f;
    Vector3 _curDirection;
    int hitcount = 0;

    // Start is called before the first frame update
    public override void UpdatePlayers()
    {
        P1Obj.transform.position = new Vector3(P1Obj.transform.position.x, 6 * AnalogJoyHandler.Instance.GetP1Potval(), P1Obj.transform.position.z);
        P2Obj.transform.position = new Vector3(P2Obj.transform.position.x, 6 * AnalogJoyHandler.Instance.GetP2Potval(), P2Obj.transform.position.z);

    }

    public override void UpdateNPC()
    {
        //  if (rb == null) { Logger.Debug("NORB"); return; }
        // rb.velocity = _curDirection * speed;
        Debug.DrawRay(TheBallIneed.transform.position, _curDirection * speed * 2, Color.red);

        TheBallIneed.transform.position += _curDirection * speed * Time.deltaTime;
    }

    private void OnEnable()
    {
        MyEventsManager.OnBallCollided += DEtectCollisionEnter;

    }
    private void OnDisable()
    {
        MyEventsManager.OnBallCollided -= DEtectCollisionEnter;
    }

 

    public override void FindMyObjects()
    {
        Debug.Log("minipong findmyobjs");
        // throw new System.NotImplementedException();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).gameObject.CompareTag("P1"))
            {
                P1Obj = this.transform.GetChild(i).gameObject;
            }
            else
                 if (this.transform.GetChild(i).gameObject.CompareTag("P2"))
            {

                P2Obj = this.transform.GetChild(i).gameObject;
            }
            else
                 if (this.transform.GetChild(i).gameObject.CompareTag("Ball"))
            {

                TheBallIneed = this.transform.GetChild(i).gameObject;
            }
            else
                 if (this.transform.GetChild(i).gameObject.CompareTag("NPC"))
            {

                TheWallNeeded = this.transform.GetChild(i).gameObject;
            }

        }
        // rb = TheBallIneed.GetComponent<Rigidbody2D>();
        //_curDirection = Vector3.one.normalized;
        _curDirection = new Vector3(1.0f, 0.5f, 0.0f).normalized;
      

    }







    // Update is called once per frame

    public void DEtectCollisionEnter(Collision2D coll)
    {
        Debug.Log("BALL hit " + coll.collider.gameObject.name);



        Debug.DrawRay(coll.contacts[0].point, coll.contacts[0].normal, Color.green, 2, false);


        Vector2 inNormal = coll.contacts[0].normal;
        Vector2 newDirection = Vector2.Reflect(_curDirection, inNormal);


        _curDirection = newDirection;


        Debug.DrawRay(coll.contacts[0].point, newDirection, Color.magenta, 2, false);


        if (coll.collider.CompareTag("P1") || coll.collider.CompareTag("P2"))
        {

        }
    }
}



