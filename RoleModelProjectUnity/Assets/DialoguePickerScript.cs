using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class DialoguePickerScript : MonoBehaviour
{
    [Serializable]
    public class VOPicker
    {
        public float percentage;
        public AudioClip clipToPlay;
        public bool hasPlayed = false;
    }
    public List<VOPicker> VOList;

    //this is our percentage - goes from 0 to 100
    [Range(0f, 100f)] public float inputValue;
    private AudioSource _audioSource;

    // Use this for initialization
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        ResetPlayedList();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (VOPicker voiceOver in VOList)
        {
            if (inputValue >= voiceOver.percentage && !voiceOver.hasPlayed && !_audioSource.isPlaying)
            {

                _audioSource.clip = voiceOver.clipToPlay;
                _audioSource.Play();
                voiceOver.hasPlayed = true;

            }

        }
    }
    //resets them all to false
    public void ResetPlayedList()
    {
        foreach (VOPicker voiceOver in VOList)
        {
            voiceOver.hasPlayed = false;
        }
    }

}