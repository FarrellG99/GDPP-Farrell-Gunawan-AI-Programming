using System;
using System.Collections.Generic;
using UnityEngine;

public class PickableManager : MonoBehaviour
{
    private List<Pickable> _pickableList = new List<Pickable>();

    private void Start()
    {
        InitPickableList();
    }

    private void InitPickableList()
    {
        Pickable[] pickableObjects = GameObject.FindObjectsByType<Pickable>(FindObjectsSortMode.None);
        foreach (Pickable pickableObject in pickableObjects)
        {
            pickableObject.OnPicked += OnPickablePicked;
            _pickableList.Add(pickableObject);
        }

        Debug.Log("Pickable List: " + _pickableList.Count);
    }

    private void OnPickablePicked(Pickable pickable)
    {
        _pickableList.Remove(pickable);
        Destroy(pickable.gameObject);
        Debug.Log("Pickable List: " + _pickableList.Count);
        if (_pickableList.Count <= 0) Debug.Log("Win");
    }
}