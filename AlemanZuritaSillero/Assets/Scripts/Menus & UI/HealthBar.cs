using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float maxHealth,currentHealth;
    private Slider sl;

    private void Start()
    {
        maxHealth = GameManager.GInstance.playerHealth;
        currentHealth = GameManager.GInstance.playerHealth; //los dos tienen que serlo
        sl = GetComponent<Slider>();
    }

    private void Update()
    {
        if (currentHealth!= GameManager.GInstance.playerHealth)
        {
            currentHealth = GameManager.GInstance.playerHealth;
            sl.SetValueWithoutNotify(currentHealth / maxHealth);
        }
    }
}
