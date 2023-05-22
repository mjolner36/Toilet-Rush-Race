using UnityEngine;

public class FollowLineRenderer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float speed = 1.0f;
    private bool _isMoving = true;
    private float _t = 0.0f;

    private void Update()
    {
        if (!_isMoving) return;
        _t += speed * Time.deltaTime;

        if (_t >= 1.0f)
        {
            _t = 0.0f;
            _isMoving = false;
            GameManager.Instance.WinState();
            Destroy(gameObject);
        }

        Vector3 newPosition = GetPositionOnLine(_t);
        transform.position = newPosition;
    }

    private Vector3 GetPositionOnLine(float t)
    {
        int numPoints = lineRenderer.positionCount;
        float totalLength = 0.0f;

        for (int i = 0; i < numPoints - 1; i++)
        {
            totalLength += Vector3.Distance(lineRenderer.GetPosition(i), lineRenderer.GetPosition(i + 1));
        }

        float targetLength = totalLength * t;
        float currentLength = 0.0f;

        for (int i = 0; i < numPoints - 1; i++)
        {
            float segmentLength = Vector3.Distance(lineRenderer.GetPosition(i), lineRenderer.GetPosition(i + 1));

            if (currentLength + segmentLength >= targetLength)
            {
                float remainingLength = targetLength - currentLength;
                float segmentFraction = remainingLength / segmentLength;
                return Vector3.Lerp(lineRenderer.GetPosition(i), lineRenderer.GetPosition(i + 1), segmentFraction);
            }

            currentLength += segmentLength;
        }

        return lineRenderer.GetPosition(numPoints - 1);
    }
}
