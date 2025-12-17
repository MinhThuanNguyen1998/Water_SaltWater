using UnityEngine;
using UnityEngine.Rendering;

public abstract class StepBase : MonoBehaviour
{
    public int TotalSteps { get; protected set; }
    public int CurrentStep { get; protected set; }

    protected void ResolveStep()
    {
        int resolvedStep = CalculateStep();

        if (resolvedStep == CurrentStep)
            return;
        CurrentStep = resolvedStep;
        ExecuteCurrentStep();
    }
    protected abstract int CalculateStep();
    protected abstract void ExecuteCurrentStep();
    protected bool IsCompleted()
    {
        return CurrentStep >= TotalSteps;
    }
}
