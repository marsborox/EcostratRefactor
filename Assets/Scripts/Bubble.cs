using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(DestroySelf);
    }
    private void Start()
    {
        button.onClick.AddListener(GameManager.instance.AddMoney);
        button.onClick.AddListener(SoundManager.instance.Click);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
