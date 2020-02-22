using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public int coins, playerHealth, killedEnemies, totalNumberOfCoins;
    public const int maxHealth = 100;

    public string spawnSoundName;

    private AudioManager audioManager;

    public static GameManager GInstance
    {
        get { return instance; }
    }

    private void Awake()
    {
        MakeSingletone();
    }

    private void Start()
    {
        killedEnemies = 0;
        playerHealth = maxHealth;

        audioManager = AudioManager.instance;
        
        if(audioManager == null)
        {
            Debug.LogError("No audio manager found");
        }
    }


    public void MakeSingletone()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void RestoreValues()
    {
        playerHealth = maxHealth;
        killedEnemies = 0;
        coins = 0;
        totalNumberOfCoins = 0;
    }
}
