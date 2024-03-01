using System.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SmartGallery.Client.Services;
using SmartGallery.Client.Services.Contracts;
using SmartGallery.Shared;
using SmartGallery.Shared.ViewModels.ItemViewModels;
using SmartGallery.Shared.ViewModels.ReservationViewModels;

namespace SmartGallery.Client.Pages.Reservations;

public partial class ReservationsPage
{
    [Parameter]
    public int serviceId { get; set; }
    [Parameter]
    public int Id { get; set; }

    StatusEnum statusEnum { get; set; } = StatusEnum.Pending;
    bool isSuccess { get; set; }
    bool isFailed { get; set; }
    public ReservationDetailsVM viewModel { get; set; } = new();
    List<ItemViewModel> itemViewModels { get; set; } = new();
    ItemViewModel SelectedItem { get; set; } = new();
    [Inject] IReservationsService _reservationsService { get; set; }
    [Inject] ILoginService _loginService { get; set; }
    [Inject] IServiceItemsService _serviceItemsService { get; set; }
    [Inject] NavigationManager _navigationManager { get; set; }
    [Inject] AuthenticationStateProvider _authenticationStateProvider { get; set;}
    public string MessageToShow { get; set; } = " ";
    protected override async Task OnInitializedAsync()
    {
        if(Id is not default(int))
        {
            viewModel = await _reservationsService.GetReservationByIdAsync(Id);
        }
        viewModel.ReservationDate =DateOnly.FromDateTime(DateTime.Now);
        viewModel.ReservationTime = TimeOnly.FromDateTime(DateTime.Now);
            
        itemViewModels = (await _serviceItemsService.GetItemsForServiceAsync(serviceId)).ToList();
        await InvokeAsync(StateHasChanged);
        await base.OnInitializedAsync();
    }
    public async Task HandleValidSubmitAsync()
    {
        ReservationForUpdateViewModel reservationForUpdateViewModel = new()
        {
            ProblemDescription = viewModel.ProblemDescription,
            ReservationDate = viewModel.ReservationDate,
            ReservationTime = viewModel.ReservationTime,
            Status = statusEnum,
            ItemId = SelectedItem.Id == 0 ? null : SelectedItem.Id
        };
        if (Id is not default(int))
        {
        await _reservationsService.UpdateReservationAsync(Id, reservationForUpdateViewModel
        );
        _navigationManager.NavigateTo("/Profile");
        }
        else
        {
            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authenticationState.User;
            string userId = user.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
            ReservationForCreationViewModel reservationForCreationViewModel = new()
            {
                ProblemDescription = viewModel.ProblemDescription,
                ReservationDate = viewModel.ReservationDate,
                ReservationTime = viewModel.ReservationTime,
                ItemId = SelectedItem.Id == 0 ? null : SelectedItem.Id
            };
            var response = await _reservationsService.CreateReservation(serviceId,userId,reservationForCreationViewModel);
            if (response is not null)
            {
                isSuccess = true;
                MessageToShow = "Your Reservation Was Done Successfully";
                await InvokeAsync(StateHasChanged);
                await Task.Delay(TimeSpan.FromSeconds(1.5));
                _navigationManager.NavigateTo("/");
            }
            else
            {
                isFailed = true;
                MessageToShow = "You Already Done A Reservation If you want something else Please Add it to your Old Reservation";
            }
            await InvokeAsync(StateHasChanged);
        }
    }
    private async Task LogoutAsync()
    {
        await _loginService.LogoutAsync();
        _navigationManager.NavigateTo("/");
    }
    private void NavigateToHome()
    {
        _navigationManager.NavigateTo("/");
    }

}

