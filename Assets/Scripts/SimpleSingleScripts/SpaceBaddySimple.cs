using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[ExecuteInEditMode]

public class SpaceBaddySimple : MonoBehaviour, IEnemySimple
{
    BoxCollider2D _myboxcollider;
    #region Iface
    public int  SetPositive_Getnegative_ID(int argid)
    {
        if (argid > 0) {
            ID = argid;
        }
        return ID;
    }
    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }
    #endregion



    public int ID;
 

   
    void Start()
    {
        _myboxcollider = GetComponent<BoxCollider2D>();

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("yo baddy id " + ID + " OUCH ");

        MyEventsManager.Call_EnemyTriggered(collision, ID);

        //if (collision.gameObject.CompareTag("Bullet_P1")) {
        //    Debug.Log("yo baddy id " + ID + "collided 1 "); 
        //}
        //if (collision.gameObject.CompareTag("Bullet_P2")) {
        //    Debug.Log("yo baddy id " + ID + "collided 2");
        //}
    }

    public void Activeateme(bool argOnOff)
    {
        this.transform.GetChild(0).gameObject.SetActive(argOnOff);
        _myboxcollider.enabled = argOnOff;
      //  throw new System.NotImplementedException();
    }
}

