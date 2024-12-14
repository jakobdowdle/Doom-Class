using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float time = 1;
    [SerializeField] private float moveDist = 2;

    private Vector3 startLocation;
    private bool _playerInRange=false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && _playerInRange)
        {
            //Debug.Log("enter friend");
            openDoor();
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

    public void openDoor()
    {
        startLocation = transform.position;
        StartCoroutine(RepeatingLerp());
    }

    IEnumerator RepeatingLerp()
    {
        //Debug.Log("Repeating");
        float t = 0;
        Vector3 newLocation = startLocation + new Vector3 (0,moveDist,0);
        while (t < 1)
        {
            //Debug.Log("Moving");
            t += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Lerp(startLocation, newLocation, t);
            yield return null;
        }
    }
}
