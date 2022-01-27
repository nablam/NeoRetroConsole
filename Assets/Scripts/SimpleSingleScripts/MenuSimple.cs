using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSimple : MonoBehaviour
{
    int selecedGameIndex = 0;
    public Tile pongTile;
    public Tile wallPongTile;
    public Tile SpaceinvadersTile;

    public List<Tile> GameList;

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
        Debug.Log("gamemanager heard PEW");
        if (argbutton == 0)
        {
            
                Debug.Log("PEW InMenu ");
            if (GameManagerSimple.Instance.IndexOfCurGame != selecedGameIndex)
            {
                GameManagerSimple.Instance.IndexOfCurGame = selecedGameIndex;
                GameManagerSimple.Instance.StartGameXandStopAllOthers();
            }
        }
    }
    void Start()
    {
        GameList = new List<Tile>();
        GameList.Add(pongTile);
        GameList.Add(wallPongTile);
        GameList.Add(SpaceinvadersTile);
    }

    private void FixedUpdate()
    {
        UpdateIndex();
    }

    void UpdateIndex()
    {
        float originalVal = AnalogJoyHandler.Instance.GetP1Potval();
        float IndexifiedFloat = Extensions.RemapUnity(originalVal, -1.0f, 1f, 0f, GameList.Count);
        if (IndexifiedFloat >= GameList.Count - 1)
        {
            IndexifiedFloat = GameList.Count - 1;
        }
        int intDex = (int)IndexifiedFloat;
        //Debug.Log(intDex);
        selecedGameIndex = intDex;

        for (int iterationIndex =0; iterationIndex< GameList.Count; iterationIndex++) {
            if (selecedGameIndex == iterationIndex)
            {
                GameList[selecedGameIndex].HighLightMe(true);
            }
            else 
                GameList[iterationIndex].HighLightMe(false);
        }
    }
    public void ShowMenueOptions(bool argOnOff) { foreach (Tile atile in GameList) { atile.HighLightMe(argOnOff); } }
}
