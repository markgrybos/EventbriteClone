using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;
using WebMvc.Models.CartModels;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json.Linq;
using WebMvc;
using WebMvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using WebMvc.Models.OrderModels;

namespace WebMvc.Services
{
    public class CartService : ICartService
    {
        private readonly IConfiguration _config;
        private IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;
        private IHttpContextAccessor _httpContextAccesor;
        private readonly ILogger _logger;
        public CartService(IConfiguration config, IHttpContextAccessor httpContextAccesor,
            IHttpClient httpClient, ILoggerFactory logger)
        {
            _config = config;
            _remoteServiceBaseUrl = $"{_config["CartUrl"]}/api/cart";
            _httpContextAccesor = httpContextAccesor;
            _apiClient = httpClient;
            _logger = logger.CreateLogger<CartService>();
        }


        public async Task AddItemToCart(ApplicationUser user, CartItem events)
        {
            var cart = await GetCart(user);
            _logger.LogDebug("User Name: " + user.Email);

            var basketItem = cart.Items
                .Where(e => e.EventId == events.EventId)
                .FirstOrDefault();
            if (basketItem == null)
            {
                cart.Items.Add(events);
            }
            else
            {
                basketItem.Tickets += 1;
            }


            await UpdateCart(cart);
        }

        public async Task ClearCart(ApplicationUser user)
        {
            var token = await GetUserTokenAsync();
            var cleanBasketUri = ApiPaths.Basket.CleanBasket(_remoteServiceBaseUrl, user.Email);
            _logger.LogDebug("Clean Basket uri : " + cleanBasketUri);
            var response = await _apiClient.DeleteAsync(cleanBasketUri);
            _logger.LogDebug("Basket cleaned");
        }

        public async Task<Cart> GetCart(ApplicationUser user)
        {
            var token = await GetUserTokenAsync();
            _logger.LogInformation(" We are in get basket and user id " + user.Email);
            _logger.LogInformation(_remoteServiceBaseUrl);

            var getBasketUri = ApiPaths.Basket.GetBasket(_remoteServiceBaseUrl, user.Email);
            _logger.LogInformation(getBasketUri);
            var dataString = await _apiClient.GetStringAsync(getBasketUri, token);
            _logger.LogInformation(dataString);

            var response = JsonConvert.DeserializeObject<Cart>(dataString.ToString()) ??
               new Cart()
               {
                   BuyerId = user.Email
               };
            return response;
        }

        public Order MapCartToOrder(Cart cart)
        {
            var order = new Order();
            order.OrderTotal = 0;

            cart.Items.ForEach(x =>
            {
                order.OrderItems.Add(new OrderItem()
                {
                    EventId = int.Parse(x.EventId),

                    PictureUrl = x.EventURL,
                    EventName = x.EventName,
                    Tickets = x.Tickets,
                    EventPrice = x.EventPrice
                });
              order.OrderTotal += (x.Tickets * x.EventPrice);
          });

            return order;
        }


        public async Task<Cart> SetQuantities(ApplicationUser user, Dictionary<string, int> quantities)
        {
            var basket = await GetCart(user);

            basket.Items.ForEach(x =>
            {
                // Simplify this logic by using the
                // new out variable initializer.
                if (quantities.TryGetValue(x.Id, out var quantity))
                {
                    x.Tickets = quantity;
                }
            });

            return basket;
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {

            var token = await GetUserTokenAsync();
            _logger.LogDebug("Service url: " + _remoteServiceBaseUrl);
            var updateBasketUri = ApiPaths.Basket.UpdateBasket(_remoteServiceBaseUrl);
            _logger.LogDebug("Update Basket url: " + updateBasketUri);
            var response = await _apiClient.PostAsync(updateBasketUri, cart, token);
            response.EnsureSuccessStatusCode();

            return cart;
        }

        async Task<string> GetUserTokenAsync()
        {
            var context = _httpContextAccesor.HttpContext;

            return await context.GetTokenAsync("access_token");

        }
    }
}