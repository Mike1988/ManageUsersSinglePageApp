using System.Collections;
using System.Linq;
using System.Web.Mvc;

namespace ManageUsersSinglePageApp.Extensions
{
    public static class ModelStateHelper
    {
        public static IEnumerable Errors(this ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                var errors = new Hashtable();
                foreach (var pair in modelState)
                {
                    if (pair.Value.Errors.Count > 0)
                    {
                        errors[pair.Key] = pair.Value.Errors.Select(error => error.ErrorMessage).ToList();
                    }
                }
                return errors;
            }
            return null;
        }
    }
}