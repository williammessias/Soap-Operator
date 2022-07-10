namespace DemoOperator
{
    #region Usings
    using System.ServiceModel;
    #endregion

    /// <summary>
    /// Operator channel.
    /// </summary>
    public interface IOperatorChannel : IOperatorService, IClientChannel
    {
    }
}