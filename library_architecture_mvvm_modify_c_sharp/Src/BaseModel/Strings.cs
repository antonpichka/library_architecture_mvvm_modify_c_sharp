namespace library_architecture_mvvm_modify_c_sharp;

public class Strings(string field) : BaseModel(field)
{
    public readonly string field = field;

    public override Strings GetClone()
    {
        return new Strings(field);
    }

    public override string ToString()
    {
        return $"Strings(field: {field}";
    }
}
