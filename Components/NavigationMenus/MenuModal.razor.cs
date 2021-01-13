using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using cc = CommonBasicStandardLibraries.BasicDataSettingsAndProcesses.SColorString;
namespace BasicBlazorLibrary.Components.NavigationMenus
{
    public partial class MenuModal
    {
        [Parameter]
        public string BackgroundColor { get; set; } = cc.Black.ToWebColor();
        [Parameter]
        public string TextColor { get; set; } = cc.White.ToWebColor();
        [Parameter]
        public string FontSize { get; set; } = "1.5rem";
        [Parameter]
        public string Height { get; set; } = "300px"; //default to 300 pixels but its flexible as well.
        [Parameter]
        public string Width { get; set; } = "50vmin";
        [Parameter]
        public string Right { get; set; } = "2px";
        [Parameter]
        public CustomBasicList<MenuItem> MenuList { get; set; } = new CustomBasicList<MenuItem>(); //can still show the list even with no items.
        [Parameter]
        public bool Visible { get; set; } = false;
        [Parameter]
        public EventCallback<bool> VisibleChanged { get; set; }
        private string GetFirstClass()
        {
            if (Visible == false)
            {
                return "hidden";
            }
            return "";
        }
        private void ClickOutside()
        {
            VisibleChanged.InvokeAsync(false); //had to be true or this click would not have worked.
        }
        private void ClickMenu(MenuItem menu)
        {
            ClickOutside(); //this first.
            menu.Clicked.Invoke();
        }
        private string GetMainStyle()
        {
            return $"width: {Width}; height: {Height}; right: {Right}; font-size: {FontSize}; background-color: {BackgroundColor}; color: {TextColor};";
        }
    }
}