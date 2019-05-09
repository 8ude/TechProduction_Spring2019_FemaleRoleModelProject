using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class RevisedAudioPicker : MonoBehaviour
{

    //we make this into a class so that we can keep track of whether it has been played
    [Serializable]
    public class RevisedVOPicker
    {
        public AudioClip clipToPlay;
        public bool hasPlayed = false;
    }

    //we need separate playlists for meditation, relax, stress, and attention clips
    public List<RevisedVOPicker> meditationClips, relaxClips, stressClips, attentionClips;

    //this will switch to true when playing VO so we don't change states during playing
    public bool isPlayingVO;

    public float timeBetweenVOClips = 2f;

    public AudioClip musicClip;

    //if the player is in the same state for a long time, 

    private AudioSource _audioSource;

    // Use this for initialization
    void Start()
    {
        isPlayingVO = false;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        ResetPlayedList();

    }

    // Update is called once per frame
    public void PlayMeditationClips() 
    {
        if(meditationClips[0].hasPlayed) return;
        StartCoroutine(VOPlaylist(meditationClips));
    }

    public void PlayRelaxClips() 
    {
        if (relaxClips[0].hasPlayed) return;
        StartCoroutine(VOPlaylist(relaxClips));
    }

    public void PlayStressClips()
    {
        if (stressClips[0].hasPlayed) return;
        StartCoroutine(VOPlaylist(stressClips));
    }

    public void PlayAttentionClips()
    {
        if(attentionClips[0].hasPlayed) return;
        StartCoroutine(VOPlaylist(attentionClips));
    }


    //resets hasPlayed to false for all AudioClips;
    public void ResetPlayedList()
    {
        foreach (RevisedVOPicker vo in meditationClips)
        {
            vo.hasPlayed = false;
        }

        foreach (RevisedVOPicker vo in relaxClips)
        {
            vo.hasPlayed = false;
        }
        foreach (RevisedVOPicker vo in stressClips)
        {
            vo.hasPlayed = false;
        }
        foreach (RevisedVOPicker vo in attentionClips)
        {
            vo.hasPlayed = false;
        }
    }

    //this coroutine goes through whatever array of VO clips we give it, and plays
    //each clip with a 2 second pause
    public IEnumerator VOPlaylist(List<RevisedVOPicker> playlist)
    {
        //first, we set this variable to true, so we don't start playing different audio
        //if the user's emotional state changes in the middle
        isPlayingVO = true;

        //go through every item in the playlist
        for (int i = 0; i < playlist.Count; i++)
        {
            //set the clip on the audiosource and play it
            _audioSource.clip = playlist[i].clipToPlay;
            _audioSource.Play();

            //wait for the length of the clip + 2 seconds before going to the next
            yield return new WaitForSeconds(playlist[i].clipToPlay.length + timeBetweenVOClips);
        }

        //switch to music at the end
        _audioSource.clip = musicClip;
        _audioSource.Play();

        isPlayingVO = false;
    }

}
