using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Serilog;

namespace CallWebService.Core
{
    public class CalculatorService : ICalculatorService
    {

        private static readonly EndpointAddress Endpoint = new EndpointAddress(Configurations.CalculatorServiceEndPoint);
        private static readonly BasicHttpBinding Binding = new BasicHttpBinding
        {
            MaxReceivedMessageSize = 2147483647,
            MaxBufferSize = 2147483647
        };

        public int Add(int a, int b)
        {
            int result = 0;
            using (var proxy = new GenericProxy<CalculatorSoap>(Binding, Endpoint))
            {
                try
                {
                    result = proxy.Execute(c => c.Add(a, b));
                }
                catch (FaultException ex)
                {
                    Log.Logger.Error(ex, "error while adding numbers.");

                }
                catch (Exception ex)
                {
                    Log.Logger.Error(ex, "error while adding numbers.");
                }

                return result;
            }

        }

    }
}
