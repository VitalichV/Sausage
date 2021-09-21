using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Win : MonoBehaviour
{
    private Playable player;
    [SerializeField] private GameObject winMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<Playable>();
        if (player)
        {
            winMenu.SetActive(true);
            player.playableRb.mass = 1000f;
        }
 
    }
}
