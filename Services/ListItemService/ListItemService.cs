﻿using System.Reflection.Metadata.Ecma335;
using TodoListApp.Models;

namespace TodoListApp.Services.ListItemService
{
    public class ListItemService : IListItemService
    {
        //private static List<ListItem> todo = new List<ListItem>
        //{
        //    new ListItem { Id = 1, UserId = 1, ItemText = "Test" },
        //    new ListItem { Id = 2, UserId = 1, ItemText = "Test Again" },
        //    new ListItem { Id = 3, UserId = 1, ItemText = "Test Again Again" },
        //    new ListItem { Id = 4, UserId = 2, ItemText = "Test for user 2" }
        //};

        private readonly DataContext _context;

        public ListItemService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ListItem>> AddTodo(ListItem li)
        {
            _context.ListItems.Add(li);
            await _context.SaveChangesAsync();
            return await _context.ListItems.ToListAsync();
        }

        public async Task<List<ListItem>?> DeleteTodo(int id)
        {
            var item = await _context.ListItems.FindAsync(id);
            if (item is null)
                return null;

            _context.ListItems.Remove(item);
            await _context.SaveChangesAsync();

            return await _context.ListItems.ToListAsync();
        }

        public async Task<List<ListItem>?> EditTodo(int id, ListItem req)
        {
            var item = await _context.ListItems.FindAsync(id);
            if (item is null)
                return null;

            item.ItemText = req.ItemText;
            item.Order = req.Order;

            await _context.SaveChangesAsync();

            return await _context.ListItems.ToListAsync();
        }

        //public async Task<List<ListItem>> GetAllTodo()
        //{
        //    return await _context.ListItems.ToListAsync();
        //}

        public async Task<List<ListItem>?> GetUserTodo(int userId)
        {
            var items = await _context.ListItems
                .OrderBy(li => li.Order)
                .ThenBy(li => li.Created)
                .Where(li => li.UserId == userId)
                .ToListAsync();

            if (items is null || items is [])
                return null;

            return items;

        }

        public async Task<ListItem?> SetTodoStatus(int id)
        {
            var item = await _context.ListItems.FindAsync(id);
            if (item is null)
                return null;

            if (item.IsDone is false)
                item.IsDone = true;
            else
                item.IsDone = false;

            await _context.SaveChangesAsync();

            return item;
        }
    }
}
