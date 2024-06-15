using UnityEngine;
using UnityEngine.UI;

public class ButtonToggleImage : MonoBehaviour
{
    public Sprite normalSprite;     // 버튼이 안 눌렸을 때 이미지
    public Sprite pressedSprite;    // 버튼이 눌렸을 때 이미지

    private Image buttonImage;      // 버튼의 Image 컴포넌트
    private bool isPressed = false; // 버튼의 눌림 상태

    void Start()
    {
        // 버튼의 Image 컴포넌트 가져오기
        buttonImage = GetComponent<Image>();
    }

    public void OnButtonClick()
    {
        // 버튼을 클릭할 때마다 Toggle 상태 변경
        isPressed = !isPressed;

        // Toggle 상태에 따라 이미지 변경
        if (isPressed)
        {
            // 눌린 상태 이미지로 변경
            if (pressedSprite != null)
            {
                buttonImage.sprite = pressedSprite;
            }
        }
        else
        {
            // 안 눌린 상태 이미지로 변경
            if (normalSprite != null)
            {
                buttonImage.sprite = normalSprite;
            }
        }
    }
}
