using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform m_Target;
    [SerializeField] Vector3 m_Offset = new Vector3(0, 8, -8);

    // Update is called once per frame
    void Update()
    {
        transform.position = m_Target.position + m_Offset;        
    } 
}
