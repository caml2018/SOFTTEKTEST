using Microsoft.AspNetCore.Mvc.Testing;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace softtek.api.test
{
    public abstract class TestBuilder : IDisposable
    {
        protected HttpClient TestClient;

        private bool Disposed;

        protected TestBuilder()
        {
            loadClient();
        }
        protected void loadClient()
        {
            Disposed = false;
            var appFactory = new WebApplicationFactory<softtek.api.Startup>();
            TestClient= appFactory.CreateClient();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
                return;

            if (disposing)
            {
                TestClient.Dispose();
            }

            Disposed = true;
        }
    }
}
