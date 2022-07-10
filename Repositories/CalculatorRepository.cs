namespace DemoOperator
{
    #region Usings
    using System;
    using System.ServiceModel;
    using System.Threading.Tasks;
    using System.Xml;
    #endregion

    /// <summary>
    /// Operator repository.
    /// </summary>
    public class OperatorRepository
    {
        /// <summary>
        /// The <see cref="IOperatorChannel"/> proxy.
        /// </summary>
        private readonly IOperatorChannel proxy;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DemoOperator.OperatorRepository"/> class.
        /// </summary>
        /// <param name="endpointAddress">Endpoint address.</param>
        /// <param name="timeout">The timeout.</param>
        public OperatorRepository(string endpointAddress, double timeout)
        {
            BasicHttpBinding binding = new BasicHttpBinding
            {
                SendTimeout = TimeSpan.FromSeconds(timeout),
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue,
                AllowCookies = true,
                ReaderQuotas = XmlDictionaryReaderQuotas.Max
            };

            binding.Security.Mode = BasicHttpSecurityMode.None;

            EndpointAddress address = new EndpointAddress(endpointAddress);

            ChannelFactory<IOperatorChannel> factory = new ChannelFactory<IOperatorChannel>(binding, address);

            this.proxy = factory.CreateChannel();
        }

        /// <summary>
        /// Adds asynchronously.
        /// </summary>
        /// <returns>The calculation.</returns>
        /// <param name="intA">Int a.</param>
        /// <param name="intB">Int b.</param>
        public async Task<int> AddAsync(int intA, int intB)
        {
            return await this.proxy.AddAsync(intA, intB);
        }

        /// <summary>
        /// Subtracts asynchronously.
        /// </summary>
        /// <returns>The calculation.</returns>
        /// <param name="intA">Int a.</param>
        /// <param name="intB">Int b.</param>
        public async Task<int> SubtractAsync(int intA, int intB)
        {
            return await this.proxy.SubtractAsync(intA, intB);
        }

        /// <summary>
        /// Multiplies asynchronously.
        /// </summary>
        /// <returns>The calculation.</returns>
        /// <param name="intA">Int a.</param>
        /// <param name="intB">Int b.</param>
        public async Task<int> MultiplyAsync(int intA, int intB)
        {
            return await this.proxy.MultiplyAsync(intA, intB);
        }

        /// <summary>
        /// Divides asynchronously.
        /// </summary>
        /// <returns>The calculation.</returns>
        /// <param name="intA">Int a.</param>
        /// <param name="intB">Int b.</param>
        public async Task<int> DivideAsync(int intA, int intB)
        {
            return await this.proxy.DivideAsync(intA, intB);
        }
    }
}