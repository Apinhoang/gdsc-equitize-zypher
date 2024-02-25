// using UnityEngine;
// using TMPro;
// using UnityEngine.UI;
// using System.Collections.Generic;

// [System.Serializable]
// public class DialogueNode
// {
//     public string dialogueText; // Văn bản hội thoại
//     public List<string> choices; // Danh sách các lựa chọn văn bản
//     public List<int> nextNodes; // Chỉ số của node tiếp theo tương ứng với mỗi lựa chọn
// }

// public class DialogueSystem : MonoBehaviour
// {
//     public TextMeshProUGUI dialogueText;
//     public GameObject[] choiceButtons;
//     public GameObject dialoguePanel;
//     private int currentNode;
//     public List<DialogueNode> dialogueNodes;
//     private bool playerIsInTrigger = false;

//     void Update()
//     {
//         // Kiểm tra nếu đang trong một hội thoại và nhấn phím "F" để bắt đầu
//         if (playerIsInTrigger && Input.GetKeyDown(KeyCode.F) && !dialoguePanel.activeInHierarchy)
//         {
//             StartDialogue();
//         }
        
//         // Kiểm tra khi đang trong hội thoại
//         if (dialoguePanel.activeInHierarchy)
//         {
//             // Nếu node hiện tại không có lựa chọn, cho phép nhấn "Space" để tiếp tục
//             if (dialogueNodes[currentNode].choices.Count == 0 && Input.GetKeyDown(KeyCode.Space))
//             {
//                 ContinueDialogue();
//             }
//         }
//     }

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             playerIsInTrigger = true;
//         }
//     }

//     void OnTriggerExit2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             playerIsInTrigger = false;
//         }
//     }

//     public void StartDialogue()
//     {
//         dialoguePanel.SetActive(true);
//         currentNode = 0;
//         ShowNode(dialogueNodes[currentNode]);
//     }

//     void ShowNode(DialogueNode node) 
//     {
//         dialogueText.text = node.dialogueText;

//         // Ẩn tất cả các nút trước khi hiển thị những cái cần thiết
//         foreach (var button in choiceButtons)
//         {
//             button.SetActive(false);
//         }

//         // Kích hoạt và cập nhật văn bản cho các nút lựa chọn dựa trên nội dung của node hiện tại
//         for (int i = 0; i < node.choices.Count; i++)
//         {
//             if (i < choiceButtons.Length)
//             {
//                 choiceButtons[i].SetActive(true);
//                 TextMeshProUGUI buttonText = choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>();
//                 if (buttonText != null)
//                 {
//                     buttonText.text = node.choices[i];
//                 }

//                 int nextNodeIndex = node.nextNodes[i];
//                 choiceButtons[i].GetComponent<Button>().onClick.RemoveAllListeners();
//                 choiceButtons[i].GetComponent<Button>().onClick.AddListener(() => SelectChoice(nextNodeIndex));
//             }
//         }
//     }


//     void SelectChoice(int nextNodeIndex)
//     {
//         if (nextNodeIndex < dialogueNodes.Count)
//         {
//             ShowNode(dialogueNodes[nextNodeIndex]);
//         }
//         else
//         {
//             EndDialogue();
//         }
//     }

//     void ContinueDialogue()
//     {
//         currentNode++;
//         if (currentNode < dialogueNodes.Count)
//         {
//             Debug.Log("node" + currentNode);
//             ShowNode(dialogueNodes[currentNode]);
//         }
//         else
//         {
//             Debug.Log("node" + currentNode);
//             EndDialogue(); // Kết thúc hội thoại nếu đây là node cuối cùng
//         }
//     }

//     void EndDialogue()
//     {
//         dialoguePanel.SetActive(false);
//     }
// }

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class DialogueNode
{
    public string dialogueText; // Văn bản hội thoại
    public List<string> choices; // Danh sách các lựa chọn văn bản
    public List<int> nextNodes; // Chỉ số của node tiếp theo tương ứng với mỗi lựa chọn
}

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject[] choiceButtons;
    public GameObject dialoguePanel;
    private int nextNodeIndex; // Biến mới để lưu trữ chỉ số của node tiếp theo
    public List<DialogueNode> dialogueNodes;
    private bool playerIsInTrigger = false;

    void Update()
    {
        if (playerIsInTrigger && Input.GetKeyDown(KeyCode.F) && !dialoguePanel.activeInHierarchy)
        {
            StartDialogue();
        }
        
        // Debug.Log("Node" + nextNodeIndex);
        // Debug.Log(dialogueNodes[nextNodeIndex].choices.Count);
        if (dialoguePanel.activeInHierarchy && dialogueNodes[nextNodeIndex].choices.Count == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            ContinueDialogue();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsInTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsInTrigger = false;
        }
    }

    public void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        nextNodeIndex = 0; // Bắt đầu từ node đầu tiên
        ShowNode(dialogueNodes[nextNodeIndex], nextNodeIndex);
    }

    void ShowNode(DialogueNode node, int nodeIndex) 
    {
        dialogueText.text = node.dialogueText;

        foreach (var button in choiceButtons)
        {
            button.SetActive(false);
        }

        Debug.Log("Node" + nodeIndex);
        Debug.Log(node.choices.Count);

        for (int i = 0; i < node.choices.Count; i++)
        {
            if (i < choiceButtons.Length)
            {
                choiceButtons[i].SetActive(true);
                TextMeshProUGUI buttonText = choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                if (buttonText != null)
                {
                    buttonText.text = node.choices[i];
                }

                int nextNodeIndex = node.nextNodes[i];
                choiceButtons[i].GetComponent<Button>().onClick.RemoveAllListeners();
                choiceButtons[i].GetComponent<Button>().onClick.AddListener(() => SelectChoice(nextNodeIndex));
            }
        }
    }

    void SelectChoice(int selectedNextNodeIndex)
    {
        nextNodeIndex = selectedNextNodeIndex; // Cập nhật chỉ số của node tiếp theo dựa trên lựa chọn

        if (nextNodeIndex < dialogueNodes.Count)
        {
            ShowNode(dialogueNodes[nextNodeIndex], nextNodeIndex);
        }
        else
        {
            EndDialogue();
        }
    }

    void ContinueDialogue()
    {
        nextNodeIndex++;
        if (nextNodeIndex < dialogueNodes.Count)
        {
            ShowNode(dialogueNodes[nextNodeIndex], nextNodeIndex);
        }
        else
        {
            EndDialogue(); // Kết thúc hội thoại nếu đây là node cuối cùng
        }
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
