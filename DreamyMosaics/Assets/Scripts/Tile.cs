using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColour, offSetColour;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void Init(bool isOffset)
    {
        spriteRenderer.color = isOffset ? offSetColour : baseColour;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("has triggered");
        SpriteRenderer playerRender = other.gameObject.GetComponent<SpriteRenderer>();

        if (playerRender.color == spriteRenderer.color)
        {
            //Debug.Log("Has recognised colour");
            Destroy(gameObject);
        }
    }
}
