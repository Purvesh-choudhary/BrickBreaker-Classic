using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundClip{
    public string name;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    [SerializeField] AudioSource audioSource;
    [SerializeField] SoundClip[] soundClips;

    // [SerializeField] Dictionary<string, AudioClip> soundClips = new Dictionary<string, AudioClip>();
 
    void Awake()
    {
        if(Instance == null){
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(string clipName){
        foreach (var soundClip in soundClips){
            if(soundClip.name == clipName){
                audioSource.PlayOneShot(soundClip.clip);
            }
        }
    }

    public void HitSound(){

    }

    public void MissSound(){

    }
}
