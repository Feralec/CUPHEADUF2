using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public int coins, playerHealth;
    public const int maxHealth = 100;

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
        playerHealth = maxHealth;
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
}
