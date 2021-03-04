using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace BasicBlazorLibrary.Components.Basic
{
    public partial class NumberComponent
    {
        [Parameter]
        public int Value { get; set; } = 0;
        [Parameter]
        public EventCallback<int> ValueChanged { get; set; }
        //this does not tie to any specific form.

        [Parameter]
        public string Class { get; set; } = "";
        [Parameter]
        public string Style { get; set; } = "";
        //this is oninput always though.

        private int CurrentValue
        {
            get => Value;
            set
            {
                var hasChanged = !EqualityComparer<int>.Default.Equals(value, Value);
                if (hasChanged)
                {
                    ValueChanged.InvokeAsync(value);
                }
            }
        }
    }
}