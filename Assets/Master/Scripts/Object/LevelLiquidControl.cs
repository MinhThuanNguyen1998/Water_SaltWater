
using UnityEngine;

public class LevelLiquidControl : MonoBehaviour
{
    [SerializeField] private Renderer m_Renderer;
    private Material m_Material;
    private float m_DefaultFill = -0.3f;
    private float m_MaxFill = 0f;
    private float m_FillValue;
    public float CurrentFill
    {
        get => m_FillValue;
        set
        {
            m_FillValue = Mathf.Clamp01(value);
            UpdateFillLevel();
        }
    }
    private void Start()
    {
        if (m_Renderer != null) m_Material = m_Renderer.sharedMaterial;
        ResetFillLevel();
    }
    public void AddFill(float delta)
    {
        SetFill(m_FillValue + delta);
    }
    public void SetFill(float value)
    {
        m_FillValue = Mathf.Clamp(value, m_DefaultFill, m_MaxFill);
        UpdateFillLevel();
    }
    public void ResetFillLevel() => SetFill(m_DefaultFill);

    private void UpdateFillLevel() => m_Material?.SetFloat("_Fill", m_FillValue);
 
}

