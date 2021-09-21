using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    [SerializeField] private PlayablePropertis[] playableColor;

    public void SelectColor(int index)
    {
        RememberColor.colorSO = playableColor[index];
    }

    public void ColorDefault()
    {
        if (RememberColor.colorSO == null)
        {
            RememberColor.colorSO = playableColor[0];
        }
    }
}
