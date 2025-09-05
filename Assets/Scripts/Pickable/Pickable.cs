using System;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public Action<Pickable> OnPicked;

    [SerializeField] private PickableType pickableType;

    private void OnTriggerEnter(Collider other)
    {
        if(OnPicked != null)
        {
            OnPicked(this);
        }
    }
}

public enum PickableType
{
    Coin,
    PowerUp,
}