namespace ProjectRoadmap.SemanticChat.SharedKernel;

public interface IDomainEventDispatcher
{
    Task DispatchAndClearEvents(IEnumerable<IHaveDomainEvents> entitiesWithEvents);
}

