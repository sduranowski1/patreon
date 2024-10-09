using Microsoft.AspNetCore.Components;

namespace blazorblog.Shared
{
    public class ProtectedPageBase : ComponentBase
    {
        [Inject] public AuthService AuthService { get; set; }
        [Inject] public NavigationManager Navigation { get; set; }

        protected override async Task OnInitializedAsync()
        {
            bool isLoggedIn = await AuthService.IsLoggedIn();

            if (!isLoggedIn)
            {
                // Redirect to login if not authenticated
                Navigation.NavigateTo("/login");
            }
        }
    }
}

