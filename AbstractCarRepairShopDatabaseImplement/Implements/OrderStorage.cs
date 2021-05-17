using AbstractCarRepairShopBisinessLogic.BindingModels;
using AbstractCarRepairShopBisinessLogic.Interfaces;
using AbstractCarRepairShopBisinessLogic.ViewModels;
using AbstractCarRepairShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractCarRepairShopDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                return context.Orders.Include(rec => rec.Repair)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    RepairId = rec.RepairId,
                    RepairName = rec.Repair.RepairName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                })
                .ToList();
            }
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                return context.Orders.Include(rec => rec.Repair)
                 .Where(rec => rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo)
                 .Select(rec => new OrderViewModel
                 {
                     Id = rec.Id,
                     RepairId = rec.RepairId,
                     RepairName = rec.Repair.RepairName,
                     Count = rec.Count,
                     Sum = rec.Sum,
                     Status = rec.Status,
                     DateCreate = rec.DateCreate,
                     DateImplement = rec.DateImplement,
                 })
                 .ToList();
            }
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                Order order = context.Orders.Include(rec => rec.Repair)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    RepairId = order.RepairId,
                    RepairName = order.Repair.RepairName,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                } :
                null;
            }
        }
        public void Insert(OrderBindingModel model)
        {
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                Order order = new Order
                {
                    RepairId = model.RepairId,
                    Count = model.Count,
                    Sum = model.Sum,
                    Status = model.Status,
                    DateCreate = model.DateCreate,
                    DateImplement = model.DateImplement,
                };
                context.Orders.Add(order);
                context.SaveChanges();
                CreateModel(model, order);
                context.SaveChanges();
            }
        }
        public void Update(OrderBindingModel model)
        {
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                element.RepairId = model.RepairId;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            if (model == null)
            {
                return null;
            }

            using (AbstractCarShopDatabase context = new AbstractCarShopDatabase())
            {
                Repair element = context.Repairs.FirstOrDefault(rec => rec.Id == model.RepairId);
                if (element != null)
                {
                    if (element.Orders == null)
                    {
                        element.Orders = new List<Order>();
                    }
                    element.Orders.Add(order);
                    context.Repairs.Update(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
            return order;
        }
    }
}
