using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRobot : MonoBehaviour
{
    [SerializeField] GameObject _robot;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("REEE");
            Instantiate(_robot, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
