using UnityEngine;
using UnityEngine.UI;

public class ButtonToggleImage : MonoBehaviour
{
    public Sprite normalSprite;     // ��ư�� �� ������ �� �̹���
    public Sprite pressedSprite;    // ��ư�� ������ �� �̹���

    private Image buttonImage;      // ��ư�� Image ������Ʈ
    private bool isPressed = false; // ��ư�� ���� ����

    void Start()
    {
        // ��ư�� Image ������Ʈ ��������
        buttonImage = GetComponent<Image>();
    }

    public void OnButtonClick()
    {
        // ��ư�� Ŭ���� ������ Toggle ���� ����
        isPressed = !isPressed;

        // Toggle ���¿� ���� �̹��� ����
        if (isPressed)
        {
            // ���� ���� �̹����� ����
            if (pressedSprite != null)
            {
                buttonImage.sprite = pressedSprite;
            }
        }
        else
        {
            // �� ���� ���� �̹����� ����
            if (normalSprite != null)
            {
                buttonImage.sprite = normalSprite;
            }
        }
    }
}
