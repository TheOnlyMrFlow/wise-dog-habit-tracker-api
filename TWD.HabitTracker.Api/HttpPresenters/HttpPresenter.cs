using Microsoft.AspNetCore.Mvc;
using TWD.HabitTracker.Application.Common;

namespace TWD.HabitTracker.Api.HttpPresenters;

public abstract class HttpPresenter<T> : IUseCasePresenter<T> where T : IUseCaseResponse
{
    public IActionResult? Result { get; protected set; }

    public abstract void Success(T response);
}