using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginUI : MonoBehaviour
{
    
    public AudioSource audioSource;
    public GameObject buttonObject;
    
    public void bottomofplay() {
        audioSource.Play();
        buttonObject.SetActive(false);
        StartCoroutine(LoadAfterDelay());
    }

    IEnumerator LoadAfterDelay() {
        yield return new WaitForSeconds(audioSource.clip.length + 2.0f);
        SceneManager.LoadScene("CharacterCreationScene");
    }
    
    
    
}
