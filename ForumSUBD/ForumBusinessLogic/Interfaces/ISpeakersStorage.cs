using ForumBusinessLogic.BindingModels;
using ForumBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace ForumBusinessLogic.Interfaces
{
    public interface ISpeakersStorage
    {
        List<SpeakersViewModel> GetFullList();

        List<SpeakersViewModel> GetFilteredList(SpeakersBindingModel model);

        SpeakersViewModel GetElement(SpeakersBindingModel model);

        void Insert(SpeakersBindingModel model);

        void Update(SpeakersBindingModel model);

        void Delete(SpeakersBindingModel model);
    }
}
