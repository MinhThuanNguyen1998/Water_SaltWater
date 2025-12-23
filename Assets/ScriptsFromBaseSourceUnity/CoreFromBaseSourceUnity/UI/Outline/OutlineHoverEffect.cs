using UnityEngine;

[DisallowMultipleComponent]
public class OutlineHoverEffect: MonoBehaviour
{
    [SerializeField] private MyOutLine m_Outline;

    [Header("Object Type")]
    [Tooltip("Nếu bật, object này là loại có thể di chuyển.")]
    [SerializeField] private bool isMovable = false;

    // Shared settings cho toàn project
    private static OutlineSettingsSO sharedSettings;

    private void Awake()
    {
        // Lấy reference Outline
        if (m_Outline == null)
            m_Outline = GetComponent<MyOutLine>();

        // Load ScriptableObject chỉ 1 lần
        if (sharedSettings == null)
        {
            sharedSettings = Resources.Load<OutlineSettingsSO>("Settings/OutlineSettings");
            if (sharedSettings == null)
            {
                Debug.LogWarning("⚠️ OutlineSettings.asset not found in Resources/Settings/");
                return;
            }
        }

        if (m_Outline == null)
        {
            Debug.LogWarning($"⚠️ Outline component missing on {name}");
            return;
        }

        // Áp dụng cài đặt Outline tương ứng
        ApplyOutlineSettings();

        // Tắt mặc định để tiết kiệm performance
        m_Outline.enabled = false;
    }

    private void ApplyOutlineSettings()
    {
        if (isMovable)
        {
            m_Outline.OutlineColor = sharedSettings.movableColor;
            m_Outline.OutlineWidth = sharedSettings.movableWidth;

        }
        else
        {
            m_Outline.OutlineColor = sharedSettings.staticColor;
            m_Outline.OutlineWidth = sharedSettings.staticWidth;
        }
    }
    private void OnMouseEnter()
    {
        m_Outline.enabled = true;
    }

    private void OnMouseExit()
    {
        m_Outline.enabled = false;
    }
}


