using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{
    [SerializeField] private Playable player;

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.onGround = false;
    }

    private void OnTriggerStay2D(Collider2D _collision)
    {
        player.onGround = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.fallSound.Play();
        OnTriggerStay2D(collision);
    }
}
