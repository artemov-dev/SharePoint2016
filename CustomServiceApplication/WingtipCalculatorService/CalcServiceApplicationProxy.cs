using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Administration;
using System.Configuration;
using System.ServiceModel;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;

namespace CriticalPath.SharePoint.Samples.WingtipCalculator
{
    [System.Runtime.InteropServices.Guid("C7A865C4-8648-4BC1-9643-FD4671830119")]
    public class CalcServiceApplicationProxy : SPIisWebServiceApplicationProxy
    {
        private ChannelFactory<IWingtipCalcContract> _channelFactory;
        private object _channelFactoryLock = new object();
        private string _endpointConfigName;

        [Persisted]
        private SPServiceLoadBalancer _loadBalancer;

        public CalcServiceApplicationProxy() { }
        public CalcServiceApplicationProxy(string name, CalcServiceProxy proxy, Uri serviceAddress)
            : base(name, proxy, serviceAddress)
        {
            // create instance of a new load balancer
            _loadBalancer = new SPRoundRobinServiceLoadBalancer(serviceAddress);
        }

        #region service app proxy plumbing
        private ChannelFactory<T> CreateChannelFactory<T>(string endpointConfigName)
        {
            // open the client.config
            string clientConfigPath = SPUtility.GetGenericSetupPath(@"WebClients\Wingtip");
            Configuration clientConfig = OpenClientConfiguration(clientConfigPath);
            ConfigurationChannelFactory<T> factory = new ConfigurationChannelFactory<T>(endpointConfigName, clientConfig, null);

            // configure the channel factory
            factory.ConfigureCredentials(SPServiceAuthenticationMode.Claims);

            return factory;
        }

        internal delegate void CodeToRunOnApplicationProxy(CalcServiceApplicationProxy appProxy);
        internal static void Invoke(SPServiceContext serviceContext, CodeToRunOnApplicationProxy codeBlock)
        {
            if (serviceContext==null)
                throw new ArgumentNullException("serviceContext");

            // get service app proxy from the context
            CalcServiceApplicationProxy proxy = (CalcServiceApplicationProxy)serviceContext.GetDefaultProxy(typeof(CalcServiceApplicationProxy));
            if (proxy == null)
                throw new InvalidOperationException("Unable to obtain object reference to calc service proxy.");

            // run the code block on the proxy
            using (new SPServiceContextScope(serviceContext))
            {
                codeBlock(proxy);
            }
        }

        private string GetEndpointConfigName(Uri address)
        {
            string configName;

            // get the the config name for the provided address
            if (address.Scheme == Uri.UriSchemeHttp)
                configName = "http";
            else if (address.Scheme == Uri.UriSchemeHttps)
                configName = "https";
            else
                throw new NotSupportedException("Unsupported endpoint address.");

            return configName;
        }

        private IWingtipCalcContract GetChannel(Uri address)
        {
            string endpointConfig = GetEndpointConfigName(address);

            // if there's a cached channel, use that
            if ((_channelFactory == null) || (endpointConfig != _endpointConfigName))
            {
                lock (_channelFactoryLock)
                {
                    // create a channel factory using the endpoint name
                    _channelFactory = CreateChannelFactory<IWingtipCalcContract>(endpointConfig);
                    // cache the created channel
                    _endpointConfigName = endpointConfig;
                }
            }

            IWingtipCalcContract channel;

            // create a channel that acts as the logged on user when authenticating with the service
            channel = _channelFactory.CreateChannelActingAsLoggedOnUser<IWingtipCalcContract>(new EndpointAddress(address));

            return channel;
        }

        private delegate void CodeToRunOnChannel(IWingtipCalcContract contract);
        private void ExecuteOnChannel(string operationName, CodeToRunOnChannel codeBlock)
        {
            SPServiceLoadBalancerContext loadBalancerContext = _loadBalancer.BeginOperation();

            try
            {
                // get a channel to the service app endpoint
                IChannel channel = (IChannel)GetChannel(loadBalancerContext.EndpointAddress);
                try
                {
                    // execute the code block
                    codeBlock((IWingtipCalcContract)channel);
                    channel.Close();
                }
                catch (TimeoutException)
                {
                    loadBalancerContext.Status = SPServiceLoadBalancerStatus.Failed;
                    throw;
                }
                catch (EndpointNotFoundException)
                {
                    loadBalancerContext.Status = SPServiceLoadBalancerStatus.Failed;
                    throw;
                }
                finally
                {
                    if (channel.State != CommunicationState.Closed)
                        channel.Abort();
                }
            }
            finally
            {
                loadBalancerContext.EndOperation();
            }
        }
        #endregion

        // assign the custom app proxy type name
        public override string TypeName
        {
            get { return "Wingtip Calculator Service Application"; }
        }

        // provisioning the app proxy requires creating a new load balancer
        public override void Provision()
        {
            _loadBalancer.Provision();
            base.Provision();
            this.Update();
        }
        // unprovisioning the app proxy requires deleting the load balancer
        public override void Unprovision(bool deleteData)
        {
            _loadBalancer.Unprovision();
            base.Unprovision(deleteData);
            this.Update();
        }

        #region service application methods
        public int Add(int x, int y)
        {
            int result = 0;

            // execute the call against the service app
            ExecuteOnChannel("Add",
                delegate(IWingtipCalcContract channel)
                {
                    result = channel.Add(x, y);
                });

            return result;
        }
        public int Subtract(int x, int y)
        {
            int result = 0;

            // execute the call against the service app
            ExecuteOnChannel("Subtract",
                delegate(IWingtipCalcContract channel)
                {
                    result = channel.Subtract(x, y);
                });

            return result;
        }
        #endregion
    }
}
