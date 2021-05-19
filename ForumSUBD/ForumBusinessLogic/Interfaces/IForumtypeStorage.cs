using ForumBusinessLogic.BindingModels;
using ForumBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace ForumBusinessLogic.Interfaces
{
    public interface IForumtypeStorage
    {
        List<ForumtypeViewModel> GetFullList();

        List<ForumtypeViewModel> GetFilteredList(ForumtypeBindingModel model);

        ForumtypeViewModel GetElement(ForumtypeBindingModel model);

        void Insert(ForumtypeBindingModel model);

        void Update(ForumtypeBindingModel model);

        void Delete(ForumtypeBindingModel model);
    }
}
