using UnityEngine;

public class Raycast : MonoBehaviour
{
    public GameObject LookRight()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);

        return hit.collider.gameObject;
    }

    public GameObject LookLeft()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left);

        return hit.collider.gameObject;
    }

    // Test AI
}
