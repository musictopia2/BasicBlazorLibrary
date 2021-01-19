using BasicBlazorLibrary.Components.ComboTextboxes;
using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
namespace BasicBlazorLibrary.Components.Inputs
{
    public partial class InputEnterComboNumberLists
    {
        private ComboBoxStringList? _combo;
        private string _textDisplay = "";
        private readonly CustomBasicList<string> _list = new CustomBasicList<string>();
        protected override void OnInitialized()
        {
            _combo = null;
            base.OnInitialized();
        }
        protected override void OnParametersSet()
        {
            _list.Clear();
            ItemList!.ForEach(item =>
            {
                _list.Add(item.ToString());
            });
            ItemList.Sort(); //i think this needs to sort as well.
            int index = ItemList.IndexOf(Value);
            if (index == -1 && RequiredFromList)
            {
                _textDisplay = "";
            }
            else if (index == -1 && Value == 0)
            {
                _textDisplay = ""; //i think it should not diplay 0.
            }
            else if (index == -1)
            {
                _textDisplay = Value.ToString(); //maybe this is it now.
            }
            else
            {
                _textDisplay = _list[index];
            }
        }
        [Parameter]
        public CustomBasicList<int>? ItemList { get; set; }
        [Parameter]
        public bool RequiredFromList { get; set; } = true; //if not required, then if you enter and its not on the list, then listindex would be -1 and you can still keep typing away.
        [Parameter]
        public ComboStyleModel Style { get; set; } = new ComboStyleModel();
        [Parameter]
        public bool Virtualized { get; set; } = false;
        private void TextChanged(string value)
        {
            var index = _list.IndexOf(value);
            if (index == -1)
            {
                if (RequiredFromList)
                {
                    _textDisplay = "";
                    return; //because not there.
                }
                bool rets = int.TryParse(value, out int aa);
                if (rets == false)
                {
                    _textDisplay = "";
                    return;
                }
                ValueChanged.InvokeAsync(aa); //i think.
                return;
            }
            ValueChanged.InvokeAsync(ItemList![index]);
        }
        protected override Task OnFirstRenderAsync()
        {
            InputElement = _combo!.GetTextBox;
            return base.OnFirstRenderAsync();
        }
    }
}