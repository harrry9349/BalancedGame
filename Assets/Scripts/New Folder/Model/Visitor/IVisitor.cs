public interface IVisitor
{
    public void Visit(FallOutAcceptor falloutAcceptor);
    public void Visit(GoalAcceptor goalAcceptor);
    public void Visit(RelayAcceptor relayAcceptor);
}
