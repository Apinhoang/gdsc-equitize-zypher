using UnityEngine;

public class InteractionTrigger2D : MonoBehaviour
{
    public GameObject objectToShow;
    private bool isPlayerInTrigger = false;

    private void Update()
    {
        // Kiểm tra xem người chơi có trong khu vực kích hoạt và có nhấn phím "F" không
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            // Kích hoạt object
            objectToShow.SetActive(true);
        }
    }

    // Hàm này sẽ được gọi khi một Collider2D khác đi vào khu vực trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    // Hàm này sẽ được gọi khi một Collider2D khác rời khỏi khu vực trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;

            // Tùy chọn: Tắt object khi người chơi rời khỏi khu vực kích hoạt
            objectToShow.SetActive(false);
        }
    }
}
