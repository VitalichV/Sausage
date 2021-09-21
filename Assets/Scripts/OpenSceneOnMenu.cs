using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneOnMenu : MonoBehaviour
{
    public void OpenScene(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
    }
}
