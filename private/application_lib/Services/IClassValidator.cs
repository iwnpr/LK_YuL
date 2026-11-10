using application_lib.Entities;
using System.ComponentModel.DataAnnotations;

namespace application_lib.Services
{
    public interface IClassValidator
    {
        Answer Check(object obj);
    }

    public class ClassValidator : IClassValidator
    {
        public Answer Check(object obj)
        {
            List<ValidationResult> results = new ();

            var context = new ValidationContext(obj);

            if (!Validator.TryValidateObject(obj, context, results, true))
            {
                return new(300, results[0]!.ErrorMessage!);
            }

            return new(200, "Объект успешно прошел валидацию");
        }
    }
}
