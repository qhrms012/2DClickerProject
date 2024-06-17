using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Settings settings;
    public EnemySp enemySp;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

        settings = FindObjectOfType<Settings>();
        enemySp = FindObjectOfType<EnemySp>();
        
        if (settings == null)
        {
            Debug.LogError("Settings ��ü�� ã�� �� �����ϴ�.");
        }

        if (enemySp == null)
        {
            Debug.LogError("EnemySp ��ü�� ã�� �� �����ϴ�.");
        }
    }
}
