using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BlavtBudget
{
   public class Category : EntityBase
    {
        private static int InstanceCount;
        private int _id;
        private string _name;
        private int _ownerId;
        private string _description;
        private Color _color;
        private object? _icon;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public Color Color { get => _color; set => _color = value; }
        public object Icon { get => _icon; set => _icon = value; }
        public int OwnerId { get => _ownerId; set => _ownerId = value; }

        public Category(int ownerId)
        {
            IsNew = true;
            InstanceCount += 1;
            _id = InstanceCount;
            _ownerId = ownerId;
        }
        public Category(int id, string name, int ownerId, 
                        string description, Color color, object icon)
        {
          //  IsNew = true;
            _id = id;
            _ownerId = ownerId;
            _name = name;
            _description= description;
            _color = color;
            _icon = icon;
        }

        public override bool Validate()
        {
            
                if (Id <= 0)
                    return false;
                if (OwnerId <= 0)
                    return false;
                if (String.IsNullOrWhiteSpace(Name))
                    return false;

                return true;
            
        }
    }
}
