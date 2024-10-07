using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SmartGallery.Client.Services.Contracts;
using SmartGallery.Shared.ViewModels.ReviewViewModels;

namespace SmartGallery.Client.Pages
{
	public partial class AddReview
	{
        [Parameter]
        public int ReservationId { get; set; }

        private int selectedVal = 0;
        private int? activeVal;


        private string LabelText => (activeVal ?? selectedVal) switch
        {
            1 => "Very bad",
            2 => "Bad",
            3 => "Sufficient",
            4 => "Good",
            5 => "Awesome!",
            _ => "Rate our product!"
        };
        public string? userId { get; set; }
        public bool isSuccess { get; set; }
        public ReviewForCreationVM viewModel { get; set; } = new();
        [Inject]public  ILoginService _loginService { get; set; }
        [Inject] public IReviewsService _reviewsService { get; set; }
        [Inject]public NavigationManager _navigationManager { get; set; }
        [Inject] AuthenticationStateProvider _authenticationStateProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authenticationState.User;
            userId = user.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
            await base.OnInitializedAsync();
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
        private async Task HandleValidSubmitAsync()
        {
            viewModel.Rating = selectedVal;
            await _reviewsService.CreateReview(ReservationId, userId, viewModel);
            _navigationManager.NavigateTo($"/Profile/{userId}");

        }

        private void HandleHoveredValueChanged(int? val) => activeVal = val;


    }
}

