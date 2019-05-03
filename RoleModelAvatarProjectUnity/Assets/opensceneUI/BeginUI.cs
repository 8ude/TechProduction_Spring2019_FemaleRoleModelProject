using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginUI : MonoBehaviour
{
    public void bottomofplay()
    {
        SceneManager.LoadScene("CharacterCreationScene");
    }
}
