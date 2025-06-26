using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    // Allows you to hold down a key for movement.
    [SerializeField] private bool isRepeatedMovement = false;
    // Time in seconds to move between one grid position and the next.
    [SerializeField] private float moveDuration = 0.2f;
    // The size of the grid
    [SerializeField] private float gridSize = 0.3f;

    private bool isMoving = false;

    [SerializeField] private Color [] arrColours;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Light2D glowLight;

    private int arrCounter = 0;

    // Update is called once per frame
    private void Update()
    {

        // Only process on move at a time.
        if (!isMoving)
        {
            // Accomodate two different types of moving.
            System.Func<KeyCode, bool> inputFunction;
            if (isRepeatedMovement)
            {
                // GetKey repeatedly fires.
                inputFunction = Input.GetKey;
            }
            else
            {
                // GetKeyDown fires once per keypress
                inputFunction = Input.GetKeyDown;
            }

            // If the input function is active, move in the appropriate direction.
            if (inputFunction(KeyCode.UpArrow) || inputFunction(KeyCode.W))
            {
                StartCoroutine(Move(Vector2.up));
            }
            else if (inputFunction(KeyCode.DownArrow) || inputFunction(KeyCode.S))
            {
                StartCoroutine(Move(Vector2.down));
            }
            else if (inputFunction(KeyCode.LeftArrow) || inputFunction(KeyCode.A))
            {
                StartCoroutine(Move(Vector2.left));
            }
            else if (inputFunction(KeyCode.RightArrow) || inputFunction(KeyCode.D))
            {
                StartCoroutine(Move(Vector2.right));
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (arrCounter == arrColours.Length)
            {
                arrCounter = 0;
            }
            spriteRenderer.color = arrColours[arrCounter];
            glowLight.color = arrColours[arrCounter];
            arrCounter++;
        }
    }

    // Smooth movement between grid positions.
    private IEnumerator Move(Vector2 direction)
    {
        // Record that we're moving so we don't accept more input.
        isMoving = true;

        // Make a note of where we are and where we are going.
        Vector2 startPosition = transform.position;
        Vector2 endPosition = startPosition + (direction * gridSize);

        // Smoothly move in the desired direction taking the required time.
        float elapsedTime = 0;
        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float percent = elapsedTime / moveDuration;
            transform.position = Vector2.Lerp(startPosition, endPosition, percent);
            yield return null;
        }

        // Make sure we end up exactly where we want.
        transform.position = endPosition;

        // We're no longer moving so we can accept another move input.
        isMoving = false;
    }
}
