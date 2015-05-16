using Library.BLL;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LibraryServer
{
    /// <summary>
    /// Summary description for BaseWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BaseWebService : System.Web.Services.WebService, IObserver<Subscriber>
    {
        protected ILibraryController Controller { get; set; }
        public Subscriber CurrentSubscriber { get; set; }
        public BaseWebService()
        {
            Controller = new LibraryController(new Library.DAL.DatabaseRepository());
            Controller.Subscribe(this);
        }

        private void GetToken(){
            HttpRequest request = this.Context.Request;
            string userId = request.Headers["token"];
            CurrentSubscriber = Controller.FindSubscriberById(int.Parse(userId));
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Subscriber value)
        {
            throw new NotImplementedException();
        }
    }
}
