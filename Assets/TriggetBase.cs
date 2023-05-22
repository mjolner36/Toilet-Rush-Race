using UnityEngine;

public class TriggetBase : MonoBehaviour
{
    private Line parentLine;

    private void OnEnable()
    {
        parentLine = gameObject.transform.parent.gameObject.GetComponent<Line>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Base"))
        {
            if (other.gameObject.GetComponent<PlayerBase>().ID() == parentLine.idPlayer) parentLine.stopPoint = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Base"))
        {
            if (other.gameObject.GetComponent<PlayerBase>().ID() == parentLine.idPlayer) parentLine.stopPoint = false;
        }
    }
}
