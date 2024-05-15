public record CountryTestModel(string Id, string Code, string Name, string DefaultCurrency, string DefaultLocale);
public class Repository
{
    List<CountryTestModel> data = new List<CountryTestModel>();
    int index = 1;

    public async Task<CountryTestModel> Add(CountryTestModel model)
    {
        var item = new CountryTestModel(index++.ToString(), model.Code, model.Name, model.DefaultCurrency, model.DefaultLocale);
        data.Add(item);
        return item;
    }
    public async Task<bool> Update(string id, CountryTestModel model)
    {
        var current = data.First(a => a.Id == id);
        if (current is null)
            return false;
        else
        {
            var updatedItem = new CountryTestModel(current.Id, model.Code, model.Name, model.DefaultCurrency, model.DefaultLocale);
            data[data.IndexOf(current)] = updatedItem;
            return true;
        }
    }
    public async Task<bool> Delete(string id)
    {
        var item = data.First(a => a.Id == id);
        if (item is null)
            return false;
        else
        {
            data.Remove(item);
            return true;
        }
    }
    public async Task<CountryTestModel> GetById(string id)
    {
        return data.FirstOrDefault(a => a.Id == id);
    }
    public async Task<List<CountryTestModel>> GetAll()
    {
        return data;
    }

}
