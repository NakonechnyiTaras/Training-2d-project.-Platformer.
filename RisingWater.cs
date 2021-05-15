using UnityEngine;

public class RisingWater : MonoBehaviour
{

    [Tooltip ("Game units per seconds")]
    [SerializeField] float scrollRate = 0.1f;

    void Update()
    {
        float yMove = scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(0f, yMove));
    }
}
