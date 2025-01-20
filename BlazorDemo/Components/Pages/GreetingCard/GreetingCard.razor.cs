using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Components.Pages.GreetingCard
{
    public partial class GreetingCard : ComponentBase
    {
        public string? Name { get; set; }
        public bool ShowInfo { get; set; } = false;

        public void HandleClick()
        {
            ShowInfo = !ShowInfo;
            if(ShowInfo)
            {
                Name = "Duong";
            }
        }
    }
}
