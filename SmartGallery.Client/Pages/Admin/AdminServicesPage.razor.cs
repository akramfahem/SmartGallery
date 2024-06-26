﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using SmartGallery.Client.Services.Contracts;
using SmartGallery.Shared.ViewModels.ServiceViewModels;

namespace SmartGallery.Client.Pages.Admin;

[Authorize(Roles = "Admin")]
public partial class AdminServicesPage
{
    public List<ServiceViewModel> serviceViewModels { get; set; } = new();
	[Inject]
	public IServicesService servicesService { get; set; }
    [Inject]
    public NavigationManager navigationManager { get; set; }
    protected override async Task OnInitializedAsync()
    {
        serviceViewModels = (await servicesService.GetServices()).ToList();
        await base.OnInitializedAsync();
    }
    public void NavigateToReservation(int serviceId)
    {
        navigationManager.NavigateTo($"/admin/reservations/{serviceId}");
    }
    public async Task DeleteService(int id)
    {
        await servicesService.DeleteService(id);
        serviceViewModels = (await servicesService.GetServices()).ToList();
        await InvokeAsync(StateHasChanged);
    }
    public async Task UpdateService(int id)
    {
        navigationManager.NavigateTo($"/AddService/{id}");
        await InvokeAsync(StateHasChanged);
    }
    public void AddService()
    {
        navigationManager.NavigateTo($"/AddService");
    }
    public async Task NavigatoToItems(int id)
    {
        navigationManager.NavigateTo($"/admin/services/{id}");
        await InvokeAsync(StateHasChanged);
    }
}

