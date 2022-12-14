using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAt : MonoBehaviour
{
    [SerializeField] float _destroyDelay;

    void Start()
    {
        Destroy(gameObject, _destroyDelay);
    }
}
