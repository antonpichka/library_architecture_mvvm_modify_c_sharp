namespace library_architecture_mvvm_modify_c_sharp;

public class Doubles(double field) : BaseModel($"{field}")
{
    public readonly double field = field;

    public override Doubles GetClone()
    {
        return new Doubles(field);
    }

    public override string ToString()
    {
        return $"Doubles(field: {field}";
    }
}
