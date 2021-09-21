using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton class: GameManager

    public static GameManager Instans;

    void Awake()
    {
        if(Instans == null)
        {
            Instans = this;
        }
    }

    #endregion
    public Playable playable;
    public Trajectory trajectory;

    private Camera cam;
    private bool isDragging = false;

    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 direction;
    private Vector2 force;
    private float distance;

    [SerializeField] private float pushForce = 0.4f;

    void Start()
    {
        cam = Camera.main;
        playable.SetVelocity();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (playable.onGround == true)
            {
                isDragging = true;
                OnDragStart();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            OnDragEnd();
        }

        if (isDragging)
        {
            OnDrag(); 
        }
    }

    void OnDragStart()
    {
        playable.SetVelocity();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }

    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;

        Debug.DrawLine(startPoint, endPoint);

        trajectory.UpdateDots(playable.pos, force);
    }

    void OnDragEnd()
    {
        playable.Push(force);

        trajectory.Hide();
    }
}
