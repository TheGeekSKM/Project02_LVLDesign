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
            Friend friend = FindObjectOfType<Friend>();
            if (friend) friend.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            friend.RandomizeName();
            Destroy(gameObject);
        }
    }
}
