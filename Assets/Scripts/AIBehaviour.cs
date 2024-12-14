using UnityEngine.AI;
using System.Collections;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    public enum AIState { Patrol, Chase, Attack }
    [SerializeField] private GameObject _player;
    [SerializeField] private AIState _state;
    [SerializeField] private float _outOfSightChaseTime;
    [SerializeField] private float _timeBetweenAttacks = 3f;
    [SerializeField] private int _damage = 5;
    [SerializeField] private AudioSource EnemyShoot;
    private float _chaseTimer;
    private float _attackTimer;
    private NavMeshAgent _agent;

    private void Awake() {
        if (EnemyShoot == null) {
            EnemyShoot = GetComponentInChildren<AudioSource>();
            if (EnemyShoot == null) {
                Debug.LogError("No AudioSource found.");
            }
        }
    }
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _state = AIState.Patrol;
        _chaseTimer = _outOfSightChaseTime;
        _attackTimer = _timeBetweenAttacks;
    }
    void Update()
    {
        _chaseTimer += Time.deltaTime;


        if (CanSeePlayer()) {
            _chaseTimer = 0;
            _attackTimer -= Time.deltaTime;
        }

        if (_chaseTimer < _outOfSightChaseTime) Chase();
        else _state = AIState.Patrol;

        if ((_attackTimer <= 0)  && CanSeePlayer()) Attack();
        else _state= AIState.Chase;

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

    private void Attack() {
        _state = AIState.Attack;
        if (EnemyShoot != null) {
            EnemyShoot.Play();
        }
        ShootPlayer();
        StartCoroutine(HoldStill());
        _attackTimer = _timeBetweenAttacks;
    }

    private void ShootPlayer() {
        Vector3 direction = (_player.transform.position - transform.position).normalized;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit)) {
            if (hit.collider.gameObject == _player) {
                GameManager.Instance.takeDamage(_damage);
            }
        }
    }


    IEnumerator HoldStill() {
        _agent.destination = _agent.transform.position;
        yield return new WaitForSeconds(5f);
    }
}
