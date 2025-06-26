using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("has triggered");
        SpriteRenderer playerRender = other.gameObject.GetComponent<SpriteRenderer>();

        if (playerRender.color == spriteRenderer.color)
        {
            GameManager.Instance.destroyedTile++;
            //Debug.Log("Has recognised colour");
            Destroy(gameObject);
        }
        else 
        {
            GameManager.Instance.takeDamage();
        }
    }
}
