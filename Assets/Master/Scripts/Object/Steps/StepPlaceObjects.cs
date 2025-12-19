using UnityEngine;

public class StepPlaceObjects : StepBase
{
    public bool IsStandPlaced { get; private set; }
    public bool PipeConnectorPlaced { get; private set; }
    public bool IsVasePlaced { get; private set; }
    public bool BurnerUsed { get; private set; }
    private void OnEnable()
    {
        TotalSteps = 4;
        ResolveStep();
        MouseDragLock.Unblock();
        MouseDragLock.UnLockAfterStepsCompleted();
    }

    protected override int CalculateStep()
    {
        if (!IsStandPlaced)
            return 0; // Place stand
        if (!PipeConnectorPlaced)
            return 1; // Place pipeconnector
        if (!IsVasePlaced)
            return 2;  // Place vase
        if (!BurnerUsed)
            return 3; // Burner
        return 4; // Completed
    }
    protected override void ExecuteCurrentStep()
    {
        Debug.Log($"Step Place Objects - CurrentStep: {CurrentStep}");
        switch (CurrentStep)
        {
            case 0:
                Debug.Log("Step 0: Place flask");
                StepTutorialManager.Instance.GotoState(0);
                break;
            case 1:
                Debug.Log("Step 1: Place condenser");
                StepTutorialManager.Instance.GotoState(1);
                break;
            case 2:
                Debug.Log("Step 2: Place vase");
                StepTutorialManager.Instance.GotoState(2);
                break;
            case 3:
                Debug.Log("Step 3: Use burner");
                StepTutorialManager.Instance.GotoState(3);
                break;
            case 4:
                Debug.Log("All steps completed");
                StepTutorialManager.Instance.GotoState(4);
                break;
        }
    }
    public void SetStandPlaced(bool value)
    {
        IsStandPlaced = value;
        ResolveStep();
    }
    public void SetPipeConnectorPlaced(bool value)
    {
        PipeConnectorPlaced = value;
        ResolveStep();
    }
    public void SetVasePlaced(bool value)
    {
        IsVasePlaced = value;
        ResolveStep();
    }
    public void SetBurnerUsed(bool value)
    {
        BurnerUsed = value;
        ResolveStep();
    }
}

