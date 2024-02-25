using UnityEngine;
using UnityEngine.UI;

public class ToggleObjects : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject[] objectsToDeactivate; // Thay đổi thành mảng các GameObject

    public Button yourButton;

    void Start()
    {
        // Đảm bảo rằng bạn đã gán nút trong Inspector
        yourButton.onClick.AddListener(Toggle);
    }

    void Toggle()
    {
        // Kích hoạt object mới
        objectToActivate.SetActive(true);

        // Tắt tất cả các object trong mảng
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }
    }
}
