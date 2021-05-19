using System;
using System.Collections.Generic;
using ForumBusinessLogic.BindingModels;
using ForumBusinessLogic.Interfaces;
using ForumBusinessLogic.ViewModels;

namespace ForumBusinessLogic.BusinessLogics
{
    public class UsersBusinessLogic
    {
        private readonly IUsersStorage _userStorage;

        public UsersBusinessLogic(IUsersStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public List<UsersViewModel> Read(UsersBindingModel model)
        {
            if (model == null)
            {
                return _userStorage.GetFullList();
            }
            if (model.Userid.HasValue || model.Email != null)
            {
                return new List<UsersViewModel> { _userStorage.GetElement(model) };
            }
            return _userStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(UsersBindingModel model)
        {
            var element = _userStorage.GetElement(new UsersBindingModel
            {
                Email = model.Email
            });
            if (element != null && element.Userid != model.Userid)
            {
                throw new Exception("Уже есть пользователь с таким логином");
            }
            if (model.Userid.HasValue)
            {
                _userStorage.Update(model);
            }
            else
            {
                _userStorage.Insert(model);
            }
        }

        public void Delete(UsersBindingModel model)
        {
            var element = _userStorage.GetElement(new UsersBindingModel
            {
                Userid = model.Userid
            });
            if (element == null)
            {
                throw new Exception("Пользователь не найден");
            }
            _userStorage.Delete(model);
        }
    }
}
