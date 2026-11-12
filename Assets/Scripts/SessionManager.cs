using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public static SessionManager Instance;
    public string playerName;
    public int bestScore;
    void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        Instance=this;
        DontDestroyOnLoad(Instance);
    }
}
