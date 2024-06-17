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
        repeatWidth = backgrounds[0].GetComponent<Renderer>().bounds.size.x; // ��� ����� �ʺ� �����ϴٰ� ����

        // �ʱ� ��ġ ����
        for (int i = 0; i < backgrounds.Length; i++)
        {
            startPositions[i] = backgrounds[i].transform.position;
        }
    }

    private void Update()
    {
        // ��� ����� �������� �̵�
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

            // ����� �ݺ��ǵ��� ó��
            if (backgrounds[i].transform.position.x < startPositions[i].x - repeatWidth)
            {
                RepositionBackground(i);
            }
        }
    }

    private void RepositionBackground(int index)
    {
        // ����� ó�� ��ġ�� �ǵ���
        backgrounds[index].transform.position = startPositions[index] + Vector3.right * repeatWidth;
    }
}
