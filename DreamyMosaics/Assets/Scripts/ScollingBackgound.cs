using UnityEngine;

public class ScollingBackgound : MonoBehaviour
{
    public float speed;

    [SerializeField] private Renderer bgRender;

    // Update is called once per frame
    void Update()
    {
        bgRender.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);

    }
}
