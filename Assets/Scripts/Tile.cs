using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Tile : MonoBehaviour
{
    GameObject Titlebox;
    GameObject HighLight;
    public bool _isGameTile;
    public bool IsGameTile { get => _isGameTile;private set => _isGameTile = value; }

    public void Showme(bool onoff) {
        HighLight.SetActive(false);
        this.gameObject.SetActive(onoff);
    }
    public void HighLightMe(bool onoff) { HighLight.SetActive(onoff); }

    void Start()
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
