namespace coursesJwt.api.Business.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripton { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
