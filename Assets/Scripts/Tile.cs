using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Tile : MonoBehaviour
{
   public GameObject Titlebox;
    public GameObject HighLight;
    public bool _isGameTile;
    public bool IsGameTile { get => _isGameTile;private set => _isGameTile = value; }

    public void Showme(bool onoff) {
       // Debug.Log(" hi " + Titlebox.GetComponent<TextMeshPro>().text + " " + onoff.ToString());
        HighLight.SetActive(onoff);
        this.gameObject.SetActive(onoff);
    }
    public void HighLightMe(bool onoff) { HighLight.SetActive(onoff); }

    void Awake()
    {
    
        if (this.gameObject.transform.GetChild(0).gameObject.transform.childCount >0)
        {
            _isGameTile = true;
        }
        else
        {
            _isGameTile = false;
        }
        Titlebox = this.gameObject.transform.GetChild(0).gameObject;
        HighLight = this.gameObject.transform.GetChild(1).gameObject;
    }
   
}
