using _5N2_Kitchens_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5N2_Kitchens_App.Services
{
    public class MockDataStore : IDataStore<Rescue>
    {
        readonly List<Rescue> items;

        public MockDataStore()
        {
            items = new List<Rescue>()
            {
                new Rescue { Id = Guid.NewGuid().ToString(), Description="This is an item description." },
                new Rescue { Id = Guid.NewGuid().ToString(), Description="This is an item description." },
                new Rescue { Id = Guid.NewGuid().ToString(), Description="This is an item description." },
                new Rescue { Id = Guid.NewGuid().ToString(), Description="This is an item description." },
                new Rescue { Id = Guid.NewGuid().ToString(), Description="This is an item description." },
                new Rescue { Id = Guid.NewGuid().ToString(), Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Rescue item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Rescue item)
        {
            var oldItem = items.Where((Rescue arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Rescue arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Rescue> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Rescue>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}