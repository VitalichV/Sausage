using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 0f;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
    }
}
