using System;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private int id;

    public int ID()
    {
        return id;
    }

    public void Init(PlayerSO playerSO)
    {
        gameObject.GetComponent<SpriteRenderer>().color = playerSO.playerBaseColor;
    }
}