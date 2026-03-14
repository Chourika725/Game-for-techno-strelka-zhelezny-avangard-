using UnityEngine;

public class SteamEngine : MonoBehaviour
{
    public static SteamEngine Instance;
    // Update is called once per frame
   public bool canMove= true;
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        FrameMovementControll.Instance.speed = 10f;
    }
}
