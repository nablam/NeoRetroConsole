using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSimple : MonoBehaviour
{
    public static GameManagerSimple Instance = null;
    public GameObject GAME_OBJ;
    public GameObject MENU_OBJ;
    public int IndexOfCurGame=0;
    BaseMinigame _curminigame;
    public List<GameObject> PlayableGames;
    public ConsoleStates curGamestate = ConsoleStates.InMenu;
    private void OnEnable()
    {
        PlayableGames = new List<GameObject>();
       // Debug.Log("Games Manager enabled");
        for (int i = 0; i < GAME_OBJ.transform.childCount; i++)
        {
            PlayableGames.Add(GAME_OBJ.transform.GetChild(i).gameObject);
        }
    }

    public void StartGameXandStopAllOthers() {

        for (int i = 0; i < GAME_OBJ.transform.childCount; i++)
        {
            if (i == IndexOfCurGame) {
                GAME_OBJ.transform.GetChild(i).gameObject.SetActive(true);
            }
            else {
                GAME_OBJ.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        MENU_OBJ.SetActive(false);
    }

    public void GotoMenue() {
        for (int i = 0; i < GAME_OBJ.transform.childCount; i++)
        {
                GAME_OBJ.transform.GetChild(i).gameObject.SetActive(false);
        }
        MENU_OBJ.SetActive(true);
    }


    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }


}
