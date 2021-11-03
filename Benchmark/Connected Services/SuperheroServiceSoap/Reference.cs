﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//
//     Änderungen an dieser Datei können fehlerhaftes Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SuperheroServiceSoap
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WcfService")]
    public partial class CompositeType : object
    {
        
        private bool BoolValueField;
        
        private string StringValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue
        {
            get
            {
                return this.BoolValueField;
            }
            set
            {
                this.BoolValueField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue
        {
            get
            {
                return this.StringValueField;
            }
            set
            {
                this.StringValueField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Superhero", Namespace="http://schemas.datacontract.org/2004/07/Common")]
    public partial class Superhero : object
    {
        
        private string AliasField;
        
        private float HeightField;
        
        private string NameField;
        
        private SuperheroServiceSoap.Universe UniverseField;
        
        private float WeightField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Alias
        {
            get
            {
                return this.AliasField;
            }
            set
            {
                this.AliasField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Height
        {
            get
            {
                return this.HeightField;
            }
            set
            {
                this.HeightField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SuperheroServiceSoap.Universe Universe
        {
            get
            {
                return this.UniverseField;
            }
            set
            {
                this.UniverseField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Weight
        {
            get
            {
                return this.WeightField;
            }
            set
            {
                this.WeightField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Universe", Namespace="http://schemas.datacontract.org/2004/07/Common")]
    public enum Universe : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Marvel = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Dc = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SuperheroServiceSoap.ISuperheroService")]
    public interface ISuperheroService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISuperheroService/GetData", ReplyAction="http://tempuri.org/ISuperheroService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISuperheroService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ISuperheroService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<SuperheroServiceSoap.CompositeType> GetDataUsingDataContractAsync(SuperheroServiceSoap.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISuperheroService/GetSuperhero", ReplyAction="http://tempuri.org/ISuperheroService/GetSuperheroResponse")]
        System.Threading.Tasks.Task<SuperheroServiceSoap.Superhero> GetSuperheroAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISuperheroService/GetSuperheroes", ReplyAction="http://tempuri.org/ISuperheroService/GetSuperheroesResponse")]
        System.Threading.Tasks.Task<SuperheroServiceSoap.Superhero[]> GetSuperheroesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface ISuperheroServiceChannel : SuperheroServiceSoap.ISuperheroService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class SuperheroServiceClient : System.ServiceModel.ClientBase<SuperheroServiceSoap.ISuperheroService>, SuperheroServiceSoap.ISuperheroService
    {
        
        /// <summary>
        /// Implementieren Sie diese partielle Methode, um den Dienstendpunkt zu konfigurieren.
        /// </summary>
        /// <param name="serviceEndpoint">Der zu konfigurierende Endpunkt</param>
        /// <param name="clientCredentials">Die Clientanmeldeinformationen</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public SuperheroServiceClient() : 
                base(SuperheroServiceClient.GetDefaultBinding(), SuperheroServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ISuperheroService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SuperheroServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(SuperheroServiceClient.GetBindingForEndpoint(endpointConfiguration), SuperheroServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SuperheroServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(SuperheroServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SuperheroServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(SuperheroServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SuperheroServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value)
        {
            return base.Channel.GetDataAsync(value);
        }
        
        public System.Threading.Tasks.Task<SuperheroServiceSoap.CompositeType> GetDataUsingDataContractAsync(SuperheroServiceSoap.CompositeType composite)
        {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public System.Threading.Tasks.Task<SuperheroServiceSoap.Superhero> GetSuperheroAsync()
        {
            return base.Channel.GetSuperheroAsync();
        }
        
        public System.Threading.Tasks.Task<SuperheroServiceSoap.Superhero[]> GetSuperheroesAsync()
        {
            return base.Channel.GetSuperheroesAsync();
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ISuperheroService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Es wurde kein Endpunkt mit dem Namen \"{0}\" gefunden.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ISuperheroService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:21197/SuperheroService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Es wurde kein Endpunkt mit dem Namen \"{0}\" gefunden.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return SuperheroServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ISuperheroService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return SuperheroServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ISuperheroService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ISuperheroService,
        }
    }
}
