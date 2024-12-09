using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // Start is called before the first frame update

    void Update()
    {
        transform.LookAt(PlayerController.Instance.transform);
    }
}
