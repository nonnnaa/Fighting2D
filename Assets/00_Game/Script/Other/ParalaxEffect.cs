using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField][Range(0,1)] private float _paralaxEffect;
    private float _xPosition;
    private float _length;
    void Start()
    {
        _xPosition = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void Update()
    {
        float distanceMoved = _camera.transform.position.x * (1 - _paralaxEffect);
        float distanceToMove = _camera.transform.position.x * _paralaxEffect;
        transform.position = new Vector3(_xPosition + distanceToMove, transform.position.y);

        if (distanceMoved > _xPosition + _length)
        {
            _xPosition += _length;
        }
        else if(distanceMoved < _xPosition - _length)
        {
            _xPosition -= _length;
        }
    }
}
