using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                // 컴포넌트를 가지고 있는 오브젝트를 찾기
                _instance = (T)FindAnyObjectByType(typeof(T));

                if (_instance == null) // 그럼에도 인스턴스를 찾지 못한 경우
                {
                    // 컴포넌트를 가지는 오브젝트 생성
                    GameObject obj = new GameObject(typeof(T).Name, typeof(T));
                    // 오브젝트에 해당 컴포넌트 저장
                    _instance = obj.GetComponent<T>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        // 컴포넌트를 가지는 오브젝트의 자식, 부모 판별
        if (transform.parent != null && transform.root != null) // 해당 오브젝트가 자식 오브젝트라면
        {
            DontDestroyOnLoad(this.transform.root.gameObject); // 부모 오브젝트를 DontDestroyOnLoad 처리
        }
        else
        {
            DontDestroyOnLoad(this.gameObject); // 해당 오브젝트가 최 상위 오브젝트라면 자신을 DontDestroyOnLoad 처리
        }
    }
}
