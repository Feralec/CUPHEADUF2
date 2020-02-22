using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinS : MonoBehaviour
{
    public GameObject coinSound;

    private void Start()
    {
        GameManager.GInstance.totalNumberOfCoins++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.GInstance.coins += 1;
            Instantiate(coinSound);
            if (GameManager.GInstance.coins == GameManager.GInstance.totalNumberOfCoins)
                GameManager.GInstance.playerHealth = 100;
            Destroy(gameObject);
        }
    }
}
