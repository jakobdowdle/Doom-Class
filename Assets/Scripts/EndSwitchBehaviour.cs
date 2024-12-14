using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class EndSwitchBehaviour : MonoBehaviour
{
    private bool _playerInRange = false;
    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E) && _playerInRange)
        {
            Debug.Log("You beat the level!");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        _playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        _playerInRange = false;
    }
}
