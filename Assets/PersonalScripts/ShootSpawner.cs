using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpawner : MonoBehaviour
{
    [SerializeField] AudioSource _source;
    [SerializeField] List<AudioClip> _throwSoundClips;
    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject _feedback;
    [SerializeField] Transform _firePoint;
    [SerializeField] float _fireForce;
    [SerializeField] float _firingDelay;
    bool _canFire = true;

    GameObject _b;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!_canFire) return; 
            SpawnObject();
            HandleSoundFeedback();
            HandleVisualFeedback();
        }
    }

    void HandleVisualFeedback()
    {
        if (_feedback) Instantiate(_feedback, _firePoint.position, _firePoint.rotation);
        if (CamShaker.Instance) CamShaker.Instance.ShakeCamera(3f, 0.2f);
    }

    void HandleSoundFeedback()
    {
        if (_throwSoundClips.Count > 0 && !_source) return;

        _source.Stop();
        _source.PlayOneShot(_throwSoundClips[Random.Range(0, _throwSoundClips.Count)]);
    }

    void SpawnObject()
    {

        _b = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
        Rigidbody _rigidbody = _b.GetComponent<Rigidbody>();
        if (_rigidbody == null) _rigidbody = _b.AddComponent<Rigidbody>();

        _rigidbody.AddForce(_firePoint.forward * _fireForce, ForceMode.Impulse);
        _canFire = false;
        StartCoroutine(HandleFiringDelay());

    }

    IEnumerator HandleFiringDelay()
    {
        yield return new WaitForSeconds(_firingDelay);
        _canFire = true;
    }
}
