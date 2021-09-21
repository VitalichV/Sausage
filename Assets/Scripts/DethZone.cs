using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DethZone : MonoBehaviour
{
    [SerializeField] private GameObject deathMenu;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0f;

        deathMenu.SetActive(true);
    }
}
