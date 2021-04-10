﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataStorage
{
    public class FileOfDataStorage<TObject> where TObject :class, IStorable
    {
        private static readonly string BaseFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "BudgetStorage", typeof(TObject).Name);

        public FileOfDataStorage()
        {
            if(!Directory.Exists(BaseFolder))
            {
                Directory.CreateDirectory(BaseFolder);
            }
        }


        public async Task AddOrUpdateAsync(TObject obj)
        {
            string stringObject = JsonSerializer.Serialize(obj);
            string filePath = Path.Combine(BaseFolder, obj.Guid.ToString("N"));
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
              await sw.WriteAsync(stringObject);
            }
        }

        public async Task<TObject> GetAsync(Guid guid)
        {
            string stringObject = null;
            string filePath = Path.Combine(BaseFolder, guid.ToString("N"));
            if (!File.Exists(filePath))
            {
                return null;
            }

            using (StreamReader sr = new StreamReader(filePath))
            {
                stringObject = await sr.ReadToEndAsync();
            }
            return JsonSerializer.Deserialize<TObject>(stringObject);
        }

        public async Task<List<TObject>> GetAllAsync()
        {
            var res = new List<TObject>();

            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObject = null;
               
                

                using (StreamReader sr = new StreamReader(file))
                {
                    stringObject = await sr.ReadToEndAsync();
                }
                 res.Add(JsonSerializer.Deserialize<TObject>(stringObject));
            }
            return res;
        }




    }
}
