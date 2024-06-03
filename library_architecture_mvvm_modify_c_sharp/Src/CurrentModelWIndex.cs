namespace library_architecture_mvvm_modify_c_sharp;

public sealed class CurrentModelWIndex<T>(T currentModel, int index) where T : BaseModel
{
    public readonly T currentModel = currentModel;
    public readonly int index = index;
}