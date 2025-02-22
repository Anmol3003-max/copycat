using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 targetPos;
    private bool moving = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPosition();
        }

        if (moving)
        {
            MoveCharacter();
        }
    }

    void SetTargetPosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        targetPos = new Vector2(mousePos.x, mousePos.y);
        moving = true;
    }

    void MoveCharacter()
    {
        Vector2 currentPos = transform.position;
        Vector2 direction = (targetPos - currentPos).normalized;
        transform.position = Vector2.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);

        if (Vector2.Distance(currentPos, targetPos) < 0.1f)
        {
            moving = false;
        }
    }
}
