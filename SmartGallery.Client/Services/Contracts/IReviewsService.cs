using SmartGallery.Shared.ViewModels.ReviewViewModels;

namespace SmartGallery.Client.Services.Contracts;

public interface IReviewsService
{
    Task<IEnumerable<ReviewDetailsVM>?> GetReviewsAsync();
    Task CreateReview(int reservationId, string customerId, ReviewForCreationVM reviewForCreationViewModel);
}

