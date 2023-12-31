﻿using ErrorOr;
using MediatR;

namespace CrudTest.Application.Common.Interfaces.Messaging;

public interface ICommand<TResponse> : IRequest<ErrorOr<TResponse>> { }
