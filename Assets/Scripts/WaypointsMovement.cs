using UnityEngine;

public class WaypointsMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _waypointsParent;

    private Vector3[] _waypointsPositions;
    private int _currentIndex = 0;

    private void Start()
    {
        _waypointsPositions = new Vector3[_waypointsParent.childCount];

        for (int i = 0; i < _waypointsPositions.Length; i++)
        {
            _waypointsPositions[i] = _waypointsParent.GetChild(i).position;
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 currentWaypointPosition = _waypointsPositions[_currentIndex];

        transform.position = Vector3.MoveTowards(transform.position, currentWaypointPosition, _speed * Time.deltaTime);

        if (transform.position == currentWaypointPosition)
        {
            SwitchNextIndex();
        }
    }

    private void SwitchNextIndex()
    {
        _currentIndex++;

        if (_currentIndex == _waypointsPositions.Length)
        {
            _currentIndex = 0;
        }
    }
}