using UnityEngine;
using UnityEngine.UI;

public class NPCAreaController : MonoBehaviour
{
    [SerializeField] private GameObject dialogPanel;
    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            dialogPanel.SetActive(true); // ��: DialogPanel Ȱ��ȭ
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialogPanel != null)
            {
                dialogPanel.SetActive(false); // DialogPanel ��Ȱ��ȭ
            }
        }
    }
}
