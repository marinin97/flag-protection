using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed;

    
    private Transform _target;
    private int _wavePointIndex = 0;

    private void Start()
    {
        _target = Waypoints.Points[0];
    }

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * Speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }        
    }

    private void GetNextWaypoint()
    {
        if (_wavePointIndex >= Waypoints.Points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        _wavePointIndex++;
        _target = Waypoints.Points[_wavePointIndex];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("thorns"))
        {
            Destroy(gameObject);
        }
    }
}
