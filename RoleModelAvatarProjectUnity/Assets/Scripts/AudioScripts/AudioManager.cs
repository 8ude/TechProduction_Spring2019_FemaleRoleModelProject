using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    //We may replace this for a different FMOD function called "programmer sounds,"
    //but for now we will play a VO event based on the key that we pass it
    public class VOEvent {

        [FMODUnity.EventRef] public string VOEventName;

        public string VOEventKey;
        
    }
    
    public static AudioManager Instance;
    
    
    [FMODUnity.EventRef]
    public string avatarLevelMusic;

    [FMODUnity.EventRef]
    public string officeLevelAmbience;
    
    [FMODUnity.EventRef]
    public string playgroundLevelAmbience;

    public VOEvent[] avatarVOEvents;
    public VOEvent[] officeVOEvents;
    public VOEvent[] playgroundVOEvents;

    void Awake() 
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(gameObject);
        }
        else 
        {
            Instance = this;
        }
    }

}
