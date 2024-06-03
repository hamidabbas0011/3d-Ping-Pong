using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public void LoadSceneAI()
    {
        SceneManager.LoadScene("GameSceneAI");
    }

    public void LoadSceneHuman()
    {
        SceneManager.LoadScene("GameSceneHuman");
    }
}
