using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using SmartGallery.Client.Services.Contracts;
using SmartGallery.Shared.ViewModels.ItemViewModels;

namespace SmartGallery.Client.Pages.Services;

[Authorize(Roles = "Admin")]
public partial class ServiceItemsViewPage
{
    public List<ItemViewModel> itemsViewModel { get; set; } = new();
    [Parameter]
    public int ServiceId { get; set; }
    [Inject]
    NavigationManager navigationManager { get; set; }
    [Inject] IServiceItemsService _serviceItemsService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        itemsViewModel = (await _serviceItemsService.GetItemsForServiceAsync(ServiceId)).ToList();
        await base.OnInitializedAsync();
    }
    public void AddServiceItem()
    {
        navigationManager.NavigateTo($"/AddServiceItems/{ServiceId}");
    }
    public void DeleteService(int Id)
    {
        _serviceItemsService.DeleteItemForServiceAsync(ServiceId, Id);
    }
}

