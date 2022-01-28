//using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//[ExecuteInEditMode]
public class SpaceInvadersMinigame : BaseMinigame
{
    public GameObject TheRootEnemy;
    public GameObject Bullet1;
    public GameObject Bullet2;
    public Transform GunPoint_1;
    public Transform GunPoint_2;
    SpaceBulletSimple b1;
    SpaceBulletSimple b2;
    //[TypeConstraint(typeof(IEnemySimple))]

    //  [CustomPropertyDrawer(typeof(IEnemySimple))]
    // [SerializeReference]
    public List<SpaceBaddySimple> ListofEnemies;
    float speed = 3.0f;
    Vector3 _curDirection;
    int hitcount = 0;

    // Start is called before the first frame update
    public override void UpdatePlayers()
    {
        P1Obj.transform.position = new Vector3(7 * AnalogJoyHandler.Instance.GetP1Potval(), P1Obj.transform.position.y,  P1Obj.transform.position.z);
        P2Obj.transform.position = new Vector3(7 * AnalogJoyHandler.Instance.GetP2Potval(),P2Obj.transform.position.y, P2Obj.transform.position.z);
        if (Input.GetKey(KeyCode.A)) { b1.StartMove(); }

        if (Input.GetKey(KeyCode.Q)) { b1.RestPlace(); }
    }

    public override void UpdateNPC()
    {
        Debug.DrawRay(TheRootEnemy.transform.position, _curDirection * speed * 2, Color.red);
       // TheRootEnemy.transform.position += _curDirection * speed * Time.deltaTime;
    }


    private void OnEnable()
    {
        MyEventsManager.OnBallCollided += DEtectCollisionEnter;
        MyEventsManager.OnEnemyTriggered += DetctEnemyDied;
        AnalogJoyHandler.ButtonPress += HeardButtonClic;
        // ListofEnemies = new List<IEnemySimple>();

    }
    private void OnDisable()
    {
        MyEventsManager.OnBallCollided -= DEtectCollisionEnter;
        MyEventsManager.OnEnemyTriggered -= DetctEnemyDied;
        AnalogJoyHandler.ButtonPress -= HeardButtonClic;
    }

  

    void HeardButtonClic(int argbutton)
    {
        Debug.Log("gamemanager heard PEW");
        if (argbutton == 0)
        {
            b1.StartMove();


        }
        if (argbutton == 2)
        {
            b2.StartMove();
        }
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
                GunPoint_1 = P1Obj.transform.GetChild(0);
            }
            else
                 if (this.transform.GetChild(i).gameObject.CompareTag("P2"))
            {

                P2Obj = this.transform.GetChild(i).gameObject;
                GunPoint_2 = P2Obj.transform.GetChild(0);
            }
            else
                 if (this.transform.GetChild(i).gameObject.CompareTag("NPC"))
            {
                TheRootEnemy = this.transform.GetChild(i).gameObject;
            }
            else
                 if (this.transform.GetChild(i).gameObject.CompareTag("Bullet_P1"))
            {
                Bullet1 = this.transform.GetChild(i).gameObject;
                b1 = Bullet1.GetComponent<SpaceBulletSimple>();
            }
            else
                 if (this.transform.GetChild(i).gameObject.CompareTag("Bullet_P2"))
            {
                Bullet2 = this.transform.GetChild(i).gameObject;
                b2 = Bullet2.GetComponent<SpaceBulletSimple>();
            }

        }

        b1.SetBselocationTrans(GunPoint_1);
        b2.SetBselocationTrans(GunPoint_2);
        b1.RestPlace();
        b2.RestPlace();
       // b1.Showme(false);
       // b2.Showme(false);

        ListofEnemies = TheRootEnemy.transform.GetComponentsInChildren<SpaceBaddySimple>().ToList();
        for (int eId = 0; eId < ListofEnemies.Count; eId++) {

            ListofEnemies[eId].SetPositive_Getnegative_ID(eId);
        }

        //for (int eId = 0; eId < ListofEnemies.Count; eId++)
        //{

        //  Debug.Log(  ListofEnemies[eId].SetPositive_Getnegative_ID(-999));
        //}

        _curDirection = new Vector3(1.0f, 0.5f, 0.0f).normalized;
    }



    public void DEtectCollisionEnter(Collision2D coll)
    {
        // Debug.Log("BALL hit " + coll.collider.gameObject.name);
        Debug.DrawRay(coll.contacts[0].point, coll.contacts[0].normal, Color.green, 2, false);
        Vector2 inNormal = coll.contacts[0].normal;
        Vector2 newDirection = Vector2.Reflect(_curDirection, inNormal);
        _curDirection = newDirection;
        Debug.DrawRay(coll.contacts[0].point, newDirection, Color.magenta, 2, false);
        if (coll.collider.CompareTag("P1") || coll.collider.CompareTag("P2"))
        {

        }
    }

    public void DetctEnemyDied(Collider2D argCol, int argidD) {


        if (argCol.gameObject.CompareTag("Bullet_P1"))
        {
           // Debug.Log("yo baddy id " + argidD + "collided 1 ");
            b1.RestPlace();
        }
        if (argCol.gameObject.CompareTag("Bullet_P2"))
        {
            // Debug.Log("yo baddy id " + argidD + "collided 2");
            b2.RestPlace();
        }
        ListofEnemies[argidD].Activeateme(false);
    }
}
