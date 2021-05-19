using System;
using System.Collections.Generic;
using ForumBusinessLogic.BindingModels;
using ForumBusinessLogic.Interfaces;
using ForumBusinessLogic.ViewModels;

namespace ForumBusinessLogic.BusinessLogics
{
    public class ForumtypeBusinessLogic
    {
        private readonly IForumtypeStorage _forumtypeStorage;

        public ForumtypeBusinessLogic(IForumtypeStorage forumtypeStorage)
        {
            _forumtypeStorage = forumtypeStorage;
        }

        public List<ForumtypeViewModel> Read(ForumtypeBindingModel model)
        {
            if (model == null)
            {
                return _forumtypeStorage.GetFullList();
            }
            if (model.Forumtypeid.HasValue)
            {
                return new List<ForumtypeViewModel> { _forumtypeStorage.GetElement(model) };
            }
            return _forumtypeStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ForumtypeBindingModel model)
        {
            var element = _forumtypeStorage.GetElement(new ForumtypeBindingModel
            {
                Forumtypeid = model.Forumtypeid
            });
            if (element != null && element.Forumtypeid != model.Forumtypeid)
            {
                throw new Exception("Уже есть такой тип");
            }
            if (model.Forumtypeid.HasValue)
            {
                _forumtypeStorage.Update(model);
            }
            else
            {
                _forumtypeStorage.Insert(model);
            }
        }

        public void Delete(ForumtypeBindingModel model)
        {
            var element = _forumtypeStorage.GetElement(new ForumtypeBindingModel
            {
                Forumtypeid = model.Forumtypeid
            });
            if (element == null)
            {
                throw new Exception("Тип не найден");
            }
            _forumtypeStorage.Delete(model);
        }
    }
}
