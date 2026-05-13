using System.Collections;
using UnityEngine;

public class EnemyFlash : MonoBehaviour {
    [SerializeField] private Color m_FlashColor = Color.white;
    [SerializeField] private float m_FlashDuration = 0.5f;

    private Renderer _renderer;
    private Color _originalColor;
    private MaterialPropertyBlock _propertyBlock;

    private static readonly int ColorID = Shader.PropertyToID("_BaseColor");
    
    private void Start()
    {
        if  (_renderer == null) _renderer = GetComponentInChildren<Renderer>();
        _originalColor = _renderer.sharedMaterial.color;
        
        _propertyBlock = new MaterialPropertyBlock();
        _renderer.GetPropertyBlock(_propertyBlock);
    }

    public void Flash()
    {
        StartCoroutine(FlashCoroutine());
    }

    private IEnumerator FlashCoroutine()
    {
        _propertyBlock.SetColor(ColorID,  m_FlashColor);
        _renderer.SetPropertyBlock(_propertyBlock);
        
        yield return new WaitForSeconds(m_FlashDuration);
        
        _propertyBlock.SetColor(ColorID, _originalColor);
        _renderer.SetPropertyBlock(_propertyBlock);
    }
}
