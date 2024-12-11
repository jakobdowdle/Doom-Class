using UnityEngine.AI;
using UnityEngine;

public class AIChaseBehaviour : MonoBehaviour
{
    public enum AIState { Patrol, Chase }
    [SerializeField] private GameObject _player;
    [SerializeField] private AIState _state;
    [SerializeField] private float _outOfSightChaseTime;
    private float _chaseTimer;
    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _state = AIState.Patrol;
        _chaseTimer = _outOfSightChaseTime;
    }
    void Update()
    {
        _chaseTimer += Time.deltaTime;

        if(CanSeePlayer()) _chaseTimer = 0;

        if (_chaseTimer < _outOfSightChaseTime) Chase(); 
        else _state = AIState.Patrol;

        if (_agent.remainingDistance > _agent.stoppingDistance) return;
        if (_state == AIState.Patrol) Patrol();
    }
    private bool CanSeePlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, _player.transform.position - transform.position, out hit))
        {
            if (hit.collider.gameObject == _player)
            {
                return true;
            }
        }
        return false;
    }
    private void Patrol()
    {
        for (int i = 0; i < 100; i++)
        {
            Vector3 randomDirection = new Vector3(
                Random.Range(-10, 10),
                0,
                Random.Range(-10, 10)
            );

            NavMeshHit navmeshHit;
            if (NavMesh.SamplePosition(transform.position + randomDirection,
                out navmeshHit, 100, 1))
            {
                _agent.destination = navmeshHit.position;
                return;
            }
        }
    }
    private void Chase()
    {
        _agent.destination = _player.transform.position;
        _state = AIState.Chase;
    }
}
