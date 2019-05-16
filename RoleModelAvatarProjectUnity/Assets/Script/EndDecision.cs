using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDecision : MonoBehaviour
{
    public void PlayGarbageScene()
    {
        SceneManager.LoadScene("EndTrashScene");
    }
    public void PlayPartScene()
    {
        SceneManager.LoadScene("EndPartScene");
    }
}
