namespace SmartGallery.Shared.ViewModels.ReservationViewModels;

public class ReservationForUpdateViewModel : ReservationForManipulationViewModel
{
    public StatusEnum Status { get; set; }
    public int? ItemId { get; set; }
}
