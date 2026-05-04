using System.Collections;
using UnityEngine;

public class EnemyFlash : MonoBehaviour {
    [SerializeField] private Color m_FlashColor = Color.white;
    [SerializeField] private float m_FlashDuration = 0.5f;

    private Renderer _renderer;
    private Color _originalColor;

    private void Start()
    {
        if  (_renderer == null) _renderer = GetComponentInChildren<Renderer>();
        _originalColor = _renderer.material.color;
    }

    public void Flash()
    {
        StartCoroutine(FlashCoroutine());
    }
    
    private IEnumerator FlashCoroutine()
    {
        _renderer.material.color = m_FlashColor;
        yield return new WaitForSeconds(m_FlashDuration);
        _renderer.material.color = _originalColor;
    }
}
