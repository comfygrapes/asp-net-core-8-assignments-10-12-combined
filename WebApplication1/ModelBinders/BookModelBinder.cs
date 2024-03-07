using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication1.Models;

namespace WebApplication1.ModelBinders
{
    public class BookModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var book = new Book();

            if (bindingContext.ValueProvider.GetValue("Author").Count() > 0)
            {
                book.Author = bindingContext.ValueProvider.GetValue("Author").First();

                if (bindingContext.ValueProvider.GetValue("Age").Count() > 0)
                { 
                    book.Age = int.Parse(bindingContext.ValueProvider.GetValue("Age").First());
                }
            }

            bindingContext.Result = ModelBindingResult.Success(book);
            return Task.CompletedTask;
        }
    }
}
