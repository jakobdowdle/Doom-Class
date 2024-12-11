using UnityEngine.AI;
using UnityEngine;

public class ChaseThroughNavmesh : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.destination = _player.transform.position;
    }
}
