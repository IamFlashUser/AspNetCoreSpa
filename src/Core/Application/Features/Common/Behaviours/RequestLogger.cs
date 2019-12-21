﻿using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using AspNetCoreSpa.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Abstractions;

namespace AspNetCoreSpa.Application.Common.Behaviours
{
    public class Test<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;

        public Test(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            _logger.LogInformation("AspNetCoreSpa Request: {Name} {@UserId} {@Request}", 
                name, _currentUserService.UserId, request);

            return Task.CompletedTask;
        }
    }
}