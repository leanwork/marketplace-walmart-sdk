using Marketplace.Walmart.SDK.Configuration;
using Marketplace.Walmart.SDK.Constants;
using Marketplace.Walmart.SDK.Models;
using Marketplace.Walmart.SDK.Utils;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Marketplace.Walmart.SDK.Services
{
    /// <summary>
    /// API Service Base
    /// </summary>
    public abstract class APIServiceBase
    {
        string _sellerId;
        string _username;
        string _password;

        public bool Sandbox { get; set; }
        
        internal ISimpleRequest SimpleRequest
        {
            get { return _simpleRequest ?? new SimpleRequest(); }
            set { _simpleRequest = value; }
        }
        ISimpleRequest _simpleRequest;

        #region ctor

        public APIServiceBase()
        {
            this.Sandbox = APISettings.Sandbox;
            this._sellerId = APISettings.SellerId;
            this._username = APISettings.Username;
            this._password = APISettings.Password;
        }

        public APIServiceBase(string sellerId, string username, string password, bool sandbox = false)
            : base()
        {
            if (String.IsNullOrWhiteSpace(sellerId))
                throw new ArgumentNullException("sellerId");
            if (String.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException("username");
            if (String.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("password");

            this._sellerId = sellerId;
            this._username = username;
            this._password = password;
            this.Sandbox = sandbox;
        }

        #endregion

        protected Error GetError(HttpWebResponse response)
        {
            Error result = new Error();
            string error = string.Empty;

            try
            {
                using (var stream = new StreamReader(response.GetResponseStream()))
                {
                    error = stream.ReadToEnd();
                    if (String.IsNullOrWhiteSpace(error))
                    {
                        return result;
                    }
                    result = JsonConvert.DeserializeObject<Error>(error);
                }
            }
            catch (Exception ex)
            {
                result.summary = error ?? ex.GetBaseException().Message;
            }

            return result;
        }

        protected T ThreatException<T>(Exception exception, T response) where T : APIResult
        {
            string message = null;

            if (response == null)
            {
                response = Activator.CreateInstance<T>();
            }
            response.StatusCode = HttpStatusCode.InternalServerError;

            try
            {
                var webEx = exception as WebException;
                if (webEx != null)
                {
                    var httpWebResponse = webEx.Response as HttpWebResponse;
                    if (httpWebResponse != null && httpWebResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        response.StatusCode = HttpStatusCode.NotFound;
                        return response;
                    }

                    using (var stream = new StreamReader(webEx.Response.GetResponseStream()))
                    {
                        message = stream.ReadToEnd();
                        response.Error = JsonConvert.DeserializeObject<Error>(message);
                    }

                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Error = new Error
                {
                    summary = message ?? ex.GetBaseException().Message
                };
            }

            return response;
        }

        protected string GetSellerId()
        {
            return _sellerId;
        }

        protected ISimpleRequest CreateWebRequest()
        {
            var request = this.SimpleRequest;
            request.SetHost(GetHost());
            request.SetContentType(Keys.APPLICATION_JSON);
            request.SetBasicAuth(this._username, this._password);
            return request;
        }

        protected void ValidateSandboxRequest()
        {
            if (this.Sandbox == false)
            {
                throw new InvalidOperationException("Você não tem permissão para executar esta operação em ambiente de produção. Só é permitido em ambiente Sanbox.");
            }
        }

        #region privates

        private string GetHost()
        {
            return this.Sandbox ? Hosts.SANDBOX : Hosts.PRODUCTION;
        }

        #endregion
    }
}
