using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using SmartGallery.Client.Services.Contracts;
using SmartGallery.Shared.ViewModels.ItemViewModels;

namespace SmartGallery.Client.Pages.Services;

[Authorize(Roles = "Admin")]
public partial class ServiceItemsPage
{
    [Parameter]
    public int ServiceId { get; set; }
    
    public ItemCreateUpdateViewModel viewModel { get; set; } = new();
    [Inject] NavigationManager _navigationManager { get; set; }
    [Inject] ILoginService _loginService { get; set; }
    [Inject] IServiceItemsService _serviceItemsService { get; set; }

    private async Task LogoutAsync()
    {
        await _loginService.LogoutAsync();
        _navigationManager.NavigateTo("/");
    }
    private void NavigateToHome()
    {
        _navigationManager.NavigateTo("/");
    }
    private async Task HandleValidSubmitAsync()
    {
        await _serviceItemsService.CreateItemForServiceAsync(ServiceId,viewModel);
        _navigationManager.NavigateTo($"/admin/services/{ServiceId}");
        await InvokeAsync(StateHasChanged);
    }
}
