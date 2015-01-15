﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeatherService.getTheWeather {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://ws.cdyne.com/WeatherWS/", ConfigurationName="getTheWeather.WeatherSoap")]
    public interface WeatherSoap {
        
        // CODEGEN: Parameter 'GetWeatherInformationResult' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlArrayItemAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.cdyne.com/WeatherWS/GetWeatherInformation", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WeatherService.getTheWeather.GetWeatherInformationResponse GetWeatherInformation(WeatherService.getTheWeather.GetWeatherInformationRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.cdyne.com/WeatherWS/GetWeatherInformation", ReplyAction="*")]
        System.Threading.Tasks.Task<WeatherService.getTheWeather.GetWeatherInformationResponse> GetWeatherInformationAsync(WeatherService.getTheWeather.GetWeatherInformationRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.cdyne.com/WeatherWS/GetCityForecastByZIP", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WeatherService.getTheWeather.ForecastReturn GetCityForecastByZIP(string ZIP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.cdyne.com/WeatherWS/GetCityForecastByZIP", ReplyAction="*")]
        System.Threading.Tasks.Task<WeatherService.getTheWeather.ForecastReturn> GetCityForecastByZIPAsync(string ZIP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.cdyne.com/WeatherWS/GetCityWeatherByZIP", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        WeatherService.getTheWeather.WeatherReturn GetCityWeatherByZIP(string ZIP);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://ws.cdyne.com/WeatherWS/GetCityWeatherByZIP", ReplyAction="*")]
        System.Threading.Tasks.Task<WeatherService.getTheWeather.WeatherReturn> GetCityWeatherByZIPAsync(string ZIP);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.cdyne.com/WeatherWS/")]
    public partial class WeatherDescription : object, System.ComponentModel.INotifyPropertyChanged {
        
        private short weatherIDField;
        
        private string descriptionField;
        
        private string pictureURLField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public short WeatherID {
            get {
                return this.weatherIDField;
            }
            set {
                this.weatherIDField = value;
                this.RaisePropertyChanged("WeatherID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("Description");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string PictureURL {
            get {
                return this.pictureURLField;
            }
            set {
                this.pictureURLField = value;
                this.RaisePropertyChanged("PictureURL");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.cdyne.com/WeatherWS/")]
    public partial class WeatherReturn : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool successField;
        
        private string responseTextField;
        
        private string stateField;
        
        private string cityField;
        
        private string weatherStationCityField;
        
        private short weatherIDField;
        
        private string descriptionField;
        
        private string temperatureField;
        
        private string relativeHumidityField;
        
        private string windField;
        
        private string pressureField;
        
        private string visibilityField;
        
        private string windChillField;
        
        private string remarksField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool Success {
            get {
                return this.successField;
            }
            set {
                this.successField = value;
                this.RaisePropertyChanged("Success");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ResponseText {
            get {
                return this.responseTextField;
            }
            set {
                this.responseTextField = value;
                this.RaisePropertyChanged("ResponseText");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
                this.RaisePropertyChanged("State");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string City {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
                this.RaisePropertyChanged("City");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string WeatherStationCity {
            get {
                return this.weatherStationCityField;
            }
            set {
                this.weatherStationCityField = value;
                this.RaisePropertyChanged("WeatherStationCity");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public short WeatherID {
            get {
                return this.weatherIDField;
            }
            set {
                this.weatherIDField = value;
                this.RaisePropertyChanged("WeatherID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("Description");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Temperature {
            get {
                return this.temperatureField;
            }
            set {
                this.temperatureField = value;
                this.RaisePropertyChanged("Temperature");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string RelativeHumidity {
            get {
                return this.relativeHumidityField;
            }
            set {
                this.relativeHumidityField = value;
                this.RaisePropertyChanged("RelativeHumidity");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string Wind {
            get {
                return this.windField;
            }
            set {
                this.windField = value;
                this.RaisePropertyChanged("Wind");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string Pressure {
            get {
                return this.pressureField;
            }
            set {
                this.pressureField = value;
                this.RaisePropertyChanged("Pressure");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string Visibility {
            get {
                return this.visibilityField;
            }
            set {
                this.visibilityField = value;
                this.RaisePropertyChanged("Visibility");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string WindChill {
            get {
                return this.windChillField;
            }
            set {
                this.windChillField = value;
                this.RaisePropertyChanged("WindChill");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string Remarks {
            get {
                return this.remarksField;
            }
            set {
                this.remarksField = value;
                this.RaisePropertyChanged("Remarks");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.cdyne.com/WeatherWS/")]
    public partial class POP : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string nighttimeField;
        
        private string daytimeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Nighttime {
            get {
                return this.nighttimeField;
            }
            set {
                this.nighttimeField = value;
                this.RaisePropertyChanged("Nighttime");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Daytime {
            get {
                return this.daytimeField;
            }
            set {
                this.daytimeField = value;
                this.RaisePropertyChanged("Daytime");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.cdyne.com/WeatherWS/")]
    public partial class temp : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string morningLowField;
        
        private string daytimeHighField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string MorningLow {
            get {
                return this.morningLowField;
            }
            set {
                this.morningLowField = value;
                this.RaisePropertyChanged("MorningLow");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string DaytimeHigh {
            get {
                return this.daytimeHighField;
            }
            set {
                this.daytimeHighField = value;
                this.RaisePropertyChanged("DaytimeHigh");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.cdyne.com/WeatherWS/")]
    public partial class Forecast : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.DateTime dateField;
        
        private short weatherIDField;
        
        private string desciptionField;
        
        private temp temperaturesField;
        
        private POP probabilityOfPrecipiationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public System.DateTime Date {
            get {
                return this.dateField;
            }
            set {
                this.dateField = value;
                this.RaisePropertyChanged("Date");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public short WeatherID {
            get {
                return this.weatherIDField;
            }
            set {
                this.weatherIDField = value;
                this.RaisePropertyChanged("WeatherID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Desciption {
            get {
                return this.desciptionField;
            }
            set {
                this.desciptionField = value;
                this.RaisePropertyChanged("Desciption");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public temp Temperatures {
            get {
                return this.temperaturesField;
            }
            set {
                this.temperaturesField = value;
                this.RaisePropertyChanged("Temperatures");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public POP ProbabilityOfPrecipiation {
            get {
                return this.probabilityOfPrecipiationField;
            }
            set {
                this.probabilityOfPrecipiationField = value;
                this.RaisePropertyChanged("ProbabilityOfPrecipiation");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://ws.cdyne.com/WeatherWS/")]
    public partial class ForecastReturn : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool successField;
        
        private string responseTextField;
        
        private string stateField;
        
        private string cityField;
        
        private string weatherStationCityField;
        
        private Forecast[] forecastResultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool Success {
            get {
                return this.successField;
            }
            set {
                this.successField = value;
                this.RaisePropertyChanged("Success");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ResponseText {
            get {
                return this.responseTextField;
            }
            set {
                this.responseTextField = value;
                this.RaisePropertyChanged("ResponseText");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
                this.RaisePropertyChanged("State");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string City {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
                this.RaisePropertyChanged("City");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string WeatherStationCity {
            get {
                return this.weatherStationCityField;
            }
            set {
                this.weatherStationCityField = value;
                this.RaisePropertyChanged("WeatherStationCity");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=5)]
        public Forecast[] ForecastResult {
            get {
                return this.forecastResultField;
            }
            set {
                this.forecastResultField = value;
                this.RaisePropertyChanged("ForecastResult");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetWeatherInformation", WrapperNamespace="http://ws.cdyne.com/WeatherWS/", IsWrapped=true)]
    public partial class GetWeatherInformationRequest {
        
        public GetWeatherInformationRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetWeatherInformationResponse", WrapperNamespace="http://ws.cdyne.com/WeatherWS/", IsWrapped=true)]
    public partial class GetWeatherInformationResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://ws.cdyne.com/WeatherWS/", Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public WeatherService.getTheWeather.WeatherDescription[] GetWeatherInformationResult;
        
        public GetWeatherInformationResponse() {
        }
        
        public GetWeatherInformationResponse(WeatherService.getTheWeather.WeatherDescription[] GetWeatherInformationResult) {
            this.GetWeatherInformationResult = GetWeatherInformationResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WeatherSoapChannel : WeatherService.getTheWeather.WeatherSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WeatherSoapClient : System.ServiceModel.ClientBase<WeatherService.getTheWeather.WeatherSoap>, WeatherService.getTheWeather.WeatherSoap {
        
        public WeatherSoapClient() {
        }
        
        public WeatherSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WeatherSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeatherSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeatherSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WeatherService.getTheWeather.GetWeatherInformationResponse WeatherService.getTheWeather.WeatherSoap.GetWeatherInformation(WeatherService.getTheWeather.GetWeatherInformationRequest request) {
            return base.Channel.GetWeatherInformation(request);
        }
        
        public WeatherService.getTheWeather.WeatherDescription[] GetWeatherInformation() {
            WeatherService.getTheWeather.GetWeatherInformationRequest inValue = new WeatherService.getTheWeather.GetWeatherInformationRequest();
            WeatherService.getTheWeather.GetWeatherInformationResponse retVal = ((WeatherService.getTheWeather.WeatherSoap)(this)).GetWeatherInformation(inValue);
            return retVal.GetWeatherInformationResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WeatherService.getTheWeather.GetWeatherInformationResponse> WeatherService.getTheWeather.WeatherSoap.GetWeatherInformationAsync(WeatherService.getTheWeather.GetWeatherInformationRequest request) {
            return base.Channel.GetWeatherInformationAsync(request);
        }
        
        public System.Threading.Tasks.Task<WeatherService.getTheWeather.GetWeatherInformationResponse> GetWeatherInformationAsync() {
            WeatherService.getTheWeather.GetWeatherInformationRequest inValue = new WeatherService.getTheWeather.GetWeatherInformationRequest();
            return ((WeatherService.getTheWeather.WeatherSoap)(this)).GetWeatherInformationAsync(inValue);
        }
        
        public WeatherService.getTheWeather.ForecastReturn GetCityForecastByZIP(string ZIP) {
            return base.Channel.GetCityForecastByZIP(ZIP);
        }
        
        public System.Threading.Tasks.Task<WeatherService.getTheWeather.ForecastReturn> GetCityForecastByZIPAsync(string ZIP) {
            return base.Channel.GetCityForecastByZIPAsync(ZIP);
        }
        
        public WeatherService.getTheWeather.WeatherReturn GetCityWeatherByZIP(string ZIP) {
            return base.Channel.GetCityWeatherByZIP(ZIP);
        }
        
        public System.Threading.Tasks.Task<WeatherService.getTheWeather.WeatherReturn> GetCityWeatherByZIPAsync(string ZIP) {
            return base.Channel.GetCityWeatherByZIPAsync(ZIP);
        }
    }
}
