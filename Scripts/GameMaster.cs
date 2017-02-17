using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

     static GameMaster gm;


    [SerializeField]
    private int maxLives = 3;
    private static int _remainingLives;
    public static int RemainingLives
    {
        get { return _remainingLives; }
    }

    void Start() {
        if (gm == null) 
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }

        _remainingLives = maxLives;

    }

   


    public Transform playerPrefab;
    public Transform spawnpoint;
    public int spawnDelay = 2;

    [SerializeField]
    private GameObject gameOverUI;

   
      

    public void EndGame ()
    {
        Debug.Log ("GAME OVER");
        gameOverUI.SetActive(true);
      
    }

    public IEnumerator RespawnPlayer () {
        yield return new WaitForSeconds (spawnDelay);

        Instantiate (playerPrefab, spawnpoint.position, spawnpoint.rotation);

    }

    public static void KillPlayer (Player player) {
        Destroy (player.gameObject);
        _remainingLives -= 1;
        if (_remainingLives <= 0)
        {
            gm.EndGame();
        }
        else
        {
            gm.StartCoroutine(gm.RespawnPlayer());
        }
     }

}
