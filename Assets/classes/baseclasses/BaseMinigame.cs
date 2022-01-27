#define ENABLE_LOGS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//#define  ENABLE_DEBUGLOG
//[RequireComponent(typeof(la))]
public class BaseMinigame : MonoBehaviour , Iminigame
{
  public  GameObject P1Obj;
    public GameObject P2Obj;

    #region ImplementImini
    public virtual void UpdateNPC()
    {
        throw new System.NotImplementedException();
    }

    public virtual void UpdatePlayers()
    {
        throw new System.NotImplementedException();
    }
    #endregion

    public virtual void FindMyObjects()
    {
        Debug.Log("base findmyobjs");
        //virtual overriden by diff types of minigames 
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

        }
    }

    #region Mono


    void Awake() {
    
    }
     
    void Start()
    {
        FindMyObjects();


    }

     
    void FixedUpdate()
    {
        UpdatePlayers();
        UpdateNPC();
    }
    #endregion
}
