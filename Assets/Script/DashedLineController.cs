using UnityEngine;

public class DashedLineController : MonoBehaviour
{
    public float dashLength = 1f;
    public float spaceLength = 1f;

    public GameObject lineRendererPrefab;

    public GameObject startPointPlayer1;
    public GameObject startPointPlayer2;

    public GameObject endPointPlayer1;
    public GameObject endPointPlayer2;

    void Start()
    {
        LineRenderer lineRendererPlayer1 = Instantiate(lineRendererPrefab).GetComponent<LineRenderer>();
        LineRenderer lineRendererPlayer2 = Instantiate(lineRendererPrefab).GetComponent<LineRenderer>();
        CreateDashedLine(lineRendererPlayer1, startPointPlayer1.transform.position, endPointPlayer1.transform.position);
        CreateDashedLine(lineRendererPlayer2, startPointPlayer2.transform.position, endPointPlayer2.transform.position);
    }

    private void CreateDashedLine(LineRenderer lineRenderer, Vector2 startPoint, Vector2 endPoint)
    {
        float lineLength = Vector2.Distance(startPoint, endPoint);
        float patternLength = dashLength + spaceLength;
        float patternCount = lineLength / patternLength;

        lineRenderer.sharedMaterial.mainTextureScale = new Vector2(patternCount, 1);
        lineRenderer.sharedMaterial.mainTextureOffset = new Vector2(0.5f * spaceLength / patternLength, 0);

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }
}
