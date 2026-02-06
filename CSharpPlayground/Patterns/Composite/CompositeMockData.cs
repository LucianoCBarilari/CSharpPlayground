using System.Collections.Generic;
using CSharpPlayground.Patterns.Composite.Models;

namespace CSharpPlayground.Patterns.Composite
{
    public static class CompositeMockData
    {
        public static List<Group> CreateGroups()
        {
            return new List<Group>
            {
                new() { Id = 1, Name = "Group Alpha" },
                new() { Id = 2, Name = "Group Beta" },
                new() { Id = 3, Name = "Group Gamma" },
                new() { Id = 4, Name = "Group Delta" },
                new() { Id = 5, Name = "Group Epsilon" }
            };
        }

        public static List<Item> CreateItems()
        {
            return new List<Item>
            {
                new() { Id = 1, GroupId = 2, Name = "Item 1" },
                new() { Id = 2, GroupId = 3, Name = "Item 2" },
                new() { Id = 3, GroupId = 3, Name = "Item 3" },
                new() { Id = 4, GroupId = 4, Name = "Item 4" },
                new() { Id = 5, GroupId = 4, Name = "Item 5" },
                new() { Id = 6, GroupId = 4, Name = "Item 6" },
                new() { Id = 7, GroupId = 5, Name = "Item 7" },
                new() { Id = 8, GroupId = 5, Name = "Item 8" },
                new() { Id = 9, GroupId = 5, Name = "Item 9" },
                new() { Id = 10, GroupId = 5, Name = "Item 10" }
            };
        }
    }
}
