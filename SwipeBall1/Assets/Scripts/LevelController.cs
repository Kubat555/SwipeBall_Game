using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] MeshRenderer plane;
    [SerializeField] List<LevelInfo> levelsInfo;
    [SerializeField] List<GameObject> levels;

    public static LevelController Instance;
    public static int currentLevelIndex;
    public List<LevelInfo> InfoLevels{get{return levelsInfo;}}

    GameObject prevLevel;
    private void Awake() {
        if(Instance == null){
            Instance = this;
        }
        currentLevelIndex = 0;
    }

    public void StartLevel(int index){
        if(index >= levelsInfo.Count || index < 0) return;

        currentLevelIndex = index;

        player.transform.position = levelsInfo[index].playerPosition;
        Player.instance.playerMove = false;
        Player.instance.rb.velocity = Vector3.zero;
        Player.instance.DisactrivateVectors();
        // player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<MeshRenderer>().material = levelsInfo[index].playerMaterial;
        if(prevLevel != null){
            prevLevel.SetActive(false);
        }
        levels[index].SetActive(true);
        prevLevel = levels[index];
        plane.material = levelsInfo[index].planeMaterial;
        GlobalEventManager.RefreshDoor.Invoke();
        GlobalEventManager.RefreshCoin.Invoke();
        StartCoroutine(TimerPlay(0.2f));
    }

    public void NextLevel(){
        StartLevel(Mathf.Clamp(currentLevelIndex + 1, 0, levelsInfo.Count - 1));
    }

    public void RestartScene(){
        StartLevel(currentLevelIndex);
    }

    IEnumerator TimerPlay(float time){
        yield return new WaitForSeconds(time);
        GameManager.inGame = true;
        Debug.Log(GameManager.inGame);
    }
}
