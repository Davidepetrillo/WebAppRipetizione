namespace WebAppRipetizione.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }


        public Post()
        {

        }

        public Post(int id, string title, string description, string image)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Image = image;
        }
    }

    

}
