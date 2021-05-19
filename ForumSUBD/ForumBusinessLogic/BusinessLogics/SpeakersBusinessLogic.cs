using System;
using System.Collections.Generic;
using ForumBusinessLogic.BindingModels;
using ForumBusinessLogic.Interfaces;
using ForumBusinessLogic.ViewModels;
namespace ForumBusinessLogic.BusinessLogics
{
    public class SpeakersBusinessLogic
    {
        private readonly ISpeakersStorage _speakersStorage;

        public SpeakersBusinessLogic(ISpeakersStorage authorsStorage)
        {
            _speakersStorage = authorsStorage;
        }

        public List<SpeakersViewModel> Read(SpeakersBindingModel model)
        {
            if (model == null)
            {
                return _speakersStorage.GetFullList();
            }
            if (model.Speakerid.HasValue)
            {
                return new List<SpeakersViewModel> { _speakersStorage.GetElement(model) };
            }
            return _speakersStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(SpeakersBindingModel model)
        {
            var element = _speakersStorage.GetElement(new SpeakersBindingModel
            {
                Speakerid = model.Speakerid
            });
            if (element != null && element.Speakerid != model.Speakerid)
            {
                throw new Exception("Уже есть такой докладчик");
            }
            if (model.Speakerid.HasValue)
            {
                _speakersStorage.Update(model);
            }
            else
            {
                _speakersStorage.Insert(model);
            }
        }

        public void Delete(SpeakersBindingModel model)
        {
            var element = _speakersStorage.GetElement(new SpeakersBindingModel
            {
                Speakerid = model.Speakerid
            });
            if (element == null)
            {
                throw new Exception("Докладчик не найден");
            }
            _speakersStorage.Delete(model);
        }
    }
}
