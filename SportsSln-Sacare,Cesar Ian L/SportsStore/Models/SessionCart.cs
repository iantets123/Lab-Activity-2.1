using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Infrastructure;

namespace SportsStore.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
            SessionCart cart = session?.Getjson<SessionCart>("Cart")
            ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.setJson("Cart", this);
        }

        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.setJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}