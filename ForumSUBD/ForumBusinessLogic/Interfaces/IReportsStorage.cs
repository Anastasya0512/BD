using ForumBusinessLogic.BindingModels;
using ForumBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace ForumBusinessLogic.Interfaces
{
    public interface IReportsStorage
    {
        List<ReportsViewModel> GetFullList();

        List<ReportsViewModel> GetFilteredList(ReportsBindingModel model);

        ReportsViewModel GetElement(ReportsBindingModel model);

        void Insert(ReportsBindingModel model);

        void Update(ReportsBindingModel model);

        void Delete(ReportsBindingModel model);
    }
}
