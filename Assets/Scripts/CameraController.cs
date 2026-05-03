using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] Vector3 offset = new Vector3(0, 8, -8);

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;        
    } 
}
