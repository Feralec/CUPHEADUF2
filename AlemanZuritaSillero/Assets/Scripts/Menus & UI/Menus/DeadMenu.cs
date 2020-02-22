using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public bool isPlaying = true;
    
    public void PlayAgain()
    {
        GameManager.GInstance.RestoreValues();
        SceneManager.LoadScene("SampleScene");
    }
    
    public void Quit()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
