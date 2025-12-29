using UnityEngine;

public class VaseDestroyerDropletTrigger : BaseTrigger
{
    [SerializeField] private LevelLiquidControl m_LevelLiquidVaseControl;
    private float m_FillValue = 0.02f;
   
    protected override void OnEnter(Collider other)
    {
        if (other.gameObject.tag == "Droplet")
        {
            m_LevelLiquidVaseControl.AddFill(m_FillValue);
            AudioMainManager.Instance.PlayOnShot(SoundType.WaterDrip);
            Destroy(other.gameObject);
        }

    }
}
