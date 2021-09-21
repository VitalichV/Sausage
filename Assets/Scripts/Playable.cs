using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playable : MonoBehaviour
{
    [SerializeField] private Text coinCount;
    private int coin;
    private PlayablePropertis playablePropertis;

    [HideInInspector] public Rigidbody2D playableRb;
    [HideInInspector] public Collider2D playableCol;

    [HideInInspector] public Vector3 pos { get { return transform.position; } }

    [HideInInspector] public bool onGround;

    [SerializeField] private AudioSource jumpSound;
    [SerializeField] public AudioSource fallSound;

    private void Start()
    {
        coin = PlayerPrefs.GetInt("Coins count");
        coinCount.text = coin.ToString();
        playablePropertis = RememberColor.colorSO;
        this.GetComponentInChildren<Renderer>().material = playablePropertis.playableColor;
        Time.timeScale = 1f;
    }

    void Awake()
    {
        playableRb = GetComponent<Rigidbody2D>();
        playableCol = GetComponent<Collider2D>();
    }

    public void Push(Vector2 force)
    {
        if (onGround == true)
        {
            playableRb.AddForce(force, ForceMode2D.Impulse);
            jumpSound.Play();
            
        }
        
    }

    public void SetVelocity()
    {
        playableRb.velocity = Vector3.zero;
        playableRb.angularVelocity = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            coin++;
            coinCount.text = coin.ToString();

                PlayerPrefs.SetInt("Coins count", coin);
            
            Destroy(collision.gameObject);
        }
    }
}
