namespace library_architecture_mvvm_modify_c_sharp;

public interface IIterator<T>
{
    public T Current();

    public bool MoveNext();
}
