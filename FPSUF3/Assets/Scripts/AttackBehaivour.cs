using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaivour : MonoBehaviour
{
    public Action<GameObject> OnEntrar;
    public Action OnSortir;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        OnEntrar?.Invoke(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        OnSortir?.Invoke();
    }
}
