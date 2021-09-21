using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] private int dotsNumber;
    [SerializeField] private GameObject dotsParent;
    [SerializeField] private GameObject dotsPrefab;
    [SerializeField] private float dotsSpacing;

    [SerializeField] [Range(0.02f, 0.5f)] private float dotsMinScale;
    [SerializeField] [Range(0.5f, 6f)] private float dotsMaxScale;

    private Transform[] dotsArray;

    private Vector3 pos;
    private float timeStamp;

    void Start()
    {
        Hide();

        PrepareDots();
    }

    void PrepareDots()
    {
        dotsArray = new Transform[dotsNumber];
        dotsPrefab.transform.localScale = Vector3.one * dotsMaxScale;

        float scale = dotsMaxScale;
        float scaleFactor = scale / dotsNumber;

        for(int i = 0; i < dotsNumber; i++)
        {
            dotsArray[i] = Instantiate(dotsPrefab, null).transform;
            dotsArray[i].parent = dotsParent.transform;

            dotsArray[i].localScale = Vector3.one * scale;
            if (scale > dotsMinScale)
            {
                scale -= scaleFactor;
            }
        }
    }

    public void UpdateDots(Vector3 playablePos, Vector3 forceApplied)
    {
        timeStamp = dotsSpacing;
        for(int i = 0; i < dotsNumber; i++)
        {
            // For 2D game
            //pos.x = (playablePos.x + forceApplied.x * timeStamp);
            //pos.y = (playablePos.y + forceApplied.y * timeStamp) - (Physics2D.gravity.magnitude * timeStamp * timeStamp) / 2;
            pos = playablePos + forceApplied * timeStamp + Physics.gravity * timeStamp * timeStamp / 2;

            dotsArray[i].position = pos;
            timeStamp += dotsSpacing;
        }
    }

    public void Show()
    {
        dotsParent.SetActive(true);
    }

    public void Hide()
    {
        dotsParent.SetActive(false);
    }
}
