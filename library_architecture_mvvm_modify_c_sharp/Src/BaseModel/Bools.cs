namespace library_architecture_mvvm_modify_c_sharp;

public class Bools(bool isField) : BaseModel($"{isField}")
{
    public readonly bool isField = isField;

    public override Bools GetClone()
    {
        return new Bools(isField);
    }

    public override string ToString()
    {
        return $"Bools(isField: {isField}";
    }
}
