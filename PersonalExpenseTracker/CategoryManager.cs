using System.Collections.Generic;
using System.Linq;

namespace PersonalExpenseTracker
{
    public class CategoryManager
    {
        private List<Category> categories;

        public CategoryManager()
        {
            categories = new List<Category>();
        }

        public void AddCategory(Category category)
        {
            categories.Add(category);
        }

        public void UpdateCategory(Category updatedCategory)
        {
            var existingCategory = categories.FirstOrDefault(c => c.Name == updatedCategory.Name);
            if (existingCategory != null)
            {
                existingCategory.Description = updatedCategory.Description;
            }
        }

        public void RemoveCategory(Category category)
        {
            categories.Remove(category);
        }

        public List<Category> GetCategories()
        {
            return categories;
        }

        public bool IsCategoryListEmpty()
        {
            return !categories.Any();
        }
    }
}
