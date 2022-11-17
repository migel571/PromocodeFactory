using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Tables
{
    public partial class MultipleSelector
    {
        private string removeAll = "<<";
        [Parameter]
        public List<MultipleSelectorModel> NoSelected { get; set; } = new List<MultipleSelectorModel>();
        [Parameter]
        public List<MultipleSelectorModel> Selected { get; set; } = new List<MultipleSelectorModel>();

        private void Select(MultipleSelectorModel item)
        {
            NoSelected.Remove(item);
            Selected.Add(item);  
        }
        private void Deselect(MultipleSelectorModel item)
        {
            Selected.Remove(item);
            NoSelected.Add(item);
        }
        private void DeselectAll()
        {
            NoSelected.AddRange(Selected);
            Selected.Clear();
        }
        private void SelectAll()
        {
            Selected.AddRange(NoSelected);
            NoSelected.Clear();
        }
    }
}
