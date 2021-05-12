using AbstractCarRepairShopBisinessLogic.BindingModels;
using AbstractCarRepairShopBisinessLogic.BusinessLogics;
using AbstractCarRepairShopBisinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractCarRepairShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly OrderLogic _order;
        private readonly RepairLogic _repair;
        private readonly OrderLogic _main;
        public MainController(OrderLogic order, RepairLogic product, OrderLogic main)
        {
            _order = order;
            _repair = product;
            _main = main;
        }
        [HttpGet]
        public List<RepairViewModel> GetProductList() => _repair.Read(null)?.ToList();
        [HttpGet]
        public RepairViewModel GetProduct(int repairId) => _repair.Read(new RepairBindingModel
        { Id = repairId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _main.CreateOrder(model);
    }
}