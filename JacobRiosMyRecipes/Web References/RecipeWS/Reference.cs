﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace JacobRiosMyRecipes.RecipeWS {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="RecipeWebServiceSoap", Namespace="http://tempuri.org/")]
    public partial class RecipeWebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetWebServiceRecipesOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReadUserInformationOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public RecipeWebService() {
            this.Url = global::JacobRiosMyRecipes.Properties.Settings.Default.JacobRiosMyRecipes_RecipeWS_RecipeWebService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        public event GetWebServiceRecipesCompletedEventHandler GetWebServiceRecipesCompleted;
        
        /// <remarks/>
        public event ReadUserInformationCompletedEventHandler ReadUserInformationCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetWebServiceRecipes", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public WSRecipe[] GetWebServiceRecipes() {
            object[] results = this.Invoke("GetWebServiceRecipes", new object[0]);
            return ((WSRecipe[])(results[0]));
        }
        
        /// <remarks/>
        public void GetWebServiceRecipesAsync() {
            this.GetWebServiceRecipesAsync(null);
        }
        
        /// <remarks/>
        public void GetWebServiceRecipesAsync(object userState) {
            if ((this.GetWebServiceRecipesOperationCompleted == null)) {
                this.GetWebServiceRecipesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetWebServiceRecipesOperationCompleted);
            }
            this.InvokeAsync("GetWebServiceRecipes", new object[0], this.GetWebServiceRecipesOperationCompleted, userState);
        }
        
        private void OnGetWebServiceRecipesOperationCompleted(object arg) {
            if ((this.GetWebServiceRecipesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetWebServiceRecipesCompleted(this, new GetWebServiceRecipesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ReadUserInformation", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void ReadUserInformation(string UserName, string TimeStamp, string StatusMsg) {
            this.Invoke("ReadUserInformation", new object[] {
                        UserName,
                        TimeStamp,
                        StatusMsg});
        }
        
        /// <remarks/>
        public void ReadUserInformationAsync(string UserName, string TimeStamp, string StatusMsg) {
            this.ReadUserInformationAsync(UserName, TimeStamp, StatusMsg, null);
        }
        
        /// <remarks/>
        public void ReadUserInformationAsync(string UserName, string TimeStamp, string StatusMsg, object userState) {
            if ((this.ReadUserInformationOperationCompleted == null)) {
                this.ReadUserInformationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReadUserInformationOperationCompleted);
            }
            this.InvokeAsync("ReadUserInformation", new object[] {
                        UserName,
                        TimeStamp,
                        StatusMsg}, this.ReadUserInformationOperationCompleted, userState);
        }
        
        private void OnReadUserInformationOperationCompleted(object arg) {
            if ((this.ReadUserInformationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReadUserInformationCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2046.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class WSRecipe {
        
        private string recipeIdField;
        
        private string recipeNameField;
        
        private string recipeInstructionsField;
        
        private string recipeIngredientsField;
        
        private int recipeSizeField;
        
        private byte[] recipeImageField;
        
        /// <remarks/>
        public string RecipeId {
            get {
                return this.recipeIdField;
            }
            set {
                this.recipeIdField = value;
            }
        }
        
        /// <remarks/>
        public string RecipeName {
            get {
                return this.recipeNameField;
            }
            set {
                this.recipeNameField = value;
            }
        }
        
        /// <remarks/>
        public string RecipeInstructions {
            get {
                return this.recipeInstructionsField;
            }
            set {
                this.recipeInstructionsField = value;
            }
        }
        
        /// <remarks/>
        public string RecipeIngredients {
            get {
                return this.recipeIngredientsField;
            }
            set {
                this.recipeIngredientsField = value;
            }
        }
        
        /// <remarks/>
        public int RecipeSize {
            get {
                return this.recipeSizeField;
            }
            set {
                this.recipeSizeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] RecipeImage {
            get {
                return this.recipeImageField;
            }
            set {
                this.recipeImageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void GetWebServiceRecipesCompletedEventHandler(object sender, GetWebServiceRecipesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetWebServiceRecipesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetWebServiceRecipesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public WSRecipe[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((WSRecipe[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void ReadUserInformationCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591