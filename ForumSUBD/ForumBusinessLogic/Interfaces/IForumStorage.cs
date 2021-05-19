using ForumBusinessLogic.BindingModels;
using ForumBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace ForumBusinessLogic.Interfaces
{
    public interface IForumStorage
    {
        List<ForumViewModel> GetFullList();

        List<ForumViewModel> GetFilteredList(ForumBindingModel model);

        ForumViewModel GetElement(ForumBindingModel model);

        void Insert(ForumBindingModel model);

        void Update(ForumBindingModel model);

        void Delete(ForumBindingModel model);
    }
}
