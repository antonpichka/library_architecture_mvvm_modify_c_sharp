namespace library_architecture_mvvm_modify_c_sharp;

public class Ints(int field) : BaseModel($"{field}")
{
    public readonly int field = field;

    public override Ints GetClone()
    {
        return new Ints(field);
    }

    public override string ToString()
    {
        return $"Ints(field: {field})";
    }
}
