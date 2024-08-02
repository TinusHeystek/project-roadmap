using MediatR;

namespace ProjectRoadmap.SemanticChat.SharedKernel;

public abstract record IntegrationEventBase : INotification
{
    public DateTimeOffset DateTimeOffset { get; set; } = DateTimeOffset.UtcNow;
}

