using DataStorage;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService
    {
        private FileOfDataStorage<DBUser> _storage = new FileOfDataStorage<DBUser>();

        public async Task<bool> RecordCategories(User user)
        {
            DBUser userDb = await _storage.GetAsync(user.Guid);
            userDb.Categories = user.Categories;
            await _storage.AddOrUpdateAsync(userDb);
            return true;
        }
    }
}
