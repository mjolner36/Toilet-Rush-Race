using UnityEngine;

public class PlayerPlace : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private GameObject _linePrefab;
    public Line currentLine;

    public delegate void Draw();

    public event Draw endDraw;

    public int ID()
    {
        return id;
    }

    public void Init(PlayerSO playerSO)
    {
        _linePrefab = playerSO.line;
        gameObject.GetComponent<SpriteRenderer>().color = playerSO.playerBaseColor;
    }

    public void OnMouseDown()
    {
        if (currentLine != null)
        {
            Destroy(currentLine.gameObject);
            GameManager.Instance.finishDrawLine--;
        }
        
        Vector2 mousePos = GameManager.Instance.camera.ScreenToWorldPoint(Input.mousePosition);
        currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity).GetComponent<Line>();
        currentLine.idPlayer = id;
    }

    public void OnMouseDrag()
    {
        Vector2 mousePos = GameManager.Instance.camera.ScreenToWorldPoint(Input.mousePosition);
        currentLine.SetPosition((mousePos));
    }

    public void OnMouseUp()
    {
        if (!currentLine.stopPoint)
        {
            Destroy(currentLine.gameObject);
            
        }
        else
        {
            endDraw?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Wall"))
        {
            GameManager.Instance.LoseState();
        }
    }

    public void StartMove()
    {
        var lineRenderer = gameObject.GetComponent<FollowLineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.lineRenderer = currentLine._renderer;
    }
}