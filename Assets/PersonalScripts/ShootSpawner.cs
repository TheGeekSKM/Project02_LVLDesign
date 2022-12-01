using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpawner : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _firePoint;
    [SerializeField] float _fireForce;

    GameObject _b;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        _b = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
        Rigidbody _rigidbody = _b.GetComponent<Rigidbody>();
        if (_rigidbody == null) _rigidbody = _b.AddComponent<Rigidbody>();

        _rigidbody.AddForce(_firePoint.forward * _fireForce, ForceMode.Impulse);

    }
}
