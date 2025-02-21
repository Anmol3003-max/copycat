using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 targetPosition;
    private bool isMoving = false;

    void Update()
    {
        // Detecting the left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPosition();
        }

        // Move the character to the target position
        if (isMoving)
        {
            MoveCharacter();
        }
    }

    void SetTargetPosition()
    {
        // Converting mouse click to world position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition = new Vector2(mousePosition.x, mousePosition.y);
        isMoving = true;
    }

    void MoveCharacter()
    {
        // Move to target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Stop moving if close enough to the target
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
        }
    }
}
