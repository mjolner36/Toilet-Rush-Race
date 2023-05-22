using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] public LineRenderer _renderer;
    public const float RESOLUTION = .1f;
    [SerializeField] private GameObject endPointCollider;
    private List<Vector2> _points = new List<Vector2>();
    public bool stopPoint;
    public int idPlayer;


    public void SetPosition(Vector2 position)
    {
        if (!CanAppend(position)) return;
        _points.Add(position);
        _renderer.positionCount++;
        _renderer.SetPosition(_renderer.positionCount - 1, position);

        UpdateEndPointCollider();
    }

    private void UpdateEndPointCollider()
    {
        if (_points.Count > 0)
        {
            endPointCollider.transform.position = _points[_points.Count - 1];
        }
    }

    private bool CanAppend(Vector2 pos)
    {
        if (_renderer.positionCount == 0) return true;

        return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) > RESOLUTION;
    }
}
