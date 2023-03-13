using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Character : MonoBehaviour
{
    public string Name;
    public GameObject prefabPlayer;
    public GameObject prefabEnemy;
    public Image icon;
    public Image backGroundImage;
}

