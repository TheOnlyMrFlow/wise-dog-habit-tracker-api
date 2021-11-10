namespace TWD.HabitTracker.Application.Common;

public abstract class UseCaseInteractor<TRequest, TResponse, TPresenter>
    where TResponse : IUseCaseResponse
    where TPresenter : IUseCasePresenter<TResponse>
{
    protected TPresenter? Presenter;

    protected TRequest? Request;

    public UseCaseInteractor<TRequest, TResponse, TPresenter> SetPresenter(TPresenter presenter)
    {
        Presenter = presenter;

        return this;
    }

    public UseCaseInteractor<TRequest, TResponse, TPresenter> SetRequest(TRequest request)
    {
        Request = request;

        return this;
    }

    public abstract Task InvokeAsync();
}