using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject gameMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject loseMenu;

    public static bool inGame = false;

    public static GameManager Instance;

    private void Awake() {
        if(Instance == null){
            Instance = this;
        }
    }
    void Start()
    {
        inGame = false;
        Application.targetFrameRate = 120;
        GlobalEventManager.Win.AddListener(WinGame);
        GlobalEventManager.Lose.AddListener(LoseGame);
    }

    void WinGame(){
        inGame = false;
        gameMenu.SetActive(false);
        winMenu.transform.localScale = Vector3.one;
        Debug.Log("WIN!!!");
    }

    void LoseGame(){
        inGame = false;
        gameMenu.SetActive(false);
        loseMenu.transform.localScale = Vector3.one;
        Debug.Log("Lose!!!");
    }

    public void GameStart(){
        inGame = true;
    }

    public void GameStop(){
        inGame = false;
    }

    public void HidelevelMenu(){
        levelMenu.transform.localScale = Vector3.zero;
    }

    public void ShowlevelMenu(){
        levelMenu.transform.localScale = Vector3.one;
        mainMenu.transform.localScale = Vector3.zero;
    }

    public void HideMainMenu(){
        mainMenu.transform.localScale = Vector3.zero;
    }

    public void ShowMainMenu(){
        levelMenu.transform.localScale = Vector3.zero;
        mainMenu.transform.localScale = Vector3.one;
    }

    public void HideWinMenu(){
        winMenu.transform.localScale = Vector3.zero;
        loseMenu.transform.localScale = Vector3.zero;
    }


}
