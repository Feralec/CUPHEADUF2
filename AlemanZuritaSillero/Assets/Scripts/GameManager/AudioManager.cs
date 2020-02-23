using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class Sound
{
    public string name;
    public AudioClip clip;

    private AudioSource source;

    [Range(0f, 1f)] public float volume = 0.5f;
    [Range(0f, 1.5f)] public float pitch = 1f;

    [Range(0f, 1f)] public float volumenVariation = 0.5f;
    [Range(0f, 1f)] public float pitchVaration = 0.1f;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }

    public void Play()
    {
        source.volume = volume * (1+ Random.Range(-volumenVariation / 2f, volumenVariation / 2f));
        source.pitch = pitch * (1 + Random.Range(-pitchVaration / 2f, pitchVaration / 2f));
        source.Play();
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] Sound[] sounds;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one audiomanager in the scene");
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject go = new GameObject("Sound " + i + "_" + sounds[i].name);
            go.transform.SetParent(this.transform);
            sounds[i].SetSource (go.AddComponent<AudioSource>());
        }
    }

    public void PlaySound (string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if(sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }
        Debug.LogWarning("AudioManager: sound not found.." + _name);
    }
}
