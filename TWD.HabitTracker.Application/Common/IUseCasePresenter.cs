namespace TWD.HabitTracker.Application.Common
{
    public interface IUseCasePresenter<in TUseCaseResponse> where TUseCaseResponse : IUseCaseResponse
    {
        void PresentSuccess(TUseCaseResponse response);

        void PresentUnknownError();
    }
}