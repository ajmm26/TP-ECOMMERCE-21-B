using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;

namespace service
{
    public class MercadoPago
    {
        private PreferenceRequest request;
        private List<PreferenceItemRequest> listaPreferenceItemRequest;
        private Preference preference;
        private PreferenceClient client;
        private string success;
        private string failure;
        private string pending;


        public MercadoPago(string urlBase)
        {
            MercadoPagoConfig.AccessToken = ConfigurationManager.AppSettings["AccessToken"];
            string baseUrl = urlBase.TrimEnd('/').Replace("http://", "http://");
            success = baseUrl + "/PurchaseConfirmation.aspx";
            failure = baseUrl + "/PurchaseFailure.aspx";
            pending = baseUrl + "/PurchasePending.aspx";
            client = new PreferenceClient();
            request = new PreferenceRequest
            {
                BackUrls = new PreferenceBackUrlsRequest
                { Success = success, Failure = failure, Pending = pending },
                AutoReturn = "approved",
                Items = new List<PreferenceItemRequest>()
            };
        }
        public string CrearPreferencia(string titulo, int cantidad, decimal precio) 
        { 
             var item = new PreferenceItemRequest 
           { 
            Title = titulo, 
            Quantity = cantidad, 
            CurrencyId = "ARS",
            UnitPrice = precio 
           };

            request.Items.Add(item); 

            Preference preference = client.Create(request);
            return preference.InitPoint; 
        }
        
          

    }
}