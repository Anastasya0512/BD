using System;
using System.Collections.Generic;
using ForumBusinessLogic.BindingModels;
using ForumBusinessLogic.Interfaces;
using ForumBusinessLogic.ViewModels;

namespace ForumBusinessLogic.BusinessLogics
{
    public class ForumLogic
    {
        private readonly IForumStorage _forumStorage;

        public ForumLogic(IForumStorage forumStorage)
        {
            _forumStorage = forumStorage;
        }

        public List<ForumViewModel> Read(ForumBindingModel model)
        {
            if (model == null)
            {
                return _forumStorage.GetFullList();
            }
            if (model.Forumid.HasValue)
            {
                return new List<ForumViewModel> { _forumStorage.GetElement(model) };
            }
            return _forumStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ForumBindingModel model)
        {
            var element = _forumStorage.GetElement(new ForumBindingModel
            {
                Forumid = model.Forumid
            });
            if (element != null && element.Forumid != model.Forumid)
            {
                throw new Exception("Уже есть такой форум");
            }
            if (model.Forumid.HasValue)
            {
                _forumStorage.Update(model);
            }
            else
            {
                _forumStorage.Insert(model);
            }
        }

        public void Delete(ForumBindingModel model)
        {
            var element = _forumStorage.GetElement(new ForumBindingModel
            {
                Forumid = model.Forumid
            });
            if (element == null)
            {
                throw new Exception("Форум не найден");
            }
            _forumStorage.Delete(model);
        }
    }
}
