using UnityEngine;

public class BoardGrabber : MonoBehaviour
{
    public static BoardGrabber GrabberInstance { get; private set; }
    private void Awake()
    {
        GrabberInstance = this;
    }

    public void GetBoard()
    {
        
    }
}
