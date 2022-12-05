namespace coursesJwt.api.Models
{
    public class ValidateFieldsViewModelOutput
    {
        public IEnumerable<string> Errors { get; private set; }

        public ValidateFieldsViewModelOutput(IEnumerable<string> errors)
        {
            Errors = errors;    
        }
    }
}
