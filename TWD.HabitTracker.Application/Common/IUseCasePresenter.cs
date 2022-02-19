namespace TWD.HabitTracker.Application.Common;

public interface IUseCasePresenter<in TUseCaseResponse> where TUseCaseResponse : IUseCaseResponse
{
    void Success(TUseCaseResponse response);
}