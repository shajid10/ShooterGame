using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance;
    [SerializeField] private DynamicJoystick m_DynamicJoystick;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    public Vector2 GetInputVector()
    {
        return m_DynamicJoystick.Direction;
    }

    public Vector2 GetInputVectorNormalized()
    {
        return GetInputVector().normalized;
    }
}
