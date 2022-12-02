using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Friend : MonoBehaviour
{
    [SerializeField] List<string> _friendBotNames;
    [SerializeField] TextMeshPro _nameText;
    [SerializeField] Transform _textTransform;
    [SerializeField] bool _rotateText = true;
    Transform _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerCharacterController>().transform;
    }

    public void RandomizeName()
    {
        if (_friendBotNames.Count <= 0 && _nameText == null) return;

        _nameText.text = _friendBotNames[Random.Range(0, _friendBotNames.Count)];
    }

    private void Update()
    {
        if (_rotateText) _textTransform.LookAt(_player.position);
    }
}
