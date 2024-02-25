using UnityEngine;

public class VisibilityTrigger2D : MonoBehaviour
{
    public GameObject objectToShow; // Gán object này trong Inspector

    // Hàm này sẽ được gọi khi một Collider2D khác đi vào khu vực trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem có phải là người chơi không
        if (other.CompareTag("Player"))
        {
            // Hiển thị object
            objectToShow.SetActive(true);
        }
    }

    // Hàm này sẽ được gọi khi một Collider2D khác rời khỏi khu vực trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        // Kiểm tra xem có phải là người chơi không
        if (other.CompareTag("Player"))
        {
            // Ẩn object
            objectToShow.SetActive(false);
        }
    }
}
