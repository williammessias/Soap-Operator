 
namespace DemoOperator
{
    #region Usings
    using System.ServiceModel;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Operator service.
    /// </summary>
    [ServiceContract(ConfigurationName = "DemoOperator.IOperatorService")]
    public interface IOperatorService
    {
        /// <summary>
        /// Adds asynchronously.
        /// </summary>
        /// <returns>The calculation.</returns>
        /// <param name="intA">Int a.</param>
        /// <param name="intB">Int b.</param>
        [OperationContract(Action = "http://tempuri.org/Add", ReplyAction = "*")]
        Task<int> AddAsync(int intA, int intB);

        /// <summary>
        /// Subtracts asynchronously.
        /// </summary>
        /// <returns>The calculation.</returns>
        /// <param name="intA">Int a.</param>
        /// <param name="intB">Int b.</param>
        [OperationContract(Action = "http://tempuri.org/Subtract", ReplyAction = "*")]
        Task<int> SubtractAsync(int intA, int intB);

        /// <summary>
        /// Multiplies asynchronously.
        /// </summary>
        /// <returns>The calculation.</returns>
        /// <param name="intA">Int a.</param>
        /// <param name="intB">Int b.</param>
        [OperationContract(Action = "http://tempuri.org/Multiply", ReplyAction = "*")]
        Task<int> MultiplyAsync(int intA, int intB);

        /// <summary>
        /// Divides asynchronously.
        /// </summary>
        /// <returns>The calculation.</returns>
        /// <param name="intA">Int a.</param>
        /// <param name="intB">Int b.</param>
        [OperationContract(Action = "http://tempuri.org/Divide", ReplyAction = "*")]
        Task<int> DivideAsync(int intA, int intB);
         
    }
}
