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
            FindObjectOfType<Friend>().transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            Destroy(gameObject);
        }
    }
}
