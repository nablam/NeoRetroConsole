using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    GameObject P1_DebugOBJ;
    GameObject P2_DebugOBJ;
    GameObject Line_DebugOBJ;
    GameObject Text_DebugOBJ;
    TextMeshPro P1_Debug;
    TextMeshPro P2_Debug;
    TextMeshPro Line_Debug;
    TextMeshPro Text_Debug;

    private void OnEnable()
    {
        AnalogJoyHandler.ButtonPress += HeardButtonClic;
    }

    private void OnDisable()
    {
        AnalogJoyHandler.ButtonPress -= HeardButtonClic;
    }

    void HeardButtonClic(int argbutton)
    {
        Set_TextDebug("eard button " + argbutton);
    }
    void Start()
    {
        P1_DebugOBJ= this.gameObject.transform.GetChild(0).gameObject;
        P2_DebugOBJ = this.gameObject.transform.GetChild(1).gameObject;
        Line_DebugOBJ = this.gameObject.transform.GetChild(2).gameObject;
        Text_DebugOBJ = this.gameObject.transform.GetChild(3).gameObject;

        P1_Debug = P1_DebugOBJ.GetComponent<TextMeshPro>();
        P2_Debug = P2_DebugOBJ.GetComponent<TextMeshPro>();
        Line_Debug = Line_DebugOBJ.GetComponent<TextMeshPro>();
        Text_Debug = Text_DebugOBJ.GetComponent<TextMeshPro>();
        //Debug.Log(this.gameObject.transform.GetChild(0).gameObject.name);
        //Debug.Log(this.gameObject.transform.GetChild(1).gameObject.name);
        //Debug.Log(this.gameObject.transform.GetChild(2).gameObject.name);
        //Debug.Log(this.gameObject.transform.GetChild(3).gameObject.name);
    }
    public void Set_P1Debug(string argstr) { P1_Debug.text = argstr; }
    public void Set_P2Debug(string argstr) { P2_Debug.text = argstr; }
    public void Set_LineDebug(string argstr) { Line_Debug.text = argstr; }
    public void Set_TextDebug(string argstr) { Text_Debug.text += "\n"+ argstr; }
    // Update is called once per frame
    void Update()
    {
        mouseCursorSpeed = AnalogJoyHandler.Instance.GetP1Potval() / Time.deltaTime;

        //P1_Debug.text = "p1";
        //P2_Debug.text = "p2";
        //Line_Debug.text = "line";
        //Text_Debug.text = "text \n text \n text";

        //Set_P1Debug(AnalogJoyHandler.Instance.GetP1Potval().ToString());

        if (mouseCursorSpeed > best) {
            best = mouseCursorSpeed;
        }
        Set_P1Debug(best.ToString());
        // Set_P2Debug(AnalogJoyHandler.Instance.GetP2Potval().ToString());
        Set_P2Debug(mouseCursorSpeed.ToString()) ;


    }
    float mouseCursorSpeed;
    float best;
 

public Rigidbody2D p2rb;
}
