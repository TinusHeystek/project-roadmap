namespace ProjectRoadmap.SemanticChat.SharedKernel;

public interface IHaveDomainEvents
{
    IEnumerable<DomainEventBase> DomainEvents { get; }
    void ClearDomainEvents();
}

