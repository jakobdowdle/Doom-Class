using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukageBehaviour : MonoBehaviour
{
    [SerializeField] private int nukageDamage = 5;
    private void OnTriggerStay(Collider other)
    {
        GameManager.Instance.takeDamage(nukageDamage);
        StartCoroutine(Cooldown());
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(5f);
    }
}
