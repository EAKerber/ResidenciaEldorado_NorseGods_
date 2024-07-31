using UnityEngine;

public class MouseSimulator : MonoBehaviour
{
    public Rect screenRect;
    public Texture2D cursorTexture;

    private Vector3 mousePosition;

    void Start()
    {
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 rawMousePosition = Input.mousePosition;
        mousePosition = ClampMousePosition(rawMousePosition);
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(mousePosition.x - cursorTexture.width / 2, Screen.height - mousePosition.y - cursorTexture.height / 2, cursorTexture.width, cursorTexture.height), cursorTexture);
    }

    Vector3 ClampMousePosition(Vector3 pos)
    {
        pos.x = Mathf.Clamp(pos.x, screenRect.xMin, screenRect.xMax);
        pos.y = Mathf.Clamp(pos.y, screenRect.yMin, screenRect.yMax);
        return pos;
    }
}
