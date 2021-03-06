using CommonBasicStandardLibraries.Exceptions;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Net.Http;

namespace BasicBlazorLibrary.Components.Tabs
{
    public partial class TabPage
    {
        //most of the time, this would be used.
        //however, there is a navigation version of it as well.

        [CascadingParameter]
        private ITabContainer? TabContainer { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }



        //private string GetDisplay
        //{
        //    get
        //    {
        //        string output = TabContainer!.ActivePage == this ? "1" : "0";
        //        Console.WriteLine(output);
        //        Console.WriteLine(Text);
        //        return output;
        //    }
        //}


        private string GetDisplay => TabContainer!.ActivePage == this ? "" : "none";

        [Parameter]
        public string Text { get; set; } = "";

        protected override void OnInitialized()
        {
            if (TabContainer == null)
            {
                throw new BasicBlankException("Needs tab container");
            }
            base.OnInitialized();
            TabContainer.AddPage(this);
        }

    }
}