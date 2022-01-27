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
     //   P1Obj.transform.position = new Vector3(P1Obj.transform.position.x, 6 * AnalogJoyHandler.Instance.GetP1Potval(), P1Obj.transform.position.z);
      //  P2Obj.transform.position = new Vector3(P2Obj.transform.position.x, 6 * AnalogJoyHandler.Instance.GetP2Potval(), P2Obj.transform.position.z);

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
