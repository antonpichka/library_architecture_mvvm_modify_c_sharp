using library_architecture_mvvm_modify_c_sharp;

namespace IteratorTestMain;

public class UserBalance(string username, int money) : BaseModel(username) 
{
    public readonly string username = username;
    public readonly int money = money;

    public override UserBalance GetClone()
    {
        return new UserBalance(username,money);
    }

    public override string ToString()
    {
        return $"UserBalance(username: {username}, money: {money})";
    }
}

public class ListUserBalance<T>(List<T> listModel) : BaseListModel<T>(listModel) where T : UserBalance
{
    public override ListUserBalance<T> GetClone()
    {   
        List<T?> newListModel = [];
        foreach(T model in listModel)
        {
            newListModel.Add(model.GetClone() as T);
        }
        return new ListUserBalance<T>(newListModel!);
    }

    public override string ToString()
    {
        string strListModel = "\n";
        foreach(T model in listModel) 
        {
            strListModel += $"{model},\n";
        }
        return $"ListUserBalance(listModel: [{strListModel}])";
    }
}

public class UserBalanceWOrderByDescWMoneyIterator<T> : BaseModelWNamedWNamedWNamedIterator<T> where T : UserBalance 
{
    protected override CurrentModelWIndex<T> CurrentModelWIndex()
    {
        T? clone = listModelIterator[0].GetClone() as T;
        if(listModelIterator.Count <= 1) 
        {
            return new CurrentModelWIndex<T>(clone!,0);
        }
        int indexRemove = 0;
        for(int i = 1; i < listModelIterator.Count; i++) 
        {
            var itemModelIterator = listModelIterator[i];
            if(itemModelIterator.money > clone?.money) 
            {
                clone = itemModelIterator.GetClone() as T;
                indexRemove = i;
                continue;
            }
        }
        return new CurrentModelWIndex<T>(clone!,indexRemove);
    }
}

public class IteratorTestMain
{
    public static void Main() 
    {
        var listUserBalance = new ListUserBalance<UserBalance>([]);
        listUserBalance.InsertListFromNewListModelParameterListModel([
            new UserBalance("Jone", 3),
            new UserBalance("Freddy", 1),
            new UserBalance("Mitsuya", 10),
            new UserBalance("Duramichi", 5),
            new UserBalance("Hook", 7),
            new UserBalance("Sexy", -1),
        ]);
        Utility.DebugPrint($"Before: {listUserBalance}"); // 3, 1, 10, 5, 7, -1
        var userBalanceWOrderByDescWMoneyIterator = new UserBalanceWOrderByDescWMoneyIterator<UserBalance>();
        listUserBalance.SortingFromModelWNamedWNamedWNamedIteratorParameterListModel(userBalanceWOrderByDescWMoneyIterator);
        Utility.DebugPrint($"After: {listUserBalance}"); // 10, 7, 5, 3, 1, -1
        listUserBalance.UpdateFromNewModelParameterListModel(new UserBalance("Duramichi", 15));
        listUserBalance.SortingFromModelWNamedWNamedWNamedIteratorParameterListModel(userBalanceWOrderByDescWMoneyIterator);
        Utility.DebugPrint($"After(Two): {listUserBalance}"); // 15, 10, 7, 3, 1, -1
        listUserBalance.DeleteFromUniqueIdByModelParameterListModel("Mitsuya");
        listUserBalance.SortingFromModelWNamedWNamedWNamedIteratorParameterListModel(userBalanceWOrderByDescWMoneyIterator);
        Utility.DebugPrint($"After(Three): {listUserBalance}"); // 15, 7, 3, 1, -1
    }
}
// EXPECTED OUTPUT:
//
// Before: ListUserBalance(listModel: [       
// UserBalance(username: Jone, money: 3),     
// UserBalance(username: Freddy, money: 1),   
// UserBalance(username: Mitsuya, money: 10), 
// UserBalance(username: Duramichi, money: 5),
// UserBalance(username: Hook, money: 7),        
// UserBalance(username: Sexy, money: -1),    
// ])
// After: ListUserBalance(listModel: [        
// UserBalance(username: Mitsuya, money: 10), 
// UserBalance(username: Hook, money: 7),     
// UserBalance(username: Duramichi, money: 5),
// UserBalance(username: Jone, money: 3),
// UserBalance(username: Freddy, money: 1),
// UserBalance(username: Sexy, money: -1),
// ])
// After(Two): ListUserBalance(listModel: [
// UserBalance(username: Duramichi, money: 15),
// UserBalance(username: Mitsuya, money: 10),
// UserBalance(username: Hook, money: 7),
// UserBalance(username: Jone, money: 3),
// UserBalance(username: Freddy, money: 1),
// UserBalance(username: Sexy, money: -1),
// ])
// After(Three): ListUserBalance(listModel: [
// UserBalance(username: Duramichi, money: 15),
// UserBalance(username: Hook, money: 7),
// UserBalance(username: Jone, money: 3),
// UserBalance(username: Freddy, money: 1),
// UserBalance(username: Sexy, money: -1),
// ])