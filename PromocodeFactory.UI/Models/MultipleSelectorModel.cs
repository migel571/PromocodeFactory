namespace PromocodeFactory.UI.Models
{
    public class MultipleSelectorModel
    {
        public MultipleSelectorModel(string key, string value)
        {
            Key = key;
            Value = value;

        }
        public string Key { get; set; }
        public string Value { get; set; }  
        public bool Selectable { get; set; }
    }
}
