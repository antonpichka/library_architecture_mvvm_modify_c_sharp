namespace library_architecture_mvvm_modify_c_sharp;

public sealed class NamedCallback(string name, dynamic callback)
{
    public readonly string name = name;
    
    public readonly dynamic callback = callback;
}