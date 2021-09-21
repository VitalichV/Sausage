using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New playable", menuName = "Playable", order = 51)]
public class PlayablePropertis : ScriptableObject
{
    [Header("View Settings")]
    public Material playableColor;
}
