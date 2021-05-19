using System;
using System.Collections.Generic;
using ForumBusinessLogic.BindingModels;
using ForumBusinessLogic.Interfaces;
using ForumBusinessLogic.ViewModels;

namespace ForumBusinessLogic.BusinessLogics
{
    public class ReportsBusinessLogic
    {
        private readonly IReportsStorage _reportsStorage;

        public ReportsBusinessLogic(IReportsStorage booksStorage)
        {
            _reportsStorage = booksStorage;
        }

        public List<ReportsViewModel> Read(ReportsBindingModel model)
        {
            if (model == null)
            {
                return _reportsStorage.GetFullList();
            }
            if (model.Reportid.HasValue)
            {
                return new List<ReportsViewModel> { _reportsStorage.GetElement(model) };
            }
            return _reportsStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ReportsBindingModel model)
        {
            var element = _reportsStorage.GetElement(new ReportsBindingModel
            {
                Reportid = model.Reportid
            });
            if (element != null && element.Reportid != model.Reportid)
            {
                throw new Exception("Уже есть такой доклад");
            }
            if (model.Reportid.HasValue)
            {
                _reportsStorage.Update(model);
            }
            else
            {
                _reportsStorage.Insert(model);
            }
        }

        public void Delete(ReportsBindingModel model)
        {
            var element = _reportsStorage.GetElement(new ReportsBindingModel
            {
                Reportid = model.Reportid
            });
            if (element == null)
            {
                throw new Exception("Доклад не найдена");
            }
            _reportsStorage.Delete(model);
        }
    }
}
