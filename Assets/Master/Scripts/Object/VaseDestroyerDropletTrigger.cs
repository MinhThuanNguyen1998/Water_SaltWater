using UnityEngine;

public class VaseDestroyerDropletTrigger : BaseTrigger
{
    [SerializeField] private LevelLiquidControl m_LevelLiquidVaseControl;
    private float m_FillValue = 0.01f;
    private float m_MaxFillValue = 0.2f;
    protected override void OnEnter(Collider other)
    {
        if (other.gameObject.tag == "Droplet")
        {
            float newFill = Mathf.Clamp(m_LevelLiquidVaseControl.CurrentFill + m_FillValue, 0f, m_MaxFillValue);
            m_LevelLiquidVaseControl.ControlFillLevel(newFill);
            Destroy(other.gameObject);

        }

    }
}
