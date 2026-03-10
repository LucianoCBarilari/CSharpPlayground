using System.Collections.Generic;
using CSharpPlayground.Slices.Patterns.Composite.Models;

namespace CSharpPlayground.Slices.Patterns.Composite
{
    public static class CompositeFactory
    {
        public static List<GroupNode> BuildTree()
        {
            var groupData = CompositeMockData.CreateGroups();
            var itemData = CompositeMockData.CreateItems();

            var result = new List<GroupNode>();
            var index = new Dictionary<int, GroupNode>();

            foreach (var item in groupData)
            {
                var group = new GroupNode
                {
                    Id = item.Id,
                    Name = item.Name
                };

                result.Add(group);
                index[item.Id] = group;
            }

            foreach (var item in itemData)
            {
                if (!index.TryGetValue(item.GroupId, out var parent))
                {
                    continue;
                }

                var child = new ItemNode
                {
                    Id = item.Id,
                    Name = item.Name,
                    GroupId = item.GroupId
                };

                parent.ChildNode.Add(child);
            }

            return result;
        }
    }
}


