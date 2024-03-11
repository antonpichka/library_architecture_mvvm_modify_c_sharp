namespace library_architecture_mvvm_modify_c_sharp;

public sealed class LocalException(object thisClass, EnumGuilty enumGuilty, string key, string message = "") : BaseException(thisClass, "LocalException", key)
{
    public readonly EnumGuilty enumGuilty = enumGuilty;
    public readonly string message = message;

    public override string ToString()
    {
        return $"LocalException(enumGuilty: {enumGuilty}, key: {key}, message (optional): {message})";
    }
}
