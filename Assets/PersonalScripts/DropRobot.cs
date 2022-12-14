using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRobot : MonoBehaviour
{
    [SerializeField] GameObject _robot;
    [SerializeField] GameObject _spawnFeedback;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("REEE");
            HandleSpawnFeedback();
            Friend friend = FindObjectOfType<Friend>();
            if (friend) friend.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            friend.RandomizeName();
            Destroy(gameObject);
        }
    }

    void HandleSpawnFeedback()
    {
        if (_spawnFeedback) Instantiate(_spawnFeedback, transform.position, Quaternion.identity);
    }
}
