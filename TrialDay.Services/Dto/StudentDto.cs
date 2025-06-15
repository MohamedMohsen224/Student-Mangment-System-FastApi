namespace TrialDay.Dto
{
    public record StudentDto ( int id, string FirstName , string LastName , int Age);

    public record CreateStudentRequest (string FirstName , string LastName , int Age);


    public record DeleteReq(int id);

    public class GetStudentRequest
    {

        public int pageindex { get; set; } = 1;

        public int PageSize { get; set; } = 10; 

        public string? Search { get; set; }
    }

}
