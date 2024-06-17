using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 1.0f;
    public GameObject[] backgrounds;
    private Vector3[] startPositions;
    private float repeatWidth;

    private void Start()
    {
        startPositions = new Vector3[backgrounds.Length];
        repeatWidth = backgrounds[0].GetComponent<Renderer>().bounds.size.x; // 모든 배경의 너비 동일하다고 가정

        // 초기 위치 저장
        for (int i = 0; i < backgrounds.Length; i++)
        {
            startPositions[i] = backgrounds[i].transform.position;
        }
    }

    private void Update()
    {
        // 모든 배경을 왼쪽으로 이동
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

            // 배경이 반복되도록 처리
            if (backgrounds[i].transform.position.x < startPositions[i].x - repeatWidth)
            {
                RepositionBackground(i);
            }
        }
    }

    private void RepositionBackground(int index)
    {
        // 배경을 처음 위치로 되돌림
        backgrounds[index].transform.position = startPositions[index] + Vector3.right * repeatWidth;
    }
}
