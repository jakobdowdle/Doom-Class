using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SecretElevatorBehaviour : MonoBehaviour
{
    [SerializeField] private float elevatorTimer = 5f;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float time = 1;
    [SerializeField] private float moveDist = 2;

    [SerializeField] private AudioSource ElevatorSound;

    private Vector3 startLocation;
   
    private void OnTriggerStay()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            LowerElevator();
        }
        elevatorTimer = 5f;
    }

    public void LowerElevator()
    {
        if (ElevatorSound != null)
        {
            ElevatorSound.Play();
        }
        startLocation = transform.position;
        StartCoroutine(RepeatingLerp());
    }

    IEnumerator RepeatingLerp()
    {
        //Debug.Log("Repeating");
        float t = 0;
        Vector3 newLocation = startLocation + new Vector3(0, -moveDist, 0);
        while (t < 1)
        {
            //Debug.Log("Moving");
            t += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Lerp(startLocation, newLocation, t);
            yield return null;
        }
    }
}
