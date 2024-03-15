namespace library_architecture_mvvm_modify_c_sharp;

public class DatesTimes(DateTime dateTime) : BaseModel($"{dateTime}")
{
    public readonly DateTime dateTime = dateTime;

    public override DatesTimes GetClone()
    {
        return new DatesTimes(dateTime);
    }

    public override string ToString()
    {
        return $"DatesTimes(dateTime: {dateTime})";
    }
}
